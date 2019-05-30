using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KütüphaneV1.Model;

namespace KütüphaneV1.Formlar
{
    public partial class frmOgrenciEkle : Form
    {
        public frmOgrenciEkle()
        {
            InitializeComponent();
        }
        KContext db = new KContext();

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Temizle()
        {
            foreach (Control control in splitContainer1.Panel1.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";

                }
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;

                }
            }
        }
        void OgrenciEkle()
        {
            bgOgrenci ogrenci = new bgOgrenci();
            ogrenci.OgrNo =int.Parse( txtOgrNo.Text);
            ogrenci.OgrAdSoyad = txtOgrenciAdi.Text;
            ogrenci.SinifNo = txtSinif.Text;
            ogrenci.SubeNo = txtSube.Text;
            db.BgOgrencis.Add(ogrenci);
            db.SaveChanges();
            MessageBox.Show("Öğrenci kayıt edilmiştir.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OgrenciEkle();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
