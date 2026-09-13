using System;

namespace RestaurantSupplier_National
{
    
    internal class Food
    {
        private String symbol;
        private String name;
        private double price;
        private int kg;

        public Food()
        {
            symbol = "###";
            name = "Generic";
            price = 0;
            kg = 0;
        }
   
        public Food(String s, String n, double p)
        {
            symbol = s;
            name = n;
            price = p;
        }

        public virtual String ToString()
        {
            return "";
        }

        //Returns symbol
        public virtual String getSKU()
        {
            return symbol;
        }
  
        //Returns name
        public virtual String getName()
        {
            return name;
        }

        //Returns price
        public virtual double getPrice()
        {
            return price;
        }

        //Returns the total $ value of the investment product (no formula)
        public virtual double getValue()
        {
            return 0.0;
        }

        //Returns the return on investment (%) of the investment product (no formula)
        public virtual double getProfit()
        {
            return 0.0;
        }
        //Returns kg
        public virtual int getTons()
        {
            return kg;
        }

        //Adds the number of requested kg
        public virtual void procureKG(int s)
        {
            kg += s;
        }

        //Sells the number of requested kg
        public virtual void distroKG(int s)
        {
            kg -= s;
        }

        public virtual double DaysSalesOfInventory()
        {
            return (kg / costOfGoodsSold()) * 365; // Assuming annual sales period
        }

        public virtual double costOfGoodsSold()
        {
            double tenPercent = kg * 0.1;
            Random rnd = new Random();
            double cost = rnd.NextDouble() * (tenPercent - 1) + 1;

            return cost;
        }
    }
}