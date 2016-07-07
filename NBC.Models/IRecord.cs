using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models
{
    public interface IRecord
    {
        String CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }      
        String ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
