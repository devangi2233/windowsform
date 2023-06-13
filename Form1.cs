using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        private int currentIndex = 0;
        private int targetIndex = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out targetIndex))
            {
                if (targetIndex > 0 && targetIndex <= groupBox1.Controls.Count)
                {
                    currentIndex = 0;
                    SelectNextRadioButton();
                }
                else
                {
                    MessageBox.Show("Invalid index. Please enter a number within the range of RadioButtons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SelectNextRadioButton()
        {

            if (currentIndex >= groupBox1.Controls.Count)
            {
                currentIndex = 0;
            }

            RadioButton radioButton = (RadioButton)groupBox1.Controls[currentIndex];
            radioButton.Checked = true;

            currentIndex++;

            if (currentIndex <= targetIndex)
            {
                Timer timer = new Timer();
                timer.Interval = 1000; // Adjust the interval as per your requirement
                timer.Tick += (sender, e) =>
                {
                    timer.Stop();
                    SelectNextRadioButton();
                };
                timer.Start();
            }

        }
    }
}
