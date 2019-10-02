using System;
using System.Collections.Generic;
using System.Linq;
using Capgemini.GreatOutdoor.Helpers;
using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;

namespace Capgemini.GreatOutdoor.Entities
{
    /// <summary>
    /// Interface for OnlineReturn Entity
    /// </summary>
    public interface IOnlineReturn
    {
        Guid OnlineReturnID { get; set; }
        PurposeOfReturn Purpose { get; set; }
        int QuantityOfReturn { get; set; }
        Guid OrderID { get; set; }
        Guid ProductID { get; set; }
        double ReturnAmount { get; set; }
        double ProductPrice { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }

    }

    /// <summary>
    /// Represents OnlineReturn
    /// </summary>
    public class OnlineReturn : IOnlineReturn
    {
        /* Auto-Implemented Properties */
        [Required("OnlineReturnID can't be blank.")]
        public Guid OnlineReturnID { get; set; }
        [Required("Quantity can't be blank.")]
       // [RegExp(@"^[1-9]+[0-9]*)$", "Quantity cannot be less than 0.")]
        public int QuantityOfReturn { get; set; }
        [Required("ProductID can't be blank.")]
        public Guid ProductID { get; set; }
        [Required("OrderID can't be blank.")]
        public Guid OrderID { get; set; }
        [Required("ReturnAmount can't be blank.")]
        public double ReturnAmount { get; set; }
        [Required("ProductPrice can't be blank.")]
        public double ProductPrice { set; get; }
        [Required("PurposeOfReturn can't be blank.")]
        public PurposeOfReturn Purpose { get; set; }
        public Guid RetailerID { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        /* Constructor */
        public OnlineReturn()
        {
            OnlineReturnID = default(Guid);
            Purpose = default(PurposeOfReturn);
            OrderID = default(Guid);
            ProductID = default(Guid);
            ReturnAmount = 0.0;
            QuantityOfReturn = 0;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}