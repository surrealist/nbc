using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NBC.Models
{
    public class Company:IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }       
        public Address Address  { get; set; }
        [StringLength(255)]
        public string ComCode { get; set; }
        public virtual MasSubBusinessType SubBusinessType { get; set; }
        [StringLength(2048)]
        public string BusinessDetail { get; set; }
        [StringLength(255)]       
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }




}
