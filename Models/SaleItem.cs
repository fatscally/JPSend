using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Jp.Models
{
    public class SaleItem : SaleItemModel
    {
        public static List<SaleItem> SaleItems = new();


        public static SaleItem CreateRandomItem()
        {

            Random r = new();
            int range = 20;
            //random price
            double rndPrice = Math.Round(r.NextDouble() * range, 2);
            //random fruit
            int fruitId = r.Next(3);



            SaleItem itm = new();

            itm.Id = Guid.NewGuid();
            itm.ProductType = JPS.Fruits.GetFruit(fruitId);
            itm.ProductValue = rndPrice;


            return itm;

        }

        public static SaleItem GetSaleItem(int index)
        {
            return SaleItems[index]; 
        }

        public static void CreateSaleItems()
        {
            SaleItems.Add(new SaleItem() { ProductType = "Apple", ProductValue = 10 });
            SaleItems.Add(new SaleItem() { ProductType = "Apple", ProductValue = 20 });
            SaleItems.Add(new SaleItem() { ProductType = "Apple", ProductValue = 30 });
            SaleItems.Add(new SaleItem() { ProductType = "Banana", ProductValue = 15 });
            SaleItems.Add(new SaleItem() { ProductType = "Banana", ProductValue = 15 });
            SaleItems.Add(new SaleItem() { ProductType = "Banana", ProductValue = 15 });
            SaleItems.Add(new SaleItem() { ProductType = "Banana", ProductValue = 15 });
            SaleItems.Add(new SaleItem() { ProductType = "Cherry", ProductValue = 20 });
            SaleItems.Add(new SaleItem() { ProductType = "Cherry", ProductValue = 20 });
            SaleItems.Add(new SaleItem() { ProductType = "Date", ProductValue = 40 });
            SaleItems.Add(new SaleItem() { ProductType = "Date", ProductValue = 40 });
            SaleItems.Add(new SaleItem() { ProductType = "Date", ProductValue = 40 });
            SaleItems.Add(new SaleItem() { ProductType = "Elderberry", ProductValue = 25 });
            SaleItems.Add(new SaleItem() { ProductType = "Elderberry", ProductValue = 25 });
            SaleItems.Add(new SaleItem() { ProductType = "Elderberry", ProductValue = 25 });
            SaleItems.Add(new SaleItem() { ProductType = "Elderberry", ProductValue = 25 });
            SaleItems.Add(new SaleItem() { ProductType = "Fig", ProductValue = 35 });
        }




        public string ToXml()
        {
            XmlSerializer xmlSerializer = new(GetType());

            using StringWriter textWriter = new();
            xmlSerializer.Serialize(textWriter, this);

            return textWriter.ToString();

        }

    }
}
