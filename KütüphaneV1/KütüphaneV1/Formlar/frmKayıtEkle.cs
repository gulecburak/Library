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
    public partial class frmKayıtEkle : Form
    {
        public frmKayıtEkle()
        {
            InitializeComponent();
        }
        KContext db = new KContext();

        private void txtKSec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KitapListeleveBul();
        }
        void KitapListeleveBul()
        {
            int turId = int.Parse(txtKSec.SelectedValue.ToString());
            var lst = db.BgKitaps.Where(x => x.TurId ==turId).Select(x=>new {x.Id,x.KitapAdi,x.KitapNo,x.BgDurum.Durum }).ToList();
            kitapList.DataSource = lst;
            foreach (DataGridViewColumn column in kitapList.Columns)
            {
                
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //column.FillWeight = 10;
            }
            //.Columns[0].Visible = false;
        }
        void OgrenciListeleveBul()
        {

            var lst = (from x in db.BgOgrencis
                       where x.SinifNo == txtSinif.Text && x.SubeNo == txtSube.Text
                       select new { x.Id, x.OgrNo, x.OgrAdSoyad, x.SinifNo, x.SubeNo }).ToList();
                /*db.BgOgrencis.Where(x => x.SinifNo == txtSinif.Text && x.SubeNo == txtSube.Text).Select(x => new { x.Id, x.OgrNo, x.OgrAdSoyad, x.SinifNo,x.SubeNo}).ToList();*/
            ogrenciList.DataSource = lst;
            foreach (DataGridViewColumn column in ogrenciList.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //column.FillWeight = 10;
            }
            //ogrenciList.Columns[0].Visible = false;
        }
        private void frmKayıtEkle_Load(object sender, EventArgs e)
        {
            
            txtKSec.DataSource = db.BgTurs.ToList();
            txtKSec.DisplayMember = "TurAdi";
            txtKSec.ValueMember = "Id";
            KitapListeleveBul();
            OgrenciListeleveBul();
        }

        private void txtSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            OgrenciListeleveBul();
        }

        private void txtSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            OgrenciListeleveBul();
        }
        public bool KontrolEtme()
        {   int id= int.Parse(kitapList.CurrentRow.Cells[0].Value.ToString());
            var kontrol = db.BgKitaps.Where(x => x.Id == id).First().DurumId;
            
            if (kontrol==1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Seçtiğiniz kitap rafta değil.");
            }
            return false;
        }
        void Kaydet()
        {
            try
            {
                if (KontrolEtme())
                {
                    int kitapId = int.Parse(kitapList.CurrentRow.Cells[0].Value.ToString());
                    kKitapKontrol kKitap = new kKitapKontrol();
                    bgKitap bgKitap = db.BgKitaps.First(x => x.Id == kitapId);
                    kKitap.KitapId = kitapId;
                    kKitap.OgrenciId = int.Parse(ogrenciList.CurrentRow.Cells[0].Value.ToString()); ;
                    bgKitap.DurumId = 2;
                    kKitap.KVTarih = txtVerilen.Value;
                    kKitap.KATarih = txtTeslim.Value;
                    db.KKitapKontrols.Add(kKitap);
                    db.SaveChanges();
                }
                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);;
            }
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
            Temizle(panel1,panel2,panel3);
        }
        void Temizle(params Panel[] panel)
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (Control item in panel[i].Controls)
                {
                   
                    if (item is DateTimePicker)
                    {
                        ((DateTimePicker)item).Value = DateTime.Now;
                    }
                    if (item is ComboBox)
                    {
                        item.Text = "";
                    }
                    if (item is DataGridView)
                    {
                        ((DataGridView)item).DataSource = "";
                    }
                }
            }
        }
    }
}
