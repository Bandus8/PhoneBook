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
    
    public partial class RecordAdd : Form
        
    {
       
        List<Szemely> szemelyek = new List<Szemely> ();
        public RecordAdd()
        {
            InitializeComponent();
        }
        internal void Betolt(List<Szemely> list)
        { 
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (szemelyek.Count > 0)
            {
                StreamWriter sw = new StreamWriter("szemelyek.txt");
                for (int i = 0; i < szemelyek.Count; i++)
                {
                    sw.WriteLine(szemelyek[i].Név +";"+ szemelyek[i].Cím + ";" + szemelyek[i].Apja + ";" + szemelyek[i].Anyja+";"+ szemelyek[i].Telefon+";"+ szemelyek[i].Nem+";"+szemelyek[i].Email+";"+szemelyek[i].Azon);
                 
                }
                sw.Close();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.Text.Length <= 0)
                {
                    MessageBox.Show("Egy mező nincs kitöltve", "Hiba!");
                    break;
                }
                else
                {
                    
                    szemelyek.Add(new Szemely(nev.Text,cim.Text,apa.Text,anya.Text,int.Parse(tel.Text),nem.Text,email.Text,azon.Text));
                    MessageBox.Show("Rekord hozzáadva!", "Siker");
                   
                }

            }
            foreach (TextBox text in this.Controls.OfType<TextBox>())
            {
                text.Clear();
            }
        }
    }
}
