using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        int contador = 0;
        int i = 0;
        string[] patentes = new string[1000];
        int[] modelo = new int[1000];
        b formresultados = new b();



        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbxElectrico.Checked)
            {
                string patente = tbPatente.Text;
                int modelos = Convert.ToInt32(tbModelo.Text);
                guardar(modelos, patente);
                cbxElectrico.Checked = false;
            }
            
                contador++;
            
            tbModelo.Clear();
            tbPatente.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEstadista_Click(object sender, EventArgs e)
        {
            burbuja();
            formresultados.lbResult.Items.Clear();
            formresultados.lbResult.Items.Add($"Total Vehiculos Registrados: {contador}");
            for (int j=0; j<i; j++)
            {
                formresultados.lbResult.Items.Add("----------------------------------");
                formresultados.lbResult.Items.Add($"Patente: {patentes[j]} - Modelo: {modelo[j]}");
            }
            formresultados.ShowDialog();
        }

        public void guardar(int modelos, string patente)
        {
            patentes[i] = patente;
            modelo[i] = modelos;
            i++;
        }

        public void burbuja()
        {
            for(int j = 0; j<i-1; j++)
            {
                for(int h = j+1; h<i; h++)
                {
                    if (modelo[j] < modelo[h])
                    {
                        int aux = modelo[h];
                        modelo[h] = modelo[j];
                        modelo[j] = aux;

                        string auxpaten = patentes[h];
                        patentes[h] = patentes[j];
                        patentes[j] = auxpaten;
                    }
                }
            }
        }
    }
}
