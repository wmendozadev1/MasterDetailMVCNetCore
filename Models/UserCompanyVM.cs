using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    [Table("UserCompanyVM")]
    public partial class UserCompanyVM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserComp_Id { get; set; }
        public int Comp_Id { get; set; }
        public string Comp_Name { get; set; }
        public string AspNetUser_Id { get; set; }
                
        public string UserName { get; set; }
        public int Act_Id { get; set; }
        public string Act_Name { get; set; }
        public string Act_LastName { get; set; }
        
        [NotMapped]
        public virtual string FullName
        {
            get => Act_Name + " " + Act_LastName + " / " + UserName;
            set { }
        }

        public DateTime UserComp_CreateDate { get; set; }
        public DateTime? UserComp_DisableDate { get; set; }
        public bool UserComp_Active { get; set; }
    }
}
