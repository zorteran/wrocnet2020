using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogElkDemo.Web.Models
{
    public class OperationViewModel
    {
        [DisplayName("First Number")]
        public int FirstNumber { get; set; }
        [DisplayName("Second Number")]
        public int SecondNumber { get; set; }
        [DisplayName("Result")]
        public double? Result { get; set; }

    }
}
