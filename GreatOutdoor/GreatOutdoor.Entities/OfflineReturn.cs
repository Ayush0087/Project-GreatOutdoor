using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.GreatOutdoor.Entities
{
    public class OfflineReturn

    {


        // Auto implemented Properties
        public Guid OfflineReturnID { get; set; }
        public Guid OfflineOrderID { get; set; }
        public double TotalReturnAmount { get; set; }
        public DateTime DateOfOfflineReturn { get; set; }


    }
}

