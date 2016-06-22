using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class ActualWork
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SeqId { get; set; }


        public TimeTable TimeTable { get; set; }

        public ActionType ActionType { get; set; }


        public List<Applicant> Applicants { get; set; }


        public DateTime ActionDate { get; set; }
        [StringLength(2048)]
        public String ActionDetail { get; set; }

        public int ActionManDay { get; set; }

        //2 file var left




        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
