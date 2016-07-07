using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class Applicant : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
        public virtual Company Company { get; set; }     
        public virtual UnitActivity UnitActivity { get; set; }
        public DateTime  ApplyDate { get; set; }
        public Boolean IsApproveTimeTable { get; set; }
        public virtual List<ApplicantPerson> Persons { get; set; }
        public virtual List<TimeTable> TimeTables { get; set; }
        public virtual List<ActualWork> ActualWorks { get; set; }
        public virtual List<ApplicantConsultant> Consultants { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
