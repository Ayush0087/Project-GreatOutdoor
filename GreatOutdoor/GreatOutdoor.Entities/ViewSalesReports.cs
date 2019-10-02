using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;

namespace Capgemini.GreatOutdoor.Entities
{/// <summary>
/// viewing sales reports class
/// </summary>
    public class ViewSalesReports
    {
        string salespersonName;
        int offlinesalesCount;
        Guid salespersonID;
        string target;
        DateTime lastUpdatedsalestime;


        public string SalespersonName { get => salespersonName; set => salespersonName = value; }
        public int OfflinesalesCount { get => offlinesalesCount; set => offlinesalesCount = value; }
        public Guid SalespersonID { get => salespersonID; set => salespersonID = value; }
        public string Target { get => target; set => target = value; }
        public DateTime LastUpdatedsalestime { get => lastUpdatedsalestime; set => lastUpdatedsalestime = value; }
        /// <summary>
        /// assigning default values to the fields.
        /// </summary>
        public ViewSalesReports()
        {
            SalespersonName = null;
            OfflinesalesCount = 0;
            SalespersonID = default(Guid);
            Target = "Not Met";
            LastUpdatedsalestime = default(DateTime);
        }
        
    }

    

}

