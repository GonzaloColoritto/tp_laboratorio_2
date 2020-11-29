using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormPrincipal : Form
    {
        Numero numero = new Numero();
        

        public FormPrincipal()
        {
            InitializeComponent();
            
        }

        private void limpiar()
        {
            txtNumero1.Text = null;
            txtNumero2.Text = null;
            cmbOperador.SelectedItem = null;
            lblResultado.Text = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            limpiar();

        }
        public static double  Operar(string numero1, string numero2, string operador) 
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            if(operador == null)
            {
                operador = " ";
            }
            resultado = Calculadora.Operar(num1,num2,operador[0]);

           
            return resultado;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

                e.Cancel = true;
            }
           
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            int aux1, aux2;
            if (int.TryParse(txtNumero1.Text, out aux1) && int.TryParse(txtNumero2.Text, out aux2))
            {
                if (FormPrincipal.Operar(this.txtNumero1.Text, this.txtNumero2.Text, (string)this.cmbOperador.SelectedItem) == double.MinValue)
                {
                    lblResultado.Text = "ERROR";
                }
                else
                {
                    lblResultado.Text = " " + FormPrincipal.Operar(this.txtNumero1.Text, this.txtNumero2.Text, (string)this.cmbOperador.SelectedItem);
                }
            }
            else { lblResultado.Text = "ERROR: ingrese solo numeros."; }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            limpiar();

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            
            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
           
        }

        private void btnCovertirADecimal_Click(object sender, EventArgs e)
        {

            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
