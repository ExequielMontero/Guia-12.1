using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indice = lbPrueba.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("No selecciono nada");
            }
            else
            {
                MessageBox.Show($"Mi indice es {indice}");
            }
            lbPrueba.SelectedIndex = -1;
            lbPrueba.Items.RemoveAt(indice);
        }
    }
}
