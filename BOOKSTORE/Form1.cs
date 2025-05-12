using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1 = new Button();
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.Location = new Point(100, 100);
            button1.MouseEnter += button1_MouseEnter;

            Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Login form = new Login(); //Hides
            form.Show();
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Login newForm = new Login();
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = new Point(this.Right, this.Top);
            newForm.Show();

            Timer slideTimer = new Timer();
            slideTimer.Interval = 10;

            slideTimer.Tick += (s, ev) =>
            {
                if (newForm.Left > this.Left + 50)
                {
                    newForm.Left -= 20;
                }
                else
                {
                    slideTimer.Stop();
                }
            };

            slideTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.Show();
            this.Hide();
        }
    }
}
