using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanJaunBasinMining
{
    internal class Cities
    {
        String cityName = "";
        int cityMileage = 0;
        public Cities()
        {
            cityName = "Test City";
            cityMileage = 100;
        }
        public Cities(String s, int i)
        {
            cityName = s;
            cityMileage = i;
        }
        public String getCityName() { return cityName; }
        public int getCityDistance() { return cityMileage; }     
    }
}
