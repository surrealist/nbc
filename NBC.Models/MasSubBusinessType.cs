using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models
{
    public class MasSubBusinessType : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public MasBusinessType BusinessType { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
