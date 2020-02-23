using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Substitution_Techniques
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ceaser firstalgo = new Ceaser();
            string temp = firstalgo.encrypt(textBox1.Text, 29);

            //MessageBox.Show(temp);
            string temp2 = firstalgo.decrypt(temp, 29);
            //MessageBox.Show(temp2);
            int key = firstalgo.Analyse(temp2, temp);
            //MessageBox.Show(key.ToString());

            Playfair secondalgo = new Playfair();
          string dec =   secondalgo.encrypt(textBox1.Text, "playfairexample");
          
          secondalgo.decrypt(dec, "playfairexample"); 

        }
    }
}
