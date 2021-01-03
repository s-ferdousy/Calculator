using System;
using System.Windows.Forms;
//clear entry one by one
//second devision and multiplication error
namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        Double resultValue2 = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox.Text == "0") || (isOperationPerformed))
                textBox.Clear();

            isOperationPerformed = false;

            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox.Text.Contains("."))
                    textBox.Text = textBox.Text + button.Text;
            }
            else
                textBox.Text = textBox.Text + button.Text;

        }
        private void operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(resultValue != 0)
            {
                buttonEqual.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            textBox.Text = "0";
            labelCurrentOperation.Text = resultValue + " " + operationPerformed + " " + textBox.Text;
        }

        private void clearEntryButton(object sender, EventArgs e)
        {
            labelCurrentOperation.Text = textBox.Text;
            textBox.Text = "0";
        }

        private void clearButton(object sender, EventArgs e)
        {
            textBox.Text = "0";
            labelCurrentOperation.Text = "0";
            resultValue = 0;

        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            labelCurrentOperation.Text = resultValue + " " + operationPerformed + " " + textBox.Text;
            switch (operationPerformed)
            {
                case "+":
                    textBox.Text = (resultValue + Double.Parse(textBox.Text)).ToString();
                    break;
                case "-":
                    textBox.Text = (resultValue - Double.Parse(textBox.Text)).ToString();
                    break;
                case "*":
                    textBox.Text = (resultValue * Double.Parse(textBox.Text)).ToString();
                    break;
                case "/":
                    textBox.Text = (resultValue / Double.Parse(textBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            //resultValue = Double.Parse(textBox.Text);
            resultValue = 0;
            //labelCurrentOperation.Text = "";
            isOperationPerformed = false;
            //resultValue = Double.Parse(textBox.Text);
            //textBox.Text = "0";
        }
    }
}
