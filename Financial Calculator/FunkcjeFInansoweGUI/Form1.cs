using FinancialFunctions;
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
            Investment inw = new Investment();
            try
            {
                double initialSum = double.Parse(textBox1.Text);
                double interest = double.Parse(textBox2.Text);
                int numberOfPeriods = int.Parse(textBox3.Text);
               
                double result = inw.countFutureValue(initialSum, interest, numberOfPeriods);
                double roundedResult = Math.Round(result, 2);
                label9.Text = roundedResult.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Błąd:", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Investment inw = new Investment();
            try
            {
                double initialSum = double.Parse(textBox4.Text);
                double finalSum = double.Parse(textBox5.Text);
                int numberOfPeriods = int.Parse(textBox6.Text);
                
                double result = inw.countInterestRate(initialSum, finalSum, numberOfPeriods);
                double roundedResult = Math.Round(result, 2);
                label10.Text = roundedResult.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd:",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
