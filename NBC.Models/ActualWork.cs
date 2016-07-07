using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class ActualWork : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SeqId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual ActionType ActionType { get; set; }  
        public DateTime ActionDate { get; set; }
        [StringLength(2048)]
        public String ActionDetail { get; set; }
        public decimal ActionManDay { get; set; }        
        public virtual FileDaily FileDailyReport { get; set; }
        public virtual FileAction FileAction { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
