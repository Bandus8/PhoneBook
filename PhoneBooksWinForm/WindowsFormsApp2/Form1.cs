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
    public partial class Form1 : Form
    {
        public int alap = 10;
        RecordAdd addform = new RecordAdd();
        ListContact ListContact = new ListContact();
        Modify modify = new Modify();
        public List<Szemely> list = new List<Szemely>();
        public Form1()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("szemelyek.txt");
            while (!sr.EndOfStream) 
            {
                string sor;
                string[] s;
                sor = sr.ReadLine();
                s = sor.Split(';');
                list.Add(new Szemely(s[0], s[1], s[2], s[3], int.Parse(s[4]), s[5], s[6], s[7]));
            }
            for (int i = alap; i < list.Count; i++)
            {
                list.Remove(list[i]);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListContact.p.Count == 0)
            {
               ListContact.Betolt();
            }
            ListContact.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (modify.p.Count == 0)
            {
                modify.Betolt();
            }
           
            modify.ShowDialog();
        }
    }
    public class Szemely
    {
        public string Név;
        public string Cím;
        public string Apja;
        public string Anyja;
        public int Telefon;
        public string Nem;
        public string Email;
        public string Azon;

        public Szemely(string név, string cím, string apja, string anyja, int telefon, string nem, string email, string azon)
        {
            Név = név;
            Cím = cím;
            Apja = apja;
            Anyja = anyja;
            Telefon = telefon;
            Nem = nem;
            Email = email;
            Azon = azon;
        }

        public override string ToString()
        {
            return Név;
        }
    }
}
