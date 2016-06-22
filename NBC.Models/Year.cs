using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models {
    public class Year
    {

        /// <summary>
        /// Year number in BD. example: 2559
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsLock { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
