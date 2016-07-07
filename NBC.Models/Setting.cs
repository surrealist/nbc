using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models {
    public class Setting : IRecord
    {

        /// <summary>
        /// default profile name is "DEFAULT"
        /// </summary>
        [Key]
        public string Profile { get; set; }

        public int? CurrentYearId { get; set; }
        public bool MailEnable { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
