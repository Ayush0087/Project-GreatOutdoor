using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Contracts.BLContracts;
using Capgemini.GreatOutdoor.Contracts.DALContracts;
using Capgemini.GreatOutdoor.DataAccessLayer;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.Exceptions;
using Capgemini.GreatOutdoor.Helpers.ValidationAttributes;

namespace Capgemini.GreatOutdoor.BusinessLayer
{/// <summary>
/// view sales reports validations class
/// </summary>
    public class ViewSalesReportsBL
    {
       /// <summary>
       /// lists all the sales persons reports
       /// </summary>
       /// <returns></returns>
        public async Task<List<ViewSalesReports>> ViewAllSalesReportsBL()
        {
            List<ViewSalesReports> viewSales = new List<ViewSalesReports>();
            try
            {
                
                ViewSalesReports item=new ViewSalesReports();
                SalesPersonDAL splist = new SalesPersonDAL();
                List<SalesPerson> salesPersonList = splist.GetAllSalesPersonsDAL();
                

                foreach (SalesPerson sp in  salesPersonList)
                {
                    item.SalespersonID = sp.SalesPersonID;
                    item.SalespersonName = sp.SalesPersonName;
                    item.LastUpdatedsalestime = default(DateTime);
                    OfflineOrderBL offorder = new OfflineOrderBL();
                    List<OfflineOrder> newlist = await offorder.GetOfflineOrderBySalesPersonIDBL(item.SalespersonID);
                    item.OfflinesalesCount = newlist.Count;
                    if (item.OfflinesalesCount > 100)
                    {
                        item.Target = "exceeded";
                    }
                    else if (item.OfflinesalesCount == 100)
                    {
                        item.Target = "Met";
                    }
                    else
                    {
                        item.Target = "Not Met";
                    }
                    viewSales.Add(item);

                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
           return viewSales;
            
        }

    }
    }

