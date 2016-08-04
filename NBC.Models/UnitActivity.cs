using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class UnitActivity : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       // [StringLength(255)]
       // [Required]
        //[Index("IX_UnitActivityName", IsUnique = true)]
      //  public String Name { get; set; }
        [ForeignKey("Unit")]
        public virtual int Unit_Id { get; set; }
        public virtual Unit Unit { get; set; }
        [ForeignKey("SVActivityYear")]
        public virtual int SVActivityYear_Id { get; set; }
        public virtual SVActivityYear SVActivityYear { get; set; }
        public int Target { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
