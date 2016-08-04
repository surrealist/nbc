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

        [ForeignKey("Company")]     
        public virtual int Company_Id { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("UnitActivity")]
        public virtual int UnitActivity_Id { get; set; }
        public virtual UnitActivity UnitActivity { get; set; }
        public DateTime  ApplyDate { get; set; }
        public Boolean IsApproveTimeTable { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual ICollection<ApplicantPerson> ApplicantPersons { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        public virtual ICollection<ActualWork> ActualWorks { get; set; }
        public virtual ICollection<ApplicantConsultant> ApplicantConsultants { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Applicant()
        {
            ApplicantPersons = new HashSet<ApplicantPerson>();
            TimeTables = new HashSet<TimeTable>();
            ActualWorks = new HashSet<ActualWork>();
            ApplicantConsultants = new HashSet<ApplicantConsultant>();
        }

    }
}
