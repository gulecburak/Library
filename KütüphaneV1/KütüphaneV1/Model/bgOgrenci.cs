using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneV1.Model
{
    class bgOgrenci
    {
        public int Id { get; set; }
        public int OgrNo { get; set; }
        public string OgrAdSoyad { get; set; }
        public string SinifNo { get; set; }
        public string SubeNo { get; set; }
        public virtual ICollection<kKitapKontrol> KKitapKontrols { get; set; }
    }
}
