using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Helpers;
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
        protected static List<Product> productList = new List<Product>();
        private static string fileName = "products.json";

        //Methods for CRUD
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product GetProductByProductIDDAL(Guid productID);
        public abstract List<Product> GetProductsByProductCategoryDAL(Category givenCategory);
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
