using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar"), StringLength(10)]
        public int KullaniciAdi { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public int Sifre { get; set; }

        [Column(TypeName = "Char"), StringLength(1)]
        public int Yetki { get; set; }
    }
}