using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
   public class TimeTable : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }   
        [Required]    
        public int SeqId { get; set; }
        [ForeignKey("Applicant")]
        public virtual int Applicant_Id { get; set; }
        public virtual Applicant Applicant { get; set; }
        [ForeignKey("ActionType")]
        public virtual int ActionType_Id { get; set; }
        public virtual ActionType ActionType { get; set; }
        [Required]
        public DateTime PlanDate { get; set; }
        [StringLength(2048)]
        public String PlanDetail { get; set; }
        [Required]
        public decimal PlanManDay { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
