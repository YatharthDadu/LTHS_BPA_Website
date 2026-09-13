using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanJaunBasinMining
{
    internal class Resources
    {
        
        private List<Minerals> minerals;  
        private int size;
        private double mileageFee = 0.89;
        private double tax = 1.2;

        public Resources()
        {
            minerals = new List<Minerals>();
            size = 0;

        }

        private String[] cities = { "Chicago", "Toronto", "Miami", "Seattle", "Mexico City" };
        private List<Cities> cityData = new List<Cities>(); 
        Random rnd = new Random();

        //STUDENT POINT //SC2

        private void setCities()
        {
            foreach (string c in cities)
            {
                cityData.Add(new Cities(c, rnd.Next(500, 1000)));
            }
        }
        //Creates the stock object to be stores in the list. Info passed from 
        //StockDriver
        //STUDENT POINT  //SC3
        public void mineralProcurement(String sym, String nam, double pri, int sha)
        {
            Minerals temp = new Minerals(sym, nam, pri, sha);
            minerals.Add(temp);
            size++;

        }


        //STUDENT POINT  //SC4
        private double getTotalOperationalCost()
        {
            double tempValue = 0;
            foreach (Minerals s in minerals)
            {
                tempValue += s.getProductionCost();
            }
            return tempValue*tax;
        }
        //STUDENT POINT  //SC5
        private String getCostTransport()
        {
            setCities();
           
            String cityTransport = "";

            foreach (Cities c in cityData)
            {
                Console.WriteLine("HERE");
         
                cityTransport = cityTransport + c.getCityName() + ": $" + (c.getCityDistance() * mileageFee * getMineralTonnage()) + Environment.NewLine; 
            }
                return cityTransport;
        }


        //STUDENT POINT  //SC6
        private String getMineralInventory()
        {
            String mineralInventory = "";
            for (int a = 0; a < size; a++)
            {
                mineralInventory = mineralInventory + minerals[a].printMineral() + Environment.NewLine;
            }
            return mineralInventory;
        }

        //STUDENT POINT  //SC7
        private int getMineralTonnage()
        {
            int mineralTons = 0;
            for (int a = 0; a < size; a++)
            {
                mineralTons = mineralTons + minerals[a].getTonnage();
            }
            return mineralTons;
        }
        //STUDENT POINT  //SC8
        public override String ToString()
        {
            
            return "This is your current accessable mineral resources:" + Environment.NewLine + Environment.NewLine + getMineralInventory() + Environment.NewLine + Environment.NewLine + 
                "Total Operating Cost to mine all minerals with state tax: $" + getTotalOperationalCost() + Environment.NewLine + Environment.NewLine + "Cost to Ship Per City" 
                + Environment.NewLine + getCostTransport();
        }
    }
}
