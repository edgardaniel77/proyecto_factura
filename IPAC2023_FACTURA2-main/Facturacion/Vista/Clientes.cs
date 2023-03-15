using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        string tipoOperacion;

        DataTable dt = new DataTable();
        ClienteDB ClienteDB = new ClienteDB();
        Cliente cliente = new Cliente();

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

        }
        private void HabilitarControles()
        {
            NIdentidadtextBox.Enabled = true;
            NombretextBox.Enabled = true;
            TelefonotextBox.Enabled = true;
            CorreotextBox.Enabled = true;
            DirecciontextBox.Enabled = true;
            NacimientodateTimePicker.Enabled = true;
            EstaActivocheckBox.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Eliminarbutton.Enabled = true;

        }
        private void DeshabilitarControles()
        {
            NIdentidadtextBox.Enabled = false;
            NombretextBox.Enabled = false;
            TelefonotextBox.Enabled =  false ;
            CorreotextBox.Enabled = false;
            DirecciontextBox.Enabled = false;
            NacimientodateTimePicker.Enabled = false;
            EstaActivocheckBox.Enabled = false;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;
            Eliminarbutton.Enabled = false;
        }
        private void LimpiarControles()
        {
            NIdentidadtextBox.Clear();
            NombretextBox.Clear();      
            TelefonotextBox.Clear();
            CorreotextBox.Clear();
            EstaActivocheckBox.Checked= false;

        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

    }
    

    }

    


