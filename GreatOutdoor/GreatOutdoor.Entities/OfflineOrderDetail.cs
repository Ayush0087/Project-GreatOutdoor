﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.GreatOutdoor.Entities
{
    public class OfflineOrderDetail
    {
        public Guid OfflineOrderDetailID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public Guid OfflineOrderID { get; set; }
    }
}