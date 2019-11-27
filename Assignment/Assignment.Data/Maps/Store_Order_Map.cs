
using Assignment.Data.Domains;

namespace Assignment.Database.Mpas
{
   
    public class Store_Order_Map
    {
        public Store_Order_Map(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<STORE_ORDER> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.HasKey(t => t.ORDER_DATE);
            entityBuilder.HasKey(t => t.ORDER_ID);
            entityBuilder.HasKey(t => t.SHIP_DATE);
            entityBuilder.HasKey(t => t.SHIP_MODE);
            entityBuilder.HasKey(t => t.QUANTITY);
            entityBuilder.HasKey(t => t.DISCOUNT);
            entityBuilder.HasKey(t => t.PROFIT);
            entityBuilder.HasKey(t => t.PRODUCT_ID);
            entityBuilder.HasKey(t => t.CUSTOMER_NAME);
            entityBuilder.HasKey(t => t.CATEGORY);
            entityBuilder.HasKey(t => t.CUSTOMER_ID);

        }

    }
}
