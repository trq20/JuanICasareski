using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        List<double> Numbers = new List<double>();
        List<string> Oprs = new List<string>();

        bool resolved = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            checkIfResolved();              // Si ya resolvi una cuenta borro la formula anterior

            textBox1.Text += boton1.Text;   // Agrego un digito a el numero actual
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton2.Text;
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton3.Text;
        }

        private void boton4_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton4.Text;
        }

        private void boton5_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton5.Text;
        }

        private void boton6_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton6.Text;
        }

        private void boton7_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton7.Text;
        }

        private void boton8_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton8.Text;
        }

        private void boton9_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton9.Text;
        }

        private void boton0_Click(object sender, EventArgs e)
        {
            checkIfResolved();

            textBox1.Text += boton0.Text;
        }

        private void botonComa_Click(object sender, EventArgs e)
        {
            if (isEmpty(textBox1.Text)) textBox1.Text += "0,";

            else textBox1.Text += botonComa.Text;

        }

        //////////////////////////////////////////////////////////////////////////////////

        private void botonBy_Click(object sender, EventArgs e)
        {
            if (!isEmpty(textBox1.Text))
            {
                textBox2.Text += textBox1.Text;                 // Agrego el numero a la formula
                textBox2.Text += botonBy.Text;                  // Agrego el operador a la formula

                Numbers.Add(Convert.ToDouble(textBox1.Text));  // Agrego el numero actual a la lista
                textBox1.Clear();                               // Limpio el numero actual

                Oprs.Add(botonBy.Text);                         // Agrego el operador a la lista
            }
        }

        private void botonTimes_Click(object sender, EventArgs e)
        {
            if (!isEmpty(textBox1.Text))
            {
                textBox2.Text += textBox1.Text;
                textBox2.Text += botonTimes.Text;

                Numbers.Add(Convert.ToDouble(textBox1.Text));
                textBox1.Clear();

                Oprs.Add(botonTimes.Text);
            }
        }

        private void botonMinus_Click(object sender, EventArgs e)
        {
            if (!isEmpty(textBox1.Text))
            {
                textBox2.Text += textBox1.Text;
                textBox2.Text += botonMinus.Text;

                Numbers.Add(Convert.ToDouble(textBox1.Text));
                textBox1.Clear();

                Oprs.Add(botonMinus.Text);
            }
        }

        private void botonPlus_Click(object sender, EventArgs e)
        {
            if (!isEmpty(textBox1.Text))
            {
                textBox2.Text += textBox1.Text;
                textBox2.Text += botonPlus.Text;

                Numbers.Add(Convert.ToDouble(textBox1.Text));
                textBox1.Clear();

                Oprs.Add(botonPlus.Text);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        
        private void botonEqual_Click(object sender, EventArgs e)
        {
            if (!isEmpty(textBox1.Text))                        // Si el numero actual está vacio no hago nada
            {
                textBox2.Text += textBox1.Text;                 // Agrego el numero a la formula

                Numbers.Add(Convert.ToDouble(textBox1.Text));  // Agrego el numero actual a la variable

                List<double> r = Resolver(Numbers, Oprs);      // Guardo la lista de 1 resultado en otra variable
                string Result = Convert.ToString(r[0]);         // Paso a string el resultado

                textBox1.Clear();                               // Borro el numero actual

                MessageBox.Show($"El resultado es {Result}");   // Muestro el resultado

                textBox2.Text = $"Ans = {Result}";              // Pongo el resultado final como formula 

                Numbers.Clear();                                // Borro los numeros sobrantes 
                Oprs.Clear();                                   // Borro los operadores sobrantes

                resolved = true;                                // Guardo el hecho de q ya resolví una cuenta
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        
        private void botonClearAll_Click(object sender, EventArgs e)
        {   // Limpia toda la formula y el numero actual

            Numbers.Clear();    // Limpio la variable de numeros
            Oprs.Clear();       // Limpio la variable de operadores
            textBox1.Clear();   // Borro el numero actual
            textBox2.Clear();   // Borro toda la formula
        }

        private void botonClear_Click(object sender, EventArgs e)
        {   // Limpia solo el numero actual

            textBox1.Clear();   // Limpio el numero actual
        }

        //////////////////////////////////////////////////////////////////////////////////
        
        public List<double> Resolver(List<double> Numbers, List<string> Oprs)
        {

            while (Oprs.Contains("x") || Oprs.Contains("/"))
            {   // Mientras oprs contenga 'x' o '/', repito

                for (int i = 0; i < Oprs.Count(); i++)
                {   // Para c/u de los operadores en la lista

                    if (Oprs[i] == "x")
                    {   // Si el operador x

                        double result = Numbers[i] * Numbers[i + 1];

                        Numbers.RemoveAt(i + 1);    // Borro el segundo numero del calculo
                        Numbers.RemoveAt(i);        // Borro el primer numero del calculo
                        Oprs.RemoveAt(i);           // Borro el operador del calculo

                        Numbers.Insert(i, result);  // Agrego el resultado a Numbers
                    }
                
                    else if (Oprs[i] == "/")
                    {
                        double result = Numbers[i] / Numbers[i + 1];

                        Numbers.RemoveAt(i + 1);
                        Numbers.RemoveAt(i);
                        Oprs.RemoveAt(i);

                        Numbers.Insert(i, result);
                    }
                }

            }

            while (Oprs.Contains("+") || Oprs.Contains("-"))
            {   // Mientras oprs contenga '+' o '-', repito

                for (int i = 0; i < Oprs.Count(); i++)
                {

                    if (Oprs[i] == "+")
                    {

                        double result = Numbers[i] + Numbers[i + 1];

                        Numbers.RemoveAt(i + 1);
                        Numbers.RemoveAt(i);
                        Oprs.RemoveAt(i);

                        Numbers.Insert(i, result);
                    }

                    else if (Oprs[i] == "-")
                    {
                        double result = Numbers[i] - Numbers[i + 1];

                        Numbers.RemoveAt(i + 1);
                        Numbers.RemoveAt(i);
                        Oprs.RemoveAt(i);

                        Numbers.Insert(i, result);
                    }
                }
            }
            return Numbers;
        }

        public void checkIfResolved() 
        {
            if (resolved)                   // Si ya resolvi una cuenta:
            {
                textBox2.Clear();           // Borro la formula anterior
                resolved = false;           // Guardo el hecho de q no resolví una cuenta
            }
        }

        public bool isEmpty(string str)
        {
            if (str == "") return true;
            else return false;
        }

    }
}