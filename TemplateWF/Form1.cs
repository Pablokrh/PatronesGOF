using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateWF
{
    public partial class Form1 : Form
    {
        List<Cliente> _clientes;
        List<String> _creditos;

        public Form1()
        {
            InitializeComponent();

            _clientes = new List<Cliente>();
            _clientes.Add(new Cliente() { Nombre = "Carlos Arequipa" });
            _clientes.Add(new Cliente() { Nombre = "Lorena Balmaceda" });
            cb_Clientes.DataSource = _clientes;

            _creditos = new List<string>();
            _creditos.Add("Personal");
            _creditos.Add("Hipotecario");
            cb_Creditos.DataSource = _creditos; 
        }

        private void btn_Solicitar_Click(object sender, EventArgs e)
        {
            var credito = cb_Creditos.SelectedItem.ToString();
            Cliente cliente = (Cliente)cb_Clientes.SelectedItem;
            
            try
            {
                if (credito == null) throw new Exception("Debe seleccionar un tipo de crédito");
                Credito c;
                //Aclara que en vez de un switch podría haberse utilizado un strategy o builder
                switch (credito)
                {
                    case "Hipotecario":
                        c = new CreditoHipotecario(cliente);
                        break;

                    case "Personal":
                        c = new CreditoPersonal(cliente);
                        break;

                    default:
                        throw new Exception("Debe seleccionar un tipo de crédito");
                }
                txt_Display.Clear();
                txt_Display.Lines = c.Verificar();
            } catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
