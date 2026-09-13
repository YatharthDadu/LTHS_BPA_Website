using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanGabrielChasmaMining
{
    public partial class Form1 : Form
    {

        String productType;
        String MetalSymbol;
        String MetalName;
        double MetalPrice;
        int MetalVolume;
        Inventory inventory;

      

        public Form1()
        {
            InitializeComponent();
        }
        //Anything in this method will immediately start with the program
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            //STEP 1 greeting message: "What do you want to do today: MINE, SELL, LIST, or END ? "
            
            
        }
        
        private void readFile()
        {
                    
        }

        //Gathers information from the text box when enter key is pressed.
        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)  
        {
           
            
        }

        //Gathers information from the text box when enter key is pressed.
        public void txtSymbol_KeyPress(object sender, KeyPressEventArgs e)  
        {
            
            
        }

        //Gathers information from the text box when enter key is pressed.
        private void txtTonnage_KeyPress(object sender, KeyPressEventArgs e)  
        {
            
            
        }

       
    }
}
