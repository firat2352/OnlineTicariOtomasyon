using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName ="Varchar"),StringLength(30)]
        public int UrunAdi { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum{ get; set; }

        [Column(TypeName = "Varchar"), StringLength(250)]
        public string UrunGorsel{ get; set; }

        public Kategori kategori { get; set; }
        public SatisHareket SatisHareket { get; set; }
    }
}