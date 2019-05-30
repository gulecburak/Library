using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneV1.Model
{
    class bgTur
    {
        public int Id { get; set; }
        public string TurAdi { get; set; }
        public virtual ICollection<bgKitap> BgKitaps { get; set; }
    }
}
