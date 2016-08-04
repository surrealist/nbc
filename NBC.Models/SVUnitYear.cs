﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace NBC.Models
{
    public class SVUnitYear : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Year")]
        public virtual int Year_Id { get; set; }
        [ScriptIgnore]
        public virtual Year Year { get; set; }       
        public virtual SV SV { get; set; }      
        public virtual Unit Unit { get; set; }

        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}
