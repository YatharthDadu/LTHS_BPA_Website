using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace RestaurantSupplier_National
{
    
    internal class Dairy: Food
    {
        private String symbol;
        private String name;
        private double price;
        private int kg;
        private String type = "Dairy";
        private double cost;

        public Dairy() : base()  
        {
            
        }
  
        public Dairy(String sym, String nam, double pri, int kg)
        {
            symbol = sym;
            name = nam;
            price = pri;
            this.kg = kg;
        }

        
        public override double getValue() //SC13
        {
            return price * kg;
        }

        
        public override double getProfit() 
        {
            return ((getValue()-5000)/5000);
        }
        //SC14
        public override double DaysSalesOfInventory()
        {
            
            return (int)((kg / costOfGoodsSold()) * 365); // Assuming annual sales period
        }
        //SC15
        public override double costOfGoodsSold()
        {
            double tenPercent = kg * 0.1;
            Random rnd = new Random();
            cost = (rnd.NextDouble() * (tenPercent - 1) + 1) * 20;

            return cost;
        }
         //SC16
        public override String ToString()
        {
            return $"Food Details:\n" +
           $"- Symbol: {getSKU()}\n" +
           $"- Food Type (P or D): {type}\n" +
           $"- Food Name: {getName()}\n" +
           $"- Price: {getPrice().ToString("C", CultureInfo.CurrentCulture)}\n" +
           $"- Total Tons: {kg}\n" +
           $"- Total Value: {getValue().ToString("C", CultureInfo.CurrentCulture)}\n" +
           $"- Days of Sales Inventory: {DaysSalesOfInventory().ToString()}" + "\n" +
           $"- COST of Goods Sold: {costOfGoodsSold().ToString("C", CultureInfo.CurrentCulture)}" + "\n";

        }

        //Returns number kg
        public override int getTons()
        {
            return kg;
        }

        //Returns symbol
        public override String getSKU()
        {
            return symbol;
        }

        //Returns name
        public override String getName()
        {
            return name;
        }

        //Returns price
        public override double getPrice()
        {
            return price;
        }

        //Adds the number of requested kg
        public override void procureKG(int s)
        {
            kg += s;
        }

        //Sells the number of requested kg
        public override void distroKG(int s)
        {
            kg -= s;
        }


    }
}