using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mtdsCongruencia
{
    public partial class Form : System.Windows.Forms.Form
    {
        double[] resultados;

        public Form()
        {
            InitializeComponent();
            nudX.Value = 1;
            nudA.Value = 6;
            nudB.Value = 9;
            nudM.Value = 13;
            nudN.Value = 12;
            cbxMetodos.SelectedIndex = 0;
            //MessageBox.Show("resultado = "+getXi(1,6,9,13));
        }

        private void metodoMixto(int numero)
        {
            int x = Convert.ToInt32(nudX.Value);
            int a = Convert.ToInt32(nudA.Value);
            int b = Convert.ToInt32(nudB.Value);
            int m = Convert.ToInt32(nudM.Value);
            int xi = getXiMixto(x, a, b, m);

            for (int i = 0; i < numero; i++) 
            {
                resultados[i] = getUiMixto(xi, m);
                //MessageBox.Show("Ui = " + resultados[i] + " con Xi = "+xi);
                dataGridView1.Rows.Add(i+1, xi, resultados[i]);
                xi = getXiMixto(xi, a, b, m);
            }
        }

        private void metodoMultiplicativo(int numero)
        {
            int x = Convert.ToInt32(nudX.Value);
            int a = Convert.ToInt32(nudA.Value);
            int b = Convert.ToInt32(nudB.Value);
            int m = Convert.ToInt32(nudM.Value);
            int xi = getXiMultiplicativo(x, a, b, m);

            for (int i = 0; i < numero; i++)
            {
                resultados[i] = getUiMultiplicativo(xi, m);
                //MessageBox.Show("Ui = " + resultados[i] + " con Xi = "+xi);
                dataGridView1.Rows.Add(i + 1, xi, resultados[i]);
                xi = getXiMultiplicativo(xi, a, b, m);
            }
        }

        private int getXiMixto(int x, int a, int b, int m) 
        {
            return (x*a+b)%m;
        }

        private double getUiMixto(int xi, int m)
        {
            return (double)xi /m;
        }

        private int getXiMultiplicativo(int x, int a, int b, int m)
        {
            return (x * a) % m;
        }

        private double getUiMultiplicativo(int xi, int m)
        {
            return (double)xi / (m-1);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int numero = Convert.ToInt32(nudN.Value);
            resultados = new double[numero];

            if (cbxMetodos.SelectedIndex == 0)
            {
                metodoMixto(numero);
            }
            else if(cbxMetodos.SelectedIndex == 1)
            {
                metodoMultiplicativo(numero);
            }
        }
    }
}