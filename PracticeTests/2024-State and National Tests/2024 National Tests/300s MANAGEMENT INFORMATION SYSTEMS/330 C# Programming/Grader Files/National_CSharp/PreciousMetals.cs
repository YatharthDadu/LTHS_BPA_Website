using System;
using System.Globalization;
namespace SanGabrielChasmaMining
{
    //STUDENT_POINT
    internal class PreciousMetals: MineralAssets
    {
        private String symbol;
        private String name;
        private double price;
        private int tons;
        private String type = "PreciousMetal";

        public PreciousMetals(): base()
        {
           
        }
        public PreciousMetals(String sym, String nam, double pri, int tons)
        {
            symbol = sym;
            name = nam;
            price = pri;
            this.tons = tons;

        }

        //STUDENT_POINT
        //SC11
        public override double getValue()  
        {
            return price * tons;
        }
        //STUDENT_POINT
        //SC12
        public override double getROI() 
        {
            return ((getValue() - 7000) / 7000);
        }
        //STUDENT_POINT
        public override String ToString()
        {
            return getSymbol() + "::  " + " {Metal Type (P or B): "
                  + type + "}  " + " {Metal Name: " + getName() + "}  " + " {Price: " +
                   getPrice().ToString("C", CultureInfo.CurrentCulture) + "}  " + " {Total Tons: " + tons
                  + "}  " + " {Total Value: " + getValue().ToString("C", CultureInfo.CurrentCulture) + "}  {ROI: " + getROI().ToString("P1", CultureInfo.InvariantCulture) + "}";
        }


        public override void sellTons(int s)
        {

            tons -= s;

        }

        public override int getTons()
        {
            return tons;
        }

        public override String getSymbol()
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
        public override void mineTons(int s)
        {

            tons += s;

        }


    }
}