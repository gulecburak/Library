using KütüphaneV1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneV1.Formlar
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        KContext db = new KContext();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lst = db.SKullanicilars.ToList();
                foreach (var item in lst)
                {
                    if (item.KAdi == textBox1.Text && item.KSifre == textBox2.Text)
                    {
                        Close();
                        break;
                        
                    }
                    else
                    {
                        MessageBox.Show("Yanlış girdiniz.");
                        return;
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
