using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneV1.Model
{
    class kKitapKontrol
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        [ForeignKey("KitapId")]
        public virtual bgKitap BgKitap { get; set; }
        public int OgrenciId { get; set; }
        [ForeignKey("OgrenciId")]
        public virtual bgOgrenci BgOgrenci { get; set; }
        public DateTime KVTarih { get; set; } // Kitabın verildiği tarih
        public DateTime KATarih { get; set; } // Kitabın teslim tarihi
        
    }
}
