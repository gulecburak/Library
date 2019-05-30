using KütüphaneV1.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneV1.Model
{
    class KContext :DbContext
    {
        public KContext() : base("KContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KContext, Configuration>("KContext"));
        }
        public virtual DbSet<bgKitap> BgKitaps { get; set; } // bgFirmalar veritabanındaki tablo ismi.
        public virtual DbSet<bgTur> BgTurs { get; set; }
        public virtual DbSet<bgDurum> BgDurums { get; set; }
        public virtual DbSet<bgOgrenci> BgOgrencis { get; set; }
        public virtual DbSet<kKitapKontrol> KKitapKontrols { get; set; }
        public virtual DbSet<sKullanicilar> SKullanicilars { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // tablo ismindeki s takılarını kaldırır.
            base.OnModelCreating(modelBuilder);
        }
    }
}
