using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana_4
{
    public partial class Form1 : Form
    {
        Persona persona = new Persona();
        List<Persona> listPersonas = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            persona.nombre = txtName.Text;
            persona.apellidos = txtLastName.Text;
            persona.cédula = Convert.ToInt32(txtID.Text);
            persona.nacionalidad = cbxNacionalidad.SelectedItem.ToString();
            listPersonas.Add(persona);
            txtName.Text = "";
            txtLastName.Text = "";
            txtID.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            TreeNode nodenacional = new TreeNode("Nacionales");
            TreeNode nodeinternacional = new TreeNode("Internacionales");
            for (int i = 0; i <= listPersonas.Count - 1; i++)
            {
                if (listPersonas.ElementAt(i).nacionalidad.Equals("Nacional"))
                {
                    TreeNode node = new TreeNode(listPersonas.ElementAt(i).VerPersona());
                    nodenacional.Nodes.Add(node);
                }
                else
                {
                    TreeNode node = new TreeNode(listPersonas.ElementAt(i).VerPersona());
                    nodeinternacional.Nodes.Add(node);
                }
            }
            form2.treeView1.Nodes.Add(nodenacional);
            form2.treeView1.Nodes.Add(nodeinternacional);
            form2.Show();
        }
    }
}
