using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models
{
    public abstract class WorkPlace:IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Index("IX_WorkPlaceName", IsUnique = true)]
        public String Name { get; set; }
        [StringLength(255)]
        public String Alias { get; set; }
        public Address Adress { get; set; }
        [StringLength(255)]
        public String Tel { get; set; }
        [StringLength(255)]
        public String Email { get; set; }
        [StringLength(2048)]
        public String Notes { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
