using Assignment.Contracts;
using Assignment.Data.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.FileManagers
{
    public class CSVFileReader : IFileProcessor

    {
        
        public void ReadFile(string path)
        {
            throw new NotImplementedException();
        }

        public List<STORE_ORDER> ReadFile(StreamReader streamReader)
        {
            List<STORE_ORDER> listCSVRecrods = new List<STORE_ORDER>();
            try
            {
                
                string[] csvFields;
                string csvLine = "";
                STORE_ORDER order;
                while ((csvLine = streamReader.ReadLine()) != null)
                {
                    order = new STORE_ORDER();
                   
                    csvFields = csvLine.Split(",");
                    order.ORDER_ID = csvFields[(int)CSVHeaders.OrdeID];

                    order.ORDER_DATE = !string.IsNullOrEmpty(csvFields[(int)CSVHeaders.OrderDate]) ? DateTime.ParseExact((csvFields[(int)CSVHeaders.OrderDate]), "dd.MM.yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    order.SHIP_DATE = !string.IsNullOrEmpty(csvFields[(int)CSVHeaders.ShipDate]) ? DateTime.ParseExact((csvFields[(int)CSVHeaders.OrderDate]), "dd.MM.yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;
                    order.SHIP_MODE =csvFields[(int)CSVHeaders.ShipMode];
                    order.CUSTOMER_ID= csvFields[(int)CSVHeaders.CustomerID];
                    order.CUSTOMER_NAME= csvFields[(int)CSVHeaders.CustomerName];
                    order.PRODUCT_ID = csvFields[(int)CSVHeaders.ProductID];
                    order.QUANTITY = Convert.ToInt32(csvFields[(int)CSVHeaders.CustomerID]);
                    order.DISCOUNT = Convert.ToDecimal(csvFields[(int)CSVHeaders.Discount]);
                    order.PROFIT = Convert.ToDecimal(csvFields[(int)CSVHeaders.Profit]);
                    listCSVRecrods.Add(order);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return listCSVRecrods;

        }
    }
}
