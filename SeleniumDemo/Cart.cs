using System;
using System.Collections.Generic;

namespace AmazonDemo
{
    public class Cart
    {
        public static void Main(string[] args)
        {
            bool isError;
            Item objItem1 = new Item("Samsung Galaxy M06 5G (Sage Green, 6GB RAM, 128 GB Storage)");
            Item objItem2 = new Item("Samsung Galaxy M06 5G (Aquatic Blue, 4GB RAM, 64 GB Storage)");

            List<Item> listItems = new List<Item>();
            listItems.Add(objItem1);
            listItems.Add(objItem2);

            Cart objCart = new Cart();
            objCart.PrintProdDesc(listItems);

            //Assigning Item2 to Item1
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Assigning Item2 to Item1");
            listItems.Clear();
            objItem1 = objItem2;
            listItems.Add(objItem1);
            listItems.Add(objItem2);
            objCart.PrintProdDesc(listItems);

            //Calc disc prod price
            isError = objItem1.calcDiscPrice(1);
            if (!isError)
                objCart.PrintItem(objItem1);

            isError = objItem2.calcDiscPrice(2);
            if (!isError)
                objCart.PrintItem(objItem2);
        }

        private void PrintProdDesc(List<Item> listItems)
        {
            int itemCounter = 0;

            System.Console.WriteLine("Product Description Printing Started");
            Console.WriteLine("===============================");

            try
            {
                foreach (Item objItems in listItems)
                {
                    itemCounter++;
                    Console.WriteLine($"Description of Item No : {itemCounter}");
                    Console.WriteLine(objItems.Desc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in printing the Product Desc : " + itemCounter.ToString() + " with error message: " + e.Message);
            }

            Console.WriteLine("===============================");
            System.Console.WriteLine("Product Description Printing Completed");
        }

        private void PrintItem(Item objItem)
        {
            System.Console.WriteLine("Product Item Printing Started");
            Console.WriteLine("===============================");

            try
            {
                Console.WriteLine($"Product ID : {objItem.Id}");
                Console.WriteLine($"Product Description : {objItem.Desc}");
                Console.WriteLine($"Product Quantity : {objItem.Qty}");
                Console.WriteLine($"Product Pricing : {objItem.Price}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in printing the Product Desc with error message: " + e.Message);
            }

            Console.WriteLine("===============================");
            System.Console.WriteLine("Product Item Printing Completed");
        }
    }
}
