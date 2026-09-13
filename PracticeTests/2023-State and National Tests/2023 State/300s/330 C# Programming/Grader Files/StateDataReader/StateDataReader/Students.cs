using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This was not used in the final solution. 

namespace StateDataReader
{
    internal class Students
    {
        string prefix;
        string firstN;
        string lastN;

        Students() 
        {
            prefix = null;
            firstN = null;
            lastN = null;
        }
        Students(string fn, string ln)
        {
            prefix = null;
            firstN=fn;
            lastN=ln;   
        }
        Students(string pf, string fn, string ln)
        {
            prefix=pf;
            firstN =fn;   
            lastN=fn;
        }

        public string ToString() 
        {
            
            return lastN + ", " + firstN + " " +prefix;
            
        }
    }
}
