using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.GreatOutdoor.Entities
{
    public class OfflineReturnDetail
    {
        public Guid OfflineReturnDetailID { get; set; }
        public Guid OfflineReturnID { get; set; }
        public Guid ProductID { get; set; }
        public double ReturnQuantity { get; set; }
        public double ReturnAmount { get; set; }
        public enum ReasonForReturn { }
    }
}
