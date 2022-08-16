using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    public class UserCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserComp_Id { get; set; }

        public string AspNetUser_Id { get; set; }
        public int Comp_Id { get; set; }
        //public int Act_Id { get; set; }
        public DateTime UserComp_CreateDate { get; set; }
        public DateTime? UserComp_DisableDate { get; set; }
        public bool UserComp_Active { get; set; }
    }
}
