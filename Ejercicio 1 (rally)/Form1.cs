using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1__rally_
{
    public partial class Form1 : Form
    {
        b formagregar = new b();
        c formtiempos = new c();
        d formresultados = new d();
        int contador = 0;
        int[] minutos = new int[1000];
        string[] nombres = new string[1000];


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formtiempos.lbCompetidor.Text = Convert.ToString(contador + 1);

            if (formtiempos.ShowDialog() == DialogResult.OK)
            {
                int hora = Convert.ToInt32(formtiempos.tbHoras.Text);
                int minuto = Convert.ToInt32(formtiempos.tbMinutos.Text);
                int total = hora * 60 + minuto;
                if (minuto<60 && minuto>0)
                {
                    tiempos(total);
                    btnAgregar.Enabled = true;
                    btnTiempos.Enabled = false; 
                }
                else
                {
                    MessageBox.Show("¡Minutos fuera de rango!");
                    formtiempos.tbHoras.Clear();
                    formtiempos.tbMinutos.Clear();
                }
                formtiempos.tbMinutos.Clear();
                formtiempos.tbHoras.Clear();    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (formagregar.ShowDialog() == DialogResult.OK)
            {
                string nombre = Convert.ToString(formagregar.tbNombre.Text);
                misnombres(nombre);
                btnAgregar.Enabled = false;
                btnTiempos.Enabled = true;
            }
            formagregar.tbNombre.Clear();
          
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            formresultados.lbResultados.Items.Clear();
            burbuja();
            for (int j = 0; j < contador; j++)
            {
                formresultados.lbResultados.Items.Add($"Nombre: {nombres[j]}");
                formresultados.lbResultados.Items.Add($"Tiempo: {minutos[j]/60}:{minutos[j]%60}");
                formresultados.lbResultados.Items.Add("------------------------------------------------");
            }
            formresultados.ShowDialog();
      
        }


        //Mis metodos
        public void misnombres(string nombre)
        {
            nombres[contador] = nombre;

        }

        public void tiempos(int minuto)
        {
            minutos[contador] = minuto;
            contador++;
        }

        public void burbuja()
        {
            for(int i=0; i<contador-1; i++)
            {
                for(int j = i+1; j<contador; j++)
                {
                    if (minutos[i] < minutos[j])
                    {
                        int aux = minutos[j];
                        minutos[j] = minutos[i];
                        minutos[i] = aux;

                        string auxnom = nombres[j];
                        nombres[j] = nombres[i];
                        nombres[i] = auxnom;
                    }
                }
            }
        }


    }
}
