using System;
using System.Collections.Generic;
using System.Text;
using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;
namespace Capgemini.GreatOutdoor.Entities
{
    public interface IOfflineOrder
    {


        Guid OfflineOrderID { get; set; }
        Guid RetailerID { get; set; }
        Guid SalesPersonID { get; set; }
        double TotalOrderAmount { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedOfflineOrder { get; set; }
        double TotalQuantity { get; set; }
    }
    public class OfflineOrder : IOfflineOrder
    {

        public Guid OfflineOrderID { get; set; }
        public Guid RetailerID { get; set; }
        public Guid SalesPersonID { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalOrderAmount { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedOfflineOrder { get; set; }

    }
}
