using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models {
  public class Setting {

    /// <summary>
    /// default profile name is "DEFAULT"
    /// </summary>
    [Key]
    public string Profile { get; set; }

    public int? CurrentYearId { get; set; }
     
  }
}
