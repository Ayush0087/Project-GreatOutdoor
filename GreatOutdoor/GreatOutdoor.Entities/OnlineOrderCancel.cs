using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.GreatOutdoor.Entities
{
    /// <summary>
    /// An Interface for OnlineOrderCancel Entity
    /// </summary>
    public interface IOnlineOrderCancel
    {
        Guid OrderCancelID { get; set; }
        Guid OrderDetailID { set; get; }
        int QuantityToBeCancelled { set; get; }
        double RefundAmount { set; get; }
    }

    /// <summary>
    /// has the necessary fields for cancelling an order
    /// </summary>
    public class OnlineOrderCancel : IOnlineOrderCancel
    {
        /*Auto-Implemented Properties */
        [Required("OrderCancelId can't be blank.")]
        public Guid OrderCancelID { get; set; }
        [Required("OrderDetailsId can't be blank.")]
        public Guid OrderDetailID { set; get; }//Order Id of the order to be cancelled       
        public int QuantityToBeCancelled { set; get; }//Quantity of the product to be cancelled
        public double RefundAmount { set; get; }//Amount to be refunded to the retailer
    }
}
