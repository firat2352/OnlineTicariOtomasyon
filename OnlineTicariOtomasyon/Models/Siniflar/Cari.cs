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

        [Column(TypeName = "Varchar"), StringLength(30,ErrorMessage ="30'dan fazla karakter giremezsiniz"),Required(ErrorMessage ="Lütfen Cari Adını Giriniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30, ErrorMessage ="30'dan fazla karakter giremezsiniz"), Required(ErrorMessage = "Lütfen Cari Soyadını Giriniz")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar"), StringLength(20)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar"), StringLength(20)]
        public string CariSifre { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}