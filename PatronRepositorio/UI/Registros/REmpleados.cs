using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio.UI.Registros
{
    public partial class REmpleados : Form
    {
        public REmpleados()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            IDNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            SueldoTextBox.Text = string.Empty;
            IncentivoTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            DireccionTextBox.Text = string.Empty;
        }

        public Empleado LlenarClase()
        {
            Empleado empleado = new Empleado();

            empleado.Empleadoid = Convert.ToInt32(IDNumericUpDown.Value);
            empleado.Nombres = NombreTextBox.Text;
            empleado.Direccion = DireccionTextBox.Text;
            empleado.Celular = CelularMaskedTextBox.Text;
            empleado.Fecha = FechadateTimePicker.Value;
            empleado.Incentivo = Convert.ToDecimal(IncentivoTextBox.Text);
            empleado.Sueldo = Convert.ToDecimal(SueldoTextBox.Text);
            empleado.Telefono = TelefonoMaskedTextBox.Text;
            empleado.Cedula = CedulaMaskedTextBox.Text;

            return empleado;
        }

        public void LlenarCampo(Empleado empleado)
        {
            IDNumericUpDown.Value = empleado.Empleadoid;
            NombreTextBox.Text = empleado.Nombres;
            CedulaMaskedTextBox.Text = empleado.Cedula;
            TelefonoMaskedTextBox.Text = empleado.Telefono;
            CelularMaskedTextBox.Text = empleado.Celular;
            SueldoTextBox.Text = Convert.ToString(empleado.Sueldo);
            IncentivoTextBox.Text = Convert.ToString(empleado.Incentivo);
            FechadateTimePicker.Value = empleado.Fecha.Date;
            DireccionTextBox.Text = empleado.Direccion;
         
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado empleado = repositorio.Buscar((int)IDNumericUpDown.Value);
            return empleado != null;
        }

        public bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El Campo nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelularMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CelularMaskedTextBox, "El Campo celular no puede estar vacio");
                CelularMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "El Campo telefono no puede estar vacio");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulaMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CedulaMaskedTextBox, "El Campo cedula no puede estar vacio");
                CedulaMaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(SueldoTextBox.Text))
            {
                MyErrorProvider.SetError(SueldoTextBox, "El Campo sueldo no puede estar vacio");
                SueldoTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "El Campo direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Empleado empleado = new Empleado();
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            if (!validar())
                return;

            empleado = LlenarClase();

            if (IDNumericUpDown.Value == 0)
                paso = repositorio.Guardar(empleado);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No existe en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(empleado);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDNumericUpDown.Text, out id);

            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            if (repositorio.Buscar(id) != null)
            {
                if (repositorio.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MyErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar este registro");
                IDNumericUpDown.Focus();
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;

            int.TryParse(IDNumericUpDown.Text, out id);
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            Empleado empleado = new Empleado();

            empleado = repositorio.Buscar(id);

            Limpiar();

            if(empleado == null)
            {
                MessageBox.Show("Persona no encontrada");
            }
            else
            {
                LlenarCampo(empleado);
            }

        }

    }
}
