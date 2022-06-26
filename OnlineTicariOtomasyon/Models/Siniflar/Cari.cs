using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int CariAd { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int CariSoyad { get; set; }

        [Column(TypeName = "Varchar"), StringLength(20)]
        public int CariSehir { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int CariMail { get; set; }

        public SatisHareket SatisHareket { get; set; }
    }
}