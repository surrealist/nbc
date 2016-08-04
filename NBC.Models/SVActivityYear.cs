using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace NBC.Models
{
    public class SVActivityYear : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Target { get; set; }
        [ForeignKey("Year")]
       
        public virtual int Year_Id { get; set; }
        [ScriptIgnore]
        public virtual Year Year { get; set; }
        //[ForeignKey("SV")]
        //public virtual int SV_Id { get; set; }
        public virtual SV SV { get; set; }
        [ForeignKey("ActitivityType")]
        [Required]
        public virtual string ActitivityType_Id { get; set; }
        public virtual ActivityType ActitivityType { get; set; }       
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
