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
    public partial class frmKitapEkle : Form
    {
        public frmKitapEkle()
        {
            InitializeComponent();
        }
        KContext db = new KContext();
        private void frmKitapEkle_Load(object sender, EventArgs e)
        {
            txtTur.DataSource = db.BgTurs.ToList();
            txtTur.DisplayMember = "TurAdi";
            txtTur.ValueMember = "Id";
        }
        void Temizle()
        {
            foreach (Control control in splitContainer1.Panel1.Controls)
            {
                if (control is TextBox )
                {
                    control.Text = "";

                }
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;

                }
            }
        }
        void KitapKaydet()
        {
            try
            {
                bgKitap kitap = new bgKitap();
                kitap.KitapAdi = txtKAdi.Text;
                kitap.KitapNo = txtKNo.Text;
                kitap.TurId = int.Parse(txtTur.SelectedValue.ToString());
                kitap.DurumId = 1;
                db.BgKitaps.Add(kitap);
                db.SaveChanges();
                MessageBox.Show("Kitap kayıt edilmiştir.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KitapKaydet();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
