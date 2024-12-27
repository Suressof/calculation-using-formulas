using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вычисление_по_формулам
{
    public partial class Калькулятор : Form
    {
        public Калькулятор()
        {
            InitializeComponent();
        }

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!textBox_Result.Text.Contains(","))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;


        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;        
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            labelCurrentOperation.Text = "";
            resultValue = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                labelCurrentOperation.Text = resultValue + " " + operationPerformed + " " + textBox_Result.Text + " = ";
                switch (operationPerformed)
                {
                    case "+":
                        textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "-":
                        textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "*":
                        textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "/":
                        textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBox_Result.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте, вы ввели не правильные значения", "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

    }
}
