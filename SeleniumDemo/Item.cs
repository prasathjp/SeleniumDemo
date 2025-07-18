using System;

namespace AmazonDemo
{
    public class Item
    {
        private int _id;
        private string _desc;
        private int _qty;
        private double _price;

        //ID Property
        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
            set 
            { 
                _id = value; 
            } 
        }

        //Desc Property
        public string Desc 
        { 
            get 
            { 
                return _desc; 
            } 
            set 
            { 
                _desc = value; 
            } 
        }

        //Qty Property
        public int Qty
        {
            get
            {
                return _qty;
            }
            set
            {
                _qty = value;
            }
        }

        //Price Property
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public Item(string prodDesc)
        {
            Desc = prodDesc;
        }

        //Calculate discounted price based on the item qty
        //If qty = 2-- > print the final price by providing 10% discount of price
        //If qty = 3 to 5--> print the final price by providing 15% discount of price
        //If qty >5 --> print the final price by providing 25% discount of price
        public bool calcDiscPrice(int prodID)
        {
            bool isError = false; ;
            this.Price = 0;
            this.Id = prodID;
            string inputQty;
            int itemQty;
            int prodPrice = 100;
            double discPrice = 0;

            try
            {
                Console.WriteLine("Enter Qty : ");
                inputQty = Console.ReadLine();
                itemQty = Convert.ToInt32(inputQty);
                this.Qty = itemQty;

                if (inputQty != null)
                {
                    if (itemQty == 2)
                        discPrice = Convert.ToDouble((prodPrice - (prodPrice * 10 / 100)) * itemQty);
                    else if (itemQty >= 3 && itemQty <= 5)
                        discPrice = Convert.ToDouble((prodPrice - (prodPrice * 15 / 100)) * itemQty);
                    else
                    {
                        if (itemQty > 5)
                            discPrice = Convert.ToDouble((prodPrice - (prodPrice * 25 / 100)) * itemQty);
                    }
                }
                this.Price = discPrice;
            }
            catch (Exception ex)
            {
                isError = true;
                Console.WriteLine("Error Message : " + ex.Message);
            }

            return isError;
        }
    }
}
