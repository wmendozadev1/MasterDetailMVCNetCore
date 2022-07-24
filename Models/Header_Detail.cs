using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    public class Header_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     
        public int Header_Detail_Id { get; set; }

        [Required]
        [ForeignKey("Header_Id")]
        public int Header_Id { get; set; }

        [Required]
        [ForeignKey("TypOption_Id")]
        public int TypOption_Id { get; set; }

        public string Header_Detail_Number { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Header_Detail_Date  { get; set; }

        public float Header_Detail_Quantity { get; set; }

        //Este campo sera calculado 
        public float Header_Detail_Estimated { get; set; }
    }
}
