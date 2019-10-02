using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capgemini.GreatOutdoor.Entities;
using Newtonsoft.Json;

namespace Capgemini.GreatOutdoor.Contracts.DALContracts
{
    public class OfflineReturnDetailDALBase
    {
        //Collection of OfflineReturnDetails
        public static List<OfflineReturnDetail> OfflineReturnDetailList = new List<OfflineReturnDetail>();
        private static string fileName = "OfflineReturnDetailss.json";
        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(OfflineReturnDetailList);
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
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var OfflineReturnDetailListFromFile = JsonConvert.DeserializeObject<List<OfflineReturnDetail>>(fileContent);
                if (OfflineReturnDetailListFromFile != null)
                {
                    OfflineReturnDetailList = OfflineReturnDetailListFromFile;
                }
            }
        }
        /// <summary>
        /// Static Constructor.
        /// </summary>
        static OfflineReturnDetailDALBase()
        {
            Deserialize();
        }
    }
}
