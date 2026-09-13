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

namespace RestaurantSupplier_National
{
    public partial class Form1 : Form
    {

        String foodCategory;
        String FoodSymbol;
        String FoodName;
        double FoodCost;
        int FoodVolume;
        Inventory foodStock;

      

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //"What do you want to do today: IMPORT, DISTRO, LIST, or END ? ";
            
            
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

        private void txtSymbol_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
