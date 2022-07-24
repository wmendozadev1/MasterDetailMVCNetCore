using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    public class Header
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Header_Id { get; set; }
        public string Header_Comment { get; set; }
        public virtual List<Header_Detail> Header_Detail { get; set; } = new List<Header_Detail>();


    }
}
