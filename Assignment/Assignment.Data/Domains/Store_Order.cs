using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Data.Domains
{
    public class STORE_ORDER
    {
        public int ID { get; set; }
        public string  ORDER_ID{ get; set; }
        public DateTime? ORDER_DATE { get; set; }
        public DateTime ?SHIP_DATE { get; set; }
        public string SHIP_MODE { get; set; }
        public int QUANTITY { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal PROFIT { get; set; }
        public string  PRODUCT_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CATEGORY { get; set; }
        public string CUSTOMER_ID { get; set; }

        //      ID INT AUTO_INCREMENT PRIMARY KEY,
        //ORDER_ID VARCHAR(20) UNIQUE NOT NULL,
        //ORDER_DATE DATE NOT NULL,
        //SHIP_DATE DATE NOT NULL,
        //SHIP_MODE VARCHAR(20),
        //QUANTITY INT NOT NULL,
        //DISCOUNT DECIMAL(3,2),
        //PROFIT DECIMAL(6,2) NOT NULL,
        //PRODUCT_ID VARCHAR(20) UNIQUE NOT NULL,
        //CUSTOMER_NAME VARCHAR(255) NOT NULL,
        //CATEGORY VARCHAR(255) NOT NULL,
        //CUSTOMER_ID VARCHAR(20) UNIQUE NOT NULL
    }
}
