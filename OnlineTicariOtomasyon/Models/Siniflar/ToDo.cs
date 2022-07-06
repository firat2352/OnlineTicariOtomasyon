using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Siniflar
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Column(TypeName = "Varchar"), StringLength(30)]
        public string Title { get; set; }

        [Column(TypeName = "bit")]
        public bool State { get; set; }
    }
}