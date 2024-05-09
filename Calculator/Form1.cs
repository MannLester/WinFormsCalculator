using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        double result = 0;
        String operation = "";
        bool isPerformed = false;
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            pictureBox.Visible = false;

            txtInput.Visible = true;

            if((txtInput.Text == "0") || (isPerformed))
            {
                txtInput.Clear();
            }
            isPerformed = false;
            Button button = (Button)sender;

            if(button.Text == ".")
            {
                if (!txtInput.Text.Contains("."))
                {
                    txtInput.Text += button.Text;    
                }
            }
            else
            {
                txtInput.Text += button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(result != 0)
            {
                btnEqual.PerformClick();
                operation = button.Text;
                isPerformed = true;
            }
            else
            {
                operation = button.Text;
                result = Double.Parse(txtInput.Text);
                isPerformed = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtInput.Text = (result + Double.Parse(txtInput.Text)).ToString();
                    break;
                case "-":
                    txtInput.Text = (result - Double.Parse(txtInput.Text)).ToString();
                    break;
                case "*":
                    txtInput.Text = (result * Double.Parse(txtInput.Text)).ToString();
                    break;
                case "/":
                    if(Double.Parse(txtInput.Text) != 0)
                    {
                        txtInput.Text = (result / Double.Parse(txtInput.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cannot Divide By Zero!");
                    }
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtInput.Text);
            operation = "";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
            pictureBox.Visible = true;
            txtInput.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(txtInput.Text.Length > 0)
            {
                txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1);
                if(txtInput.Text.Length == 0)
                {
                    txtInput.Text = "0";
                    pictureBox.Visible = true;
                    txtInput.Visible = false;
                }
            }
        }
    }
}
