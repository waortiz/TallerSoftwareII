using Nutricion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nutricion
{
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "El nombre es obligatorio");
                return;
            }
            else
            {
                erpMensaje.SetError(txtNombre, "");
            }
            //TODO: VALIDAR Número de Documento
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento debe ser menor a la fecha actual");
                return;
            }

            Entidades.Paciente paciente = new Entidades.Paciente();
            paciente.PrimerNombre = txtNombre.Text;
            paciente.NumeroDocumento = Convert.ToInt64(txtNumeroDocumento.Text);
            paciente.FechaNacimiento = dtpFechaNacimiento.Value;
            paciente.TipoDocumento = cboTipoDocumento.SelectedItem as TipoDocumento;

            Control.ControlPaciente controlPaciente = new Control.ControlPaciente();
            controlPaciente.IngresarPaciente(paciente);

            MessageBox.Show("Paciente ingresado exitosamente");
        }

        private void Paciente_Load(object sender, EventArgs e)
        {
            List<TipoDocumento>
                tiposDocumento = new List<TipoDocumento>();

            tiposDocumento.Add(new TipoDocumento() { Id = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { Id = 2, Nombre = "Tarjeta de Identidad" });

            cboTipoDocumento.DataSource = tiposDocumento;
            cboTipoDocumento.DisplayMember = "Nombre";
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 || 
                (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }

        private void dtpFechaNacimiento_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                erpMensaje.SetError(dtpFechaNacimiento, 
                    "La fecha de nacimiento debe ser menor a la fecha actual");
            }
            else
            {
                erpMensaje.SetError(dtpFechaNacimiento, string.Empty);
            }
        }
    }
}
