using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    public class Company
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Comp_Id { get; set; }
        public string Comp_Name { get; set; }
        public DateTime Comp_CreateDate { get; set; }
        public bool Comp_Active { get; set; }

    }
}
