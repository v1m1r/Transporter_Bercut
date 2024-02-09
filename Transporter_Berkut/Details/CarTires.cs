using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporter_Berkut.Model;

namespace Transporter_Berkut.Details
{
    class CarTires : Detail
    {
        public override string Type_Detail { get; set; }
        public override string PartName { get; set; }
        public override bool Success { get; set; }
    }
}
