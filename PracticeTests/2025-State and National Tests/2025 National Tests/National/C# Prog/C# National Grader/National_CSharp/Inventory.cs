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
        
        public List<Food> list_Dairy = new List<Food>();
        public List<Food> list_Produce = new List<Food>();
        private int dairyCounter = 0;
        private int produceCounter = 0;
        private Form1 mainform;
        String answerSymbol;
        int answerCount;

        public Inventory(Form1 form1)
        {
            mainform = form1;   
        }

        
        //Creates Produce objects that are added to general list. Counts how many are created.
        public void produceListAdditions(String sku, String nam, double cost, int kg)
        {
            list_Produce.Add(new Produce(sku, nam, cost, kg));
            produceCounter++;
            
        }

        
        //Creates Dairy objects that are added to general list. Counts how many are created.
        public void dairyListAdditions(String sku, String nam, double cost, int kg)
        {
            list_Dairy.Add(new Dairy(sku, nam, cost, kg));
            dairyCounter++;
        }

        //Use this method to get the typed commands from the user and then perform actions based upon the input.
        //This could be a good place to also control how the text appears on the labels.
        public void getCommand()  //SC5
        {
            String commandAnswer;
            mainform.lblTotalCounts.Visible = false;
            mainform.lblEstimatedValue.Visible = false;
            mainform.lblRetypeCommand.Visible = false;

            String[] commands = { "IMPORT", "DISTRO", "LIST", "END" };

            //Tests that the user entry matches the available commands
            mainform.lblGreeting.Visible = true;
            mainform.txtCommand.Visible = true;
            mainform.txtCommand.Focus();
            mainform.lblGreeting.Text = "What do you want to do today: IMPORT, DISTRO, LIST, or END ? ";

            //Add a check method to see whether the enter has been clicked
            commandAnswer = mainform.txtCommand.Text;
            commandAnswer = commandAnswer.ToUpper();

            if (commandAnswer.CompareTo("IMPORT") == 0) 
            {
                mainform.txtSymbol.Visible = true;
                mainform.lblFoodCode.Visible = true;
                mainform.lblFoodCode.Text = "Which food-product do you want to procure?";
                mainform.txtSymbol.Focus();
                              
            }
            else if (commandAnswer.CompareTo("DISTRO") == 0) 
            {
                mainform.txtSymbol.Visible = true;
                mainform.lblFoodCode.Visible = true;
                mainform.lblFoodCode.Text = "Which food-product do you want to sell?";
                mainform.txtSymbol.Focus();
            }
            else if (commandAnswer.CompareTo("LIST") == 0) 
            {
                getInventoryList();
            }
            else if (commandAnswer.CompareTo("END") == 0)  
            {
                MessageBox.Show("Goodbye");
                mainform.Close();
            }
            else
            {
                MessageBox.Show("Command Entry Error");
                mainform.txtCommand.Text = "";               
            }

        }

        //This will allow the user to type the commands to perform one of the actions
        //The actions are already programmed in advance
        //**list
        private double getInventoryTotalValue()  //SC8
        {
            double tempValue = 0;
            foreach (Food s in list_Dairy)
            {
                tempValue += s.getValue();

            }
            foreach (Food s in list_Produce)
            {
                tempValue += s.getValue();

            }
            return tempValue;
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
        private void getInventoryList()  //SC9
        {
            mainform.lblTotalCounts.Visible = true;
            mainform.lblList.Visible = true;
            mainform.lblEstimatedValue.Visible = true;
            mainform.lblTotalCounts.Text = "There are " + produceCounter + " produce food-products and " + dairyCounter + " dairy food-products.";
            
            mainform.lblList.Text = ToString(); 
            mainform.lblEstimatedValue.Text = "This is the estimated value of the invetory for the restaraunt supplier: " + getInventoryTotalValue().ToString("C", CultureInfo.CurrentCulture); //SC9

            mainform.lblFoodCode.Visible = false;
            mainform.lblKG_QA.Visible = false;
            mainform.txtSymbol.Visible = false;
            mainform.txtSymbol.Text = "";
            mainform.txtKG_QA.Text = "";
            mainform.txtKG_QA.Visible = false;


            mainform.lblRetypeCommand.Visible = true;
            mainform.lblRetypeCommand.Text = "Please enter in your next command.";
            mainform.txtCommand.Text = "";
        }


        //Non required helper method. This is used to control the farming process 
        public void procure_InventoryDataEntry()
        {
            MessageBox.Show("procure method runs");
            Boolean verify;
            answerSymbol = mainform.txtSymbol.Text;
            answerSymbol = answerSymbol.ToUpper();
            verify = supplySKUVerification(answerSymbol);
            if (verify==false)
            {
                MessageBox.Show("You have entered an incorrect symbol");
                mainform.lblFoodCode.Text = "Incorrect symbol entry. Reenter the correct symbol.";
                mainform.txtSymbol.Text = "";
                mainform.txtSymbol.Focus();
            }
            else
            {
                mainform.lblKG_QA.Visible = true;
                mainform.txtKG_QA.Visible = true;
                mainform.txtKG_QA.Focus();
                mainform.lblKG_QA.Text = "How many kg do you want to procure? (NOTE: 1000 kg is the maximum limit)";
            }
        }

        
        public void procureInventory() 
        {
            String answer;
            Boolean verify = false;
            mainform.txtKG_QA.Focus();
            try   //SC12
            {
                answer = mainform.txtKG_QA.Text;
                answerCount = Convert.ToInt32(answer);
            }
            catch(FormatException)
            {
                MessageBox.Show("You have entered the wrong data type");
                mainform.txtKG_QA.Clear();
                mainform.txtKG_QA.Focus();
                return; //escape from the method

            }

            verify = dataEntryVerification(answerCount, answerSymbol, true); // Check if the variables are reaching this point

            if (!verify)
            {
                MessageBox.Show("Incorrect Data Entry. Reenter a value greater than 0 and not greater than 1000");
                
                mainform.txtKG_QA.Clear();
                mainform.txtKG_QA.Focus();
            }
            else if (verify==true)
            {
                exchange(answerSymbol, answerCount, true);
            }
            else
            {
                mainform.lblKG_QA.Text = "Warning Logic Error: This is the final else statement"; //Code should not reach this point
            }
        }

        //Non required helper method. This is used to control the selling process 
        public void distro_InventoryDataEntry()
        {
            Boolean verify;
            answerSymbol = mainform.txtSymbol.Text;
            answerSymbol = answerSymbol.ToUpper();
            verify = supplySKUVerification(answerSymbol);
            if (verify == false)
            {
                MessageBox.Show("You have entered an incorrect symbol");
                
                mainform.txtSymbol.Text = "";
                mainform.txtSymbol.Focus();
            }
            else
            {
                mainform.lblKG_QA.Visible = true;
                mainform.txtKG_QA.Visible = true;
                mainform.txtKG_QA.Focus();
                mainform.lblKG_QA.Text = "How many kg do you want to sell?";
            }
        }

        //called from Form1, used to check data entry. Not required
        public void distro_InventoryFiles()
        {
            String answer;
            Boolean verify = false;
            mainform.txtKG_QA.Focus();
            try   //SC10
            {
                answer = mainform.txtKG_QA.Text;
                answerCount = Convert.ToInt32(answer);
            }
            catch (FormatException)
            {
                MessageBox.Show("You have entered the wrong data type");
                mainform.txtKG_QA.Clear();
                mainform.txtKG_QA.Focus();
                return; //escape from the method and forces user to have to enter in the correct tonnage values
            }

            mainform.label1.Text = answerCount.ToString();
            verify = dataEntryVerification(answerCount, answerSymbol, false); // Check if the variables are reaching this point
            if (!verify)
            {
                MessageBox.Show("Incorrect Data Entry. Reenter a value greater than 0, and less-or-equal to amount in the foodStock");
                mainform.txtKG_QA.Clear();
                mainform.txtKG_QA.Focus();
            }
            else if (verify == true)
            {
                exchange(answerSymbol, answerCount, false);
            }
            else
            {
                mainform.lblKG_QA.Text = "You have entered in the wrong value type";
            }
        }

        //Use this method to verifiy if the user is correctly entering symbols
        private Boolean supplySKUVerification(String sym)  //SC10
        {

            for (int i = 0; i < list_Dairy.Count; i++)
            {
                if ((sym.Equals(list_Dairy[i].getSKU())))
                    return true;
            }
            for (int i = 0; i < list_Produce.Count; i++)
            {
                if ((sym.Equals(list_Produce[i].getSKU())))
                    return true;
            }
            return false;
        }

        //Use this method to verifiy if the user is correctly entering numerical values
        private Boolean dataEntryVerification(int amt, String sym, Boolean procureOR_Distro)  //SC11
        {

            int temp = 0;
            if (procureOR_Distro) //true mines
            {
                if (amt <= 0 || amt > 1000)
                    return false;
                if (procureOR_Distro)
                    return true;
            }
            
            bool tempHold_TF = false;

            for (int i = 0; i < list_Dairy.Count; i++) //generating a list of 
            {
                if ((sym.CompareTo(list_Dairy[i].getSKU()) == 0))
                {
                    temp = list_Dairy[i].getTons();
                    if (amt > temp)
                        tempHold_TF = false;
                    else
                        tempHold_TF = true;
                }

            }
            for (int i = 0; i < list_Produce.Count; i++) //generating a list of 
            {
                if ((sym.CompareTo(list_Produce[i].getSKU()) == 0))
                {
                    temp = list_Produce[i].getTons();
                    if (amt > temp)
                        tempHold_TF = false;
                    else
                        tempHold_TF = true;
                }

            }
            return tempHold_TF;
        }

        //Not required method. This determines if the user is importing or distributing, and then adds or subtracts via object methods.
        private void exchange(String sym, int amt, Boolean procureOR_Distro) //true mines...false sells
        {

            for (int i = 0; i < list_Dairy.Count; i++) //generating a list of 
            {
                if (sym.CompareTo(list_Dairy[i].getSKU()) == 0)
                {
                    if (procureOR_Distro) list_Dairy[i].procureKG(amt);
                    else { list_Dairy[i].distroKG(amt); }
                }
            }
            for (int i = 0; i < list_Produce.Count; i++) //generating a list of 
            {
                if (sym.CompareTo(list_Produce[i].getSKU()) == 0)
                {
                    if (procureOR_Distro) list_Produce[i].procureKG(amt);
                    else { list_Produce[i].distroKG(amt); }
                }
            }
            getInventoryList();
        }

    }
}   