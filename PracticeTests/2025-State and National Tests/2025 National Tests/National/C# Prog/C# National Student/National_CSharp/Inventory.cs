using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantSupplier_National
{
    internal class Inventory: Form1
    {
        
        

        public Inventory(Form1 form1)
        {
              
        }

        
        //Creates Produce objects that are added to general list. Counts how many are created.
        public void produceListAdditions(String sku, String nam, double cost, int kg)
        {
            
            
        }

        
        //Creates Dairy objects that are added to general list. Counts how many are created.
        public void dairyListAdditions(String sku, String nam, double cost, int kg)
        {
            
        }

        //Use this method to get the typed commands from the user and then perform actions based upon the input.
        //This could be a good place to also control how the text appears on the labels.
        public void getCommand()  //SC5
        {
            //"IMPORT", "DISTRO", "LIST", "END"

            //Tests that the user entry matches the available commands
           //"What do you want to do today: IMPORT, DISTRO, LIST, or END ? ";

            //Add a check method to see whether the enter has been clicked
            //"Which food-product do you want to procure?";
            //"Which food-product do you want to sell?";
                

        }

        //This will allow the user to type the commands to perform one of the actions
        //The actions are already programmed in advance
        //**list
        private double getInventoryTotalValue()  
        {
          
        }
        //**list
        //This is not a required method. It will get all of the print information from the food-product objects.
        public override String ToString()
        {

            String inventoryPrinter = "";
            inventoryPrinter = inventoryPrinter + "\n ===========PRODUCE==================\n\n";
            for (int a = 0; a < list_Produce.Count; a++)
            {
                inventoryPrinter = inventoryPrinter + list_Produce[a].ToString() + "\n";

            }
            inventoryPrinter = inventoryPrinter + "\n ===========DAIRY==================\n\n";
            for (int a = 0; a < list_Dairy.Count; a++)
            {
                inventoryPrinter = inventoryPrinter + list_Dairy[a].ToString() + "\n";

            }

            return inventoryPrinter;

        }

        
        //NOTE: all of the label and text box visibility code is optional since this is a very long test. 
        //This method prints list
        private void getInventoryList()  
        {
            
        }


        //Non required helper method. This is used to control the farming process 
        public void procure_InventoryDataEntry()
        {
           //"You have entered an incorrect symbol");
           //"Incorrect symbol entry. Reenter the correct symbol.";
           //"How many kg do you want to procure? (NOTE: 1000 kg is the maximum limit)";
            }
        }

        
        public void procureInventory() 
        {
            //"You have entered the wrong data type");
               

        

           //"Incorrect Data Entry. Reenter a value greater than 0 and not greater than 1000"
                
           //"Warning Logic Error: This is the final else statement"; 
            
        }

        //Non required helper method. This is used to control the selling process 
        public void distro_InventoryDataEntry()
        {
            //"You have entered an incorrect symbol");
                
            //"How many kg do you want to sell?";
            
        }

        //called from Form1, used to check data entry. Not required
        public void distro_InventoryFiles()
        {
            //"Incorrect Data Entry. Reenter a value greater than 0, and less-or-equal to amount in the foodStock"
            //"You have entered in the wrong value type"
            
        }

        //Use this method to verifiy if the user is correctly entering symbols
        private Boolean supplySKUVerification(String sym)  
        {

            
        }

        //Use this method to verifiy if the user is correctly entering numerical values
        private Boolean dataEntryVerification(int amt, String sym, Boolean procureOR_Distro)  
        {

            
        }

        //Not required method. This determines if the user is importing or distributing, and then adds or subtracts via object methods.
        private void exchange(String sym, int amt, Boolean procureOR_Distro)  
        {

            
        }

    }
}   