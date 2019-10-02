using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Capgemini.GreatOutdoor.Entities;
using System.IO;

namespace Capgemini.GreatOutdoor.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for ProductDAL class 
    /// </summary>
    public abstract class ProductDALBase
    {
        //Collection od Products
        public static List<Product> productList = new List<Product>()
        {
            new Product(){ProductID=Guid.NewGuid(),ProductName="Tent\t",ProductCategory="Camping Equipment",ProductPrice=1000.00,ProductDescription="Color:Blue, Material:Polyester"},
              new Product(){ProductID=Guid.NewGuid(),ProductName="Tent\t",ProductCategory="Camping Equipment",ProductPrice=1000.00,ProductDescription="Color:Red, Material:Polyester"},
                new Product(){ProductID=Guid.NewGuid(),ProductName="Sleeping Bag",ProductCategory="Camping Equipment",ProductPrice=1500.00,ProductDescription="Color:Black, Material:Nylon"},
                  new Product(){ProductID=Guid.NewGuid(),ProductName="Golf Bag",ProductCategory="Golf Equipment",ProductPrice=500.00,ProductDescription="Color:Blue, Material:Leather"},
                    new Product(){ProductID=Guid.NewGuid(),ProductName="Golf Ball",ProductCategory="Golf Equipment",ProductPrice=200.00,ProductDescription="Color:White, Material:Plastic and Rubber"},
                      new Product(){ProductID=Guid.NewGuid(),ProductName="Climbing Helmet",ProductCategory="Mountaineering Equipment",ProductPrice=1200.00,ProductDescription="Color:Black, Material:Polystyrene"},
                        new Product(){ProductID=Guid.NewGuid(),ProductName="Rain Coat",ProductCategory="Outdoor Protection",ProductPrice=500.00,ProductDescription="Color:Navy Blue, Material:Fabric"}

        };
        private static string fileName = "products.json";

        //Methods for CRUD
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product GetProductByProductIDDAL(Guid productID);
        public abstract List<Product> GetProductsByProductCategoryDAL(string productCategory);
        public abstract List<Product> GetProductsByProductNameDAL(string productName);
        public abstract bool UpdateProductDescriptionDAL(Product updateProduct);
        public abstract bool AddProductDAL(Product addProduct);
        public abstract bool DeleteProductDAL(Guid deleteProductID);
        public abstract bool UpdateProductPriceDAL(Product updateProduct);

        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(productList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = String.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var productListFromFile = JsonConvert.DeserializeObject<List<Product>>(fileContent);
                if (productListFromFile != null)
                {
                    productList = productListFromFile;
                }
            }
        }

        /// <summary>
        ///Static Constructor. 
        /// </summary>
        static ProductDALBase()
        {
            Deserialize();
        }

    }
}
