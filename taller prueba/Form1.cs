using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller_prueba
{
    public partial class Form1 : Form
    {
        string[] patentes = new string[30];
        int i = 0, basico=0, completo=0;
        double[] total = new double[30];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string patente = tbPatente.Text;
            if (rbSimple.Checked)
            {
                if (i <= 29)
                {
                    guardarpatente(patente);
                    total[i] = 3800;
                    i++;
                    basico++;
                }
                else
                {
                    MessageBox.Show("No hay mas turnos");
                }
            }
            else if (rbCompleto.Checked)
            {
                if (i <= 29)
                {
                    guardarpatente(patente);
                    total[i] = 5200;
                    i++;
                    completo++;
                }
                else
                {
                    MessageBox.Show("No hay mas turnos");
                }
            }

            for(int j=i; j<=i; j++)
            {
                lbEspera.Items.Add(patentes[i-1]);
            }
            rbSimple.Checked = false;
            rbCompleto.Checked = false;
            tbPatente.Clear();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            int indice = lbEspera.SelectedIndex;
            string buscado = Convert.ToString(lbEspera.Items[indice]);
            int ret = metodobusquedasecuencial(buscado);
            if(indice == -1)
            {
                MessageBox.Show("No selecciono nada");
            }
            else
            {
                MessageBox.Show($"La patente {patentes[ret]} debe pagar {total[ret]} por el servicio");
                lbEspera.Items.RemoveAt(indice);
                lbEspera.SelectedIndex = -1;
            }
        }

        public void guardarpatente(string patente)
        {
            patentes[i] = patente;
        }

        public int metodobusquedasecuencial(string buscado)
        {
            
            int ret = -1, contador=0;
            while(ret==-1 && contador<i)
            {
                if (buscado == patentes[contador])
                {
                    ret = contador;
                }
                contador++;
            }

            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double recaudado = totalrecaudado();
            MessageBox.Show($"Total Recaudado: {recaudado:c} | Motos Atendidas: {i} | Total simples: {basico} | Total Completo: {completo}");
            Close();
        }

        public double totalrecaudado()
        {
            double recaudado = 0;
            for(int j=0; j<i; j++)
            {
                recaudado += total[j];
            }

            return recaudado;
        }
    }
}
