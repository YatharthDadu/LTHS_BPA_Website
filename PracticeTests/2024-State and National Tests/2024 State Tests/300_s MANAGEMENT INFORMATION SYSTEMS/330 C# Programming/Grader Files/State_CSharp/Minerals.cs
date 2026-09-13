using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanJaunBasinMining
{
    internal class Minerals
    {
        private String mineralSymbol;
        private String name;
        private double cost;
        private int tonnage;


        

        public Minerals(String sym, String nam, double cos, int ton)  //SC9
        {
            mineralSymbol = sym;
            name = nam;
            cost = cos;
            tonnage = ton;
        }

        
        public double getProductionCost()  //SC10
        {
            return cost * tonnage;
        }

        public String getmineralSymbol() 
        {
            return mineralSymbol;
        }

        public override String ToString()  //SC11
        {
            String temp = "[Mineral Symbol: " + mineralSymbol + "]" + Environment.NewLine + "[Mineral Name: " + name + "]." + "[Extraction Cost: " + cost +"]." + "[Estimated Tonnage: " + tonnage
               + "]." + "[Mineral Production Cost to Mine: $" + this.getProductionCost()+ "]"+  Environment.NewLine;
            return temp;
        }

        
        /*
        public void shipTonnage(int s)
        {
            tonnage -= s;
        }
        */
        public String printMineral()   //SC12
        {
            return ToString();
        }
        public int getTonnage()
        {
            return tonnage;
        }

        public void buytonnage(int s)
        {
            tonnage += s;
        }
    }
}
