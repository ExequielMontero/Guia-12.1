using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Ejercicio_3
{
    public partial class Form1 : Form
    {

        int[] ids = new int[100];
        string[] nacionalidades = { "Argentina", "China", "Brasil", "Chile", "Uruaguay" };
        double[] peso = new double[100];
        int[] indice = new int[100];
        b cargardatos = new b();
        int[] filtrador = new int[100];
        Resultados datos = new Resultados();
        int[] filtradorid = new int[100];
        int i = 0, q = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargardatos.ShowDialog();
            if (cargardatos.DialogResult == DialogResult.OK)
            {
                int id = Convert.ToInt32(cargardatos.tbID.Text); //Cargo ID del contenedor
                int pais = cargardatos.cmxPais.SelectedIndex; //cargo indice de pais elegido de mi ComboBox
                double peso = Convert.ToDouble(cargardatos.tbPeso.Text); //Cargo el peso de mi contenedor
                guardardatos(id, pais, peso); //Guardo datos
            }
            cargardatos.tbID.Clear();                       
            cargardatos.tbPeso.Clear();                        //Hago Limpieza
            cargardatos.cmxPais.SelectedIndex = -1;        
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            datos.lbResultados.Items.Clear();
            int buscar = cmxPais.SelectedIndex;
            if (buscar == -1)
            {
                MessageBox.Show("No selecciono nada");
            }
            else
            {
                metodosecuencial(buscar);
                metodoburbuja();
                for (int ñ = 0; ñ < q; ñ++)
                {
                    datos.lbResultados.Items.Add($"{filtradorid[ñ]} - {nacionalidades[buscar]} - {peso[filtrador[ñ]]}");
                }
                datos.ShowDialog();
                cmxPais.SelectedIndex = -1;
            }
        }

        public void guardardatos(int id, int pais, double peso)
        {
            ids[i] = id;
            this.peso[i] = peso;
            indice[i] = pais;
            i++;
        }

        public void metodosecuencial(int buscar)
        {
            q = 0;
            for (int j = 0; j < i; j++)
            {
                if (buscar == indice[j])
                {
                    filtrador[q] = j; //guarda los indice de los contenedores del mismo pais
                    filtradorid[q] = ids[j]; //guarda los id que son del pais buscado para luego ordenarlos
                    q++;
                }
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            datos.lbResultados.Items.Clear();
            ordenarcontenedores();
            for (int ñ = 0; ñ < i; ñ++)
            {
                datos.lbResultados.Items.Add($"{ids[ñ]} - {nacionalidades[indice[ñ]]} - {peso[ñ]}");
            }
            datos.ShowDialog();
        }

        public void metodoburbuja()
        {
            for (int l = 0; l < q - 1; l++)
            {
                for (int s = l + 1; s < q; s++)                 /*Me ordena los indice guardado en el
                                                                 * vector y tambien me ordena los ID*/
                {
                    if (filtradorid[l] > filtradorid[s])
                    {
                        int aux = filtradorid[s];
                        filtradorid[s] = filtradorid[l];
                        filtradorid[l] = aux;

                        int auxin = filtrador[s];
                        filtrador[s] = filtrador[l];
                        filtrador[l] = auxin;
                    }
                }
            }
        }

        public void ordenarcontenedores()
        {
            for(int a = 0; a<i-1; a++)
            {
                for(int s = a+1; s<i; s++)
                {
                    if (ids[a] > ids[s])
                    {
                        int aux = ids[s];
                        ids[s] = ids[a];
                        ids[a] = aux;

                        int auxind = indice[s];
                        indice[s] = indice[a];
                        indice[a] = auxind;

                        double auxpeso = peso[s];
                        peso[s] = peso[a];
                        peso[a] = auxpeso;

                    }
                }
            }
        }


    }
}


