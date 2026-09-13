using System;

namespace SanGabrielChasmaMining
{
    //This entire parent class is complete. You will need to copy the methods and variables to be included in the children classes 
    //which is the precious metals and base metals.
    internal class MineralAssets
    {
        private String symbol;
        private String name;
        private double price;
        private int tons;

        public MineralAssets()
        {
            symbol = "###";
            name = "Generic";
            price = 0;
            tons = 0;
        }
   
        public MineralAssets(String s, String n, double p)
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
        public virtual String getSymbol()
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
        public virtual double getROI()
        {
            return 0.0;
        }
        //Returns tons
        public virtual int getTons()
        {
            return tons;
        }

        //Adds the number of requested tons
        public virtual void mineTons(int s)
        {
            tons += s;
        }

        //Sells the number of requested tons
        public virtual void sellTons(int s)
        {
            tons -= s;
        }
    }
}