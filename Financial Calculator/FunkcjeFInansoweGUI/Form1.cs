using FunkcjeFinansowe;
using System;
using System.Windows.Forms;

namespace FunkcjeFInansoweGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inwestycja inwestycja = new Inwestycja();
            try
            {
                double kwotaPoczatkowa = double.Parse(textBox1.Text);
                double oprocentowanie = double.Parse(textBox2.Text);
                int liczbaOkresow = int.Parse(textBox3.Text);
                double wynik = inwestycja.wartoscPrzyszla
                    (kwotaPoczatkowa, oprocentowanie, liczbaOkresow);
                double wynikZaokr = Math.Round(wynik, 2);
                label9.Text = wynikZaokr.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Błąd:", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inwestycja inwestycja = new Inwestycja();
            try
            {
                double kwotaPoczatkowa = double.Parse(textBox4.Text);
                double kwotaKoncowa = double.Parse(textBox5.Text);
                int liczbaOkresow = int.Parse(textBox6.Text);
                double wynik = inwestycja.wyliczStope
                    (kwotaPoczatkowa, kwotaKoncowa, liczbaOkresow);
                double wynikZaokr = Math.Round(wynik, 2);
                label10.Text = wynikZaokr.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
