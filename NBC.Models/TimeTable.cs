using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
   public class TimeTable : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       
        public int SeqId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual ActionType ActionType { get; set; }
        public DateTime PlanDate { get; set; }
        [StringLength(2048)]
        public String PlanDetail { get; set; }
        public decimal PlanManDay { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
