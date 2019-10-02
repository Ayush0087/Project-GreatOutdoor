using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.GreatOutdoor.Entities
{
    class OrderDetails
    {
        public Guid OrderDetailsId { get; set; } //ID of the order details
        public Guid CartProductId { get; set; } //ID of Cart Product
        public Guid OrderId { get; set; } //ID of the order placed
    }
}
