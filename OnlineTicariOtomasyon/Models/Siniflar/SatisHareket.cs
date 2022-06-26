﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId{ get; set; }
        public DateTime Tarih{ get; set; }
        public int Adet{ get; set; }
        public decimal Fiyat{ get; set; }
        public decimal ToplamTutar { get; set; }

        public ICollection<Urun> Urunler { get; set; }
        public ICollection<Cari> Cariler { get; set; }
        public ICollection<Personel> Personel { get; set; }
    }
}