using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class DinamikFatura
    {

        public IEnumerable<Fatura> FaturaProp { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalemProp { get; set; }
       
    }
}