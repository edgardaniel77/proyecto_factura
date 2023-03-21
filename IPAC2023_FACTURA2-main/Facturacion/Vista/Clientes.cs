using Datos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
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
            NIdentidadtextBox.Focus();
            HabilitarControles();
            tipoOperacion = "Nuevo";

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
            TelefonotextBox.Enabled = false;
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
            EstaActivocheckBox.Checked = false;

        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(NIdentidadtextBox.Text))
                {
                    errorProvider1.SetError(NIdentidadtextBox, "Ingrese no. de identidad");
                    NIdentidadtextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(NombretextBox.Text))
                {
                    errorProvider1.SetError(NombretextBox, "Ingrese un nombre");
                    NombretextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TelefonotextBox.Text))
                {
                    errorProvider1.SetError(TelefonotextBox, "Ingrese un numero de telefono");
                    TelefonotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(CorreotextBox.Text))
                {
                    errorProvider1.SetError(CorreotextBox, "Ingrese el correo");
                    CorreotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(DirecciontextBox.Text))
                {
                    errorProvider1.SetError(DirecciontextBox, "Ingrese la direccion");
                    CorreotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                cliente.Identidad = NIdentidadtextBox.Text;
                cliente.Nombre = NombretextBox.Text;
                cliente.Telefono = TelefonotextBox.Text;
                cliente.Correo = CorreotextBox.Text;
                cliente.Direccion = DirecciontextBox.Text;
            }
            bool inserto = ClienteDB.Insertar(cliente);

            if (inserto)
            {
                LimpiarControles();
                DeshabilitarControles();
                TraerClientes();
                MessageBox.Show("Registro Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar el registro");
            }
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            TraerClientes();
        }
        private void TraerClientes()
        {
          dt = ClienteDB.DevolverClientes();
            ClientesdataGridView.DataSource= dt;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ClientesdataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = ClienteDB.Eliminar(ClientesdataGridView.CurrentRow.Cells["NIdentidadCliente"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        TraerClientes();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

       
    }


    }


    


