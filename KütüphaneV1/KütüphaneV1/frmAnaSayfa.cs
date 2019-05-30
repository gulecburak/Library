using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KütüphaneV1.Formlar;
using KütüphaneV1.Model;

namespace KütüphaneV1
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }


        KContext db = new KContext();
        frmGiris giris;
        frmKitapEkle kEkle;
        frmOgrenciEkle oEkle;
        frmKayıtEkle frmEkle;
        int i = 5;
        public void LabelDoldurma()
        {
            try
            {
                var lst = db.BgKitaps.GroupBy(x => x.Id)
                      .Select(y => new
                      {
                          Id = y.Key,
                          Quantity = y.Count()
                      }).ToList();
                lblTumKitap.Text = (from s in db.BgKitaps
                                    group s by s.KitapAdi into g
                                    select new { KitapAdi = g.Key, KitapSayisi = g.Count() }).ToList().Count().ToString();
                lblKutuphane.Text = (from s in db.BgKitaps
                                     where s.BgDurum.Durum == "Rafta"
                                     group s by s.KitapAdi into g
                                     select new { KitapAdi = g.Key, KitapSayisi = g.Count() }).ToList().Count().ToString();
                lblAlinan.Text = (from s in db.BgKitaps
                                  where s.BgDurum.Durum == "Rafta Değil"
                                  group s by s.KitapAdi into g
                                  select new { KitapAdi = g.Key, KitapSayisi = g.Count() }).ToList().Count().ToString();
                var textKitap = (from s in db.KKitapKontrols
                                 where s.BgKitap.BgDurum.Durum == "Rafta Değil"
                                 orderby s.Id descending
                                 select new { s.BgKitap.KitapAdi }).First().KitapAdi;
                var textOgr = (from s in db.KKitapKontrols
                               where s.BgKitap.BgDurum.Durum == "Rafta Değil"
                               orderby s.Id descending
                               select new { s.BgOgrenci.OgrAdSoyad }).First().OgrAdSoyad;
                var textVTarih = (from s in db.KKitapKontrols
                                  where s.BgKitap.BgDurum.Durum == "Rafta Değil"
                                  orderby s.Id descending
                                  select new { s.KVTarih }).First().KVTarih.ToShortDateString();
                stlblAKitap.Text = " Son Alınan Kitap : " + textKitap;
                stlblAOgr.Text = "--Alan Öğrenci : " + textOgr;
                stlblTarih.Text = "--Kitabın Alındığı Tarih : " + textVTarih;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message); ;
            }


        }
        void Listele()
        {
            var lst = db.KKitapKontrols.Select(x => new { Kitap_Adı = x.BgKitap.KitapAdi, Kitap_No = x.BgKitap.KitapNo, Tür_Adı = x.BgKitap.BgTur.TurAdi, Öğrenci_No = x.BgOgrenci.OgrNo, Öğrenci_AdSoyad = x.BgOgrenci.OgrAdSoyad, Sınıf = x.BgOgrenci.SinifNo, Şube = x.BgOgrenci.SubeNo, Verildiği_Tarih = x.KVTarih, Teslim_Tarihi=x.KATarih }).ToList();
            kontrolListe.DataSource = lst;

            foreach (DataGridViewColumn column in kontrolListe.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = 10;

            }
        }
        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {

            if (giris == null || giris.IsDisposed)
            {
                giris = new frmGiris();

                giris.ShowDialog();
                LabelDoldurma();

                Listele();
                tmGuncelle.Start();
            }

        }
        private void kayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEkle = new frmKayıtEkle();
            frmEkle.ShowDialog();

        }
        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            kEkle = new frmKitapEkle();
            kEkle.ShowDialog();

        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oEkle = new frmOgrenciEkle();
            oEkle.ShowDialog();
        }



        private void tmGuncelle_Tick(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                LabelDoldurma();
                Listele();
                tmGuncelle.Stop();
                i = 5;
                tmGuncelle.Start();
            }
        }

        private void kontrolListe_Paint(object sender, PaintEventArgs e)
        {

            foreach (DataGridViewColumn c in kontrolListe.Columns)
                c.HeaderText = c.HeaderText.Replace("_", " ");

        }
    }
}
