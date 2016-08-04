using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models
{
    public class ApplicantPerson: IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //todo set unique ยังไง ถ้าต้องการให้เช็คว่า Applicant, Person นี้ไม่ให้ซ้ำ
        [ForeignKey("Applicant")]
        public virtual int Applicant_Id { get; set; }
        public virtual Applicant Applicant { get; set; }

        [ForeignKey("Person")]
        public virtual int Person_Id { get; set; }
        public virtual Person Person { get; set; }
        public bool IsMainPerson { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
