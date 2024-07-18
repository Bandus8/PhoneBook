using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Modify : Form
    {
        public List<Szemely> p = new List<Szemely>();
        public Modify()
        {
            InitializeComponent();
        }
        internal void Betolt()
        {
            StreamReader sr = new StreamReader("szemelyek.txt");
            while (!sr.EndOfStream)
            {
                string sor;
                string[] s;
                sor = sr.ReadLine();
                s = sor.Split(';');
                p.Add(new Szemely(s[0], s[1], s[2], s[3], int.Parse(s[4]), s[5], s[6], s[7]));

            }
            if (p.Count > -1)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    listBox1.Items.Add(p[i]);
                }
            }


            sr.Close();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = p[listBox1.SelectedIndex].Név;
            textBox2.Text = p[listBox1.SelectedIndex].Cím;
            textBox3.Text = p[listBox1.SelectedIndex].Apja;
            textBox4.Text = p[listBox1.SelectedIndex].Anyja;
            textBox5.Text = Convert.ToString(p[listBox1.SelectedIndex].Telefon);
            textBox6.Text = p[listBox1.SelectedIndex].Nem;
            textBox7.Text = p[listBox1.SelectedIndex].Email;
            textBox8.Text = p[listBox1.SelectedIndex].Azon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p[listBox1.SelectedIndex].Név = textBox1.Text;
            p[listBox1.SelectedIndex].Cím = textBox2.Text;
            p[listBox1.SelectedIndex].Apja = textBox3.Text;
            p[listBox1.SelectedIndex].Anyja = textBox4.Text;
            p[listBox1.SelectedIndex].Telefon = int.Parse(textBox5.Text);
            p[listBox1.SelectedIndex].Nem = textBox6.Text;
            p[listBox1.SelectedIndex].Email = textBox7.Text;
            p[listBox1.SelectedIndex].Azon = textBox8.Text;
        }
    }
}
