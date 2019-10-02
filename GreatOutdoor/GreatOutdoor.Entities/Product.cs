using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;

namespace Capgemini.GreatOutdoor.Entities
{
    /// <summary>
    /// Interface for Product Entity
    /// </summary>    
    public interface IProduct
    {
        Guid ProductID { get; set; }
        string ProductName { get; set; }
        string ProductCategory { get; set; }
        string ProductDescription { get; set; }
        double ProductPrice { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }
    }
    /// <summary>
    /// Represents Product
    /// </summary>

    public class Product : IProduct
    {
        /* Auto-Implemented Properties*/
        [Required("Product ID can't be blank!")]
        public Guid ProductID { get; set; }

        [Required("Product Name can't be blank!")]
        [RegExp(@"^(\w{2,40})$", "Product Name should contain only 2 to 40 characters.")]
        public string ProductName { get; set; }

        [Required("Product Category can't be blank!")]
        [RegExp(@"^(\w{2,40})$", "Product Category should contain only 2 to 40 characters.")]
        public string ProductCategory { get; set; }

        [Required("Product Description can't be blank!")]
        [RegExp(@"^(\w:\s?,;{2,1000})$", "Product Description should contain only 2 to 1000 characters.")]
        public string ProductDescription { get; set; }

        [Required("Product price can't be blank!")]
        [RegExp(@"(^\d+\.\d{1,2}$)", "Product price should be positive with only two decimal characters")]
        public double ProductPrice { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }


        /* Constructor */
        public Product()
        {
            ProductID = default(Guid);
            ProductName = null;
            ProductCategory = null;
            ProductDescription = null;
            ProductPrice = default(double);
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
        }
    }
}

