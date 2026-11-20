using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Semana_4
{
    public partial class Form1 : Form
    {
        private readonly PersonaRepository _repository = new PersonaRepository();

        public Form1()
        {
            InitializeComponent();
            if (cbxNacionalidad.Items.Count > 0 && cbxNacionalidad.SelectedIndex < 0)
            {
                cbxNacionalidad.SelectedIndex = 0;
            }
            UpdateTitleCount();
        }

        public PersonaRepository Repository => _repository;

        private void UpdateTitleCount()
        {
            this.Text = string.Format("Registro de Personas ({0})", _repository.Personas.Count);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nacionalidad = cbxNacionalidad.SelectedItem != null
                ? cbxNacionalidad.SelectedItem.ToString()
                : cbxNacionalidad.Text;

            Persona creada;
            string error;
            if (!_repository.TryAdd(txtName.Text, txtLastName.Text, txtID.Text, nacionalidad, out creada, out error))
            {
                MessageBox.Show(error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtName.Clear();
            txtLastName.Clear();
            txtID.Clear();
            txtName.Focus();
            UpdateTitleCount();
            MessageBox.Show(
                string.Format("Persona agregada: {0}", creada.VerPersona()),
                "Registro exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_repository.Personas.Count == 0)
            {
                MessageBox.Show("Aún no hay personas registradas.", "Listado vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Form2 form2 = new Form2())
            {
                TreeNode nodeNacional = new TreeNode("Nacionales");
                TreeNode nodeInternacional = new TreeNode("Internacionales");

                foreach (Persona persona in _repository.Personas)
                {
                    TreeNode node = new TreeNode(persona.VerPersona()) { Tag = persona };
                    if (string.Equals(persona.nacionalidad, "Nacional", StringComparison.OrdinalIgnoreCase))
                    {
                        nodeNacional.Nodes.Add(node);
                    }
                    else
                    {
                        nodeInternacional.Nodes.Add(node);
                    }
                }

                form2.treeView1.BeginUpdate();
                try
                {
                    form2.treeView1.Nodes.Clear();
                    form2.treeView1.Nodes.Add(nodeNacional);
                    form2.treeView1.Nodes.Add(nodeInternacional);
                    form2.treeView1.ExpandAll();
                }
                finally
                {
                    form2.treeView1.EndUpdate();
                }

                form2.ShowDialog(this);
            }
        }
    }
}
