using System;
using System.Globalization;
namespace SanGabrielChasmaMining
{
    //STUDENT_POINT
    internal class BaseMetals: MineralAssets
    {
        private String symbol;
        private String name;
        private double price;
        private int tons;
        private String type = "BaseMetal";

        public BaseMetals() : base()  
        {
            
        }
  
        public BaseMetals(String sym, String nam, double pri, int tons)
        {
            symbol = sym;
            name = nam;
            price = pri;
            this.tons = tons;
        }

        //STUDENT POINT
        public override double getValue() //SC11
        {
            return price * tons;
        }

        //STUDENT POINT
        public override double getROI() //SC12
        {
            return ((getValue()-5000)/5000);
        }

        //STUDENT_POINT
        public override String ToString()
        {
            return getSymbol() + "::  " + " {Metal Type (P or B): "
                  + type + "}  " + " {Metal Name: " + getName() + "}  " + " {Price: " +
                   getPrice().ToString("C", CultureInfo.CurrentCulture) + "}  " + " {Total Tons: " + tons
                  + "}  " + " {Total Value: " + getValue().ToString("C", CultureInfo.CurrentCulture) +"}  {ROI: " + getROI().ToString("P1", CultureInfo.InvariantCulture)+"}";
        }

        //Returns number tons
        public override int getTons()
        {
            return tons;
        }

        //Returns symbol
        public override String getSymbol()
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

        //Adds the number of requested tons
        public override void mineTons(int s)
        {
            tons += s;
        }

        //Sells the number of requested tons
        public override void sellTons(int s)
        {
            tons -= s;
        }


    }
}