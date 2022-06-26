using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int PersonelAd { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar"), StringLength(250)]
        public string PersonelGorsel { get; set; }

        public SatisHareket SatisHareket { get; set; }
        public Departman Departman{ get; set; }
    }
}