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

namespace PatronRepositorio.UI.Consultas
{
    public partial class CEmpleados : Form
    {
        public CEmpleados()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            var Listado = new List<Empleado>();
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        Listado = repositorio.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        Listado = repositorio.GetList(p => p.Empleadoid == id);
                        break;
                    case 2:
                        Listado = repositorio.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        Listado = repositorio.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;
                }
                Listado = Listado.Where(c => c.Fecha.Date >= DesdeDateTimePicker.Value.Date && c.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                Listado = repositorio.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = Listado;
        }
    }
}
