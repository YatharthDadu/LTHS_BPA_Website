using System;
using System.Globalization;
namespace RestaurantSupplier_National
{
    
    internal class Produce: Food
    {
        private String symbol;
        private String name;
        private double price;
        private int kg;
        private String type = "Produce";
        private double cost;

        public Produce(): base()
        {
           
        }
        public Produce(String sym, String nam, double pri, int kg)
        {
            symbol = sym;
            name = nam;
            price = pri;
            this.kg = kg;

        }

        
        //SC13
        public override double getValue()  
        {
            return price * kg;
        }
        
        public override double getProfit() 
        {
            return ((getValue() - 7000) / 7000);
        }
        //SC14
        public override double DaysSalesOfInventory()
        {
            //costOfGoodsSold();
            return (int)((kg / costOfGoodsSold()) * 365); 
        }
        //SC15
        public override double costOfGoodsSold()
        {
            double tenPercent = kg * 0.1;
            Random rnd = new Random();
            cost = (rnd.NextDouble() * (tenPercent - 1) + 1)*20;

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
            $"- Total kg.: {kg}\n" +
            $"- Total Value: {getValue().ToString("C", CultureInfo.CurrentCulture)}\n" +
            $"- Days of Sales Inventory: {DaysSalesOfInventory().ToString()}" + "\n"+
            $"- COST of Goods Sold: {costOfGoodsSold().ToString("C", CultureInfo.CurrentCulture)}" + "\n";

        }


        public override void distroKG(int s)
        {

            kg -= s;

        }

        public override int getTons()
        {
            return kg;
        }

        public override String getSKU()
        {
            return symbol;
        }
        public override String getName()
        {
            return name;
        }
        public override double getPrice()
        {
            return price;
        }
        public override void procureKG(int s)
        {

            kg += s;

        }


    }
}