using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneV1.Model
{
    class bgKitap
    {
        public int Id { get; set; }
        
        public string KitapAdi { get; set; }
        public string KitapNo { get; set; }
        public int TurId { get; set; }
        [ForeignKey("TurId")]
        public virtual bgTur BgTur { get; set; }
        public int DurumId { get; set; }
        [ForeignKey("DurumId")]
        public virtual bgDurum BgDurum { get; set; }

        public virtual ICollection<kKitapKontrol> KKitapKontrols { get; set; }

    }
}
