using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class ListContact : Form
    {
        public List<Szemely> p = new List<Szemely>();
        public ListContact()
        {
            InitializeComponent();
        }

        internal void Betolt()
        {
            StreamReader sr = new StreamReader("szemelyek.txt");
            while(!sr.EndOfStream) 
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
            label2.Text = p[listBox1.SelectedIndex].Név;
            label3.Text = p[listBox1.SelectedIndex].Cím;
            label4.Text = p[listBox1.SelectedIndex].Apja;
            label5.Text = p[listBox1.SelectedIndex].Anyja;
            label6.Text = Convert.ToString(p[listBox1.SelectedIndex].Telefon);
            label7.Text = p[listBox1.SelectedIndex].Nem;
            label8.Text = p[listBox1.SelectedIndex].Email;
            label9.Text = p[listBox1.SelectedIndex].Azon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
