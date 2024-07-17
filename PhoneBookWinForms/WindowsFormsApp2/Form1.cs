using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        RecordAdd addform = new RecordAdd();
        ListContact ListContact = new ListContact();
        public List<Szemely> list = new List<Szemely>();
        public Form1()
        {
            InitializeComponent();
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
            ListContact.Betolt();
            ListContact.ShowDialog();
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
