using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SanGabrielChasmaMining
{
    internal class Inventory: Form1
    {
        
        public List<MineralAssets> list = new List<MineralAssets>();
        private int preciousMetalsCount = 0;
        private int baseMetalsCount = 0;
        private Form1 mainform;
        String answerSymbol;
        int answerCount;

        public Inventory(Form1 form1)
        {
            mainform = form1;   
        }

        
        //Creates PreciousMetal objects that are added to general list. Counts how many are created.
        public void addPreciousMetals(String sym, String nam, double pri, int tons)
        {
            list.Add(new PreciousMetals(sym, nam, pri, tons));
            preciousMetalsCount++;
        }

        
        //Creates BaseMetal objects that are added to general list. Counts how many are created.
        public void addBaseMetals(String sym, String nam, double pri, int tons)
        {
            list.Add(new BaseMetals(sym, nam, pri, tons));
            baseMetalsCount++;
        }

        //Use this method to get the typed commands from the user and then perform actions based upon the input.
        //This could be a good place to also control how the text appears on the labels.
        public void getCommand()  //SC5
        {
            String commandAnswer;
            mainform.lblTotalCounts.Visible = false;
            mainform.lblEstimatedValue.Visible = false;
            mainform.lblRetypeCommand.Visible = false;

            String[] commands = { "MINE", "SELL", "LIST", "END" };

            //Tests that the user entry matches the available commands
            mainform.lblGreeting.Visible = true;
            mainform.txtCommand.Visible = true;
            mainform.txtCommand.Focus();
            mainform.lblGreeting.Text = "What do you want to do today: MINE, SELL, LIST, or END ? ";

            //Add a check method to see whether the enter has been clicked
            commandAnswer = mainform.txtCommand.Text;
            commandAnswer = commandAnswer.ToUpper();

            if (commandAnswer.CompareTo("MINE") == 0) //SC5
            {
                mainform.txtMineralCode.Visible = true;
                mainform.lblMineralCode.Visible = true;
                mainform.lblMineralCode.Text = "Which metal do you want to mine?";
                mainform.txtMineralCode.Focus();
                              
            }
            else if (commandAnswer.CompareTo("SELL") == 0) //SC5
            {
                mainform.txtMineralCode.Visible = true;
                mainform.lblMineralCode.Visible = true;
                mainform.lblMineralCode.Text = "Which metal do you want to sell?";
                mainform.txtMineralCode.Focus();
            }
            else if (commandAnswer.CompareTo("LIST") == 0) //SC5
            {
                getInventoryList();
            }
            else if (commandAnswer.CompareTo("END") == 0)  //SC5
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
        
        private double getInventoryTotalValue()  //SC6
        {
            double tempValue = 0;
            foreach (MineralAssets s in list)
            {
                tempValue += s.getValue();

            }
            return tempValue;
        }

        //This is not a required method. It will get all of the print information from the metal objects.
        public String ToString()
        {

            String inventoryPrinter = "";
            for (int a = 0; a < list.Count; a++)
                inventoryPrinter = inventoryPrinter + list[a].ToString() + "\n";

            return inventoryPrinter;

        }

        
        //NOTE: all of the label and text box visibility code is optional since this is a very long test. 
        //This method prints list
        private void getInventoryList()  //SC7
        {
            mainform.lblTotalCounts.Visible = true;
            mainform.lblList.Visible = true;
            mainform.lblEstimatedValue.Visible = true;
            mainform.lblTotalCounts.Text = "There are " + preciousMetalsCount + " veins of precious metals and " + baseMetalsCount + " base metal ore deposits.";
            
            mainform.lblList.Text = ToString(); //gets all of the metal information; NOTE: this label is below the lblEstimatedValue
            mainform.lblEstimatedValue.Text = "This is the estimated value of the San Gabriel Chasma: " + getInventoryTotalValue().ToString("C", CultureInfo.CurrentCulture);

            mainform.lblMineralCode.Visible = false;
            mainform.lblTonQA.Visible = false;
            mainform.txtMineralCode.Visible = false;
            mainform.txtMineralCode.Text = "";
            mainform.txtTonQA.Text = "";
            mainform.txtTonQA.Visible = false;


            mainform.lblRetypeCommand.Visible = true;
            mainform.lblRetypeCommand.Text = "Please enter in your next command.";
            mainform.txtCommand.Text = "";
        }


        //Non required helper method. This is used to control the mining process 
        public void readyToMineMineralCode()
        {
            Boolean verify;
            answerSymbol = mainform.txtMineralCode.Text;
            answerSymbol = answerSymbol.ToUpper();
            verify = symbolEntryVerification(answerSymbol);
            if (verify==false)
            {
                MessageBox.Show("You have entered an incorrect symbol");
                //mainform.lblMineralCode.Text = "Incorrect symbol entry. Reenter the correct symbol.";
                mainform.txtMineralCode.Text = "";
                mainform.txtMineralCode.Focus();
            }
            else
            {
                mainform.lblTonQA.Visible = true;
                mainform.txtTonQA.Visible = true;
                mainform.txtTonQA.Focus();
                mainform.lblTonQA.Text = "How many tons do you want to mine? (NOTE: 1000 tons is the maximum limit)";
            }
        }

        //called from Form1, used to check data entry. Not required
        public void readyToMineTonQA() 
        {
            String answer;
            Boolean verify = false;
            mainform.txtTonQA.Focus();
            try   //SC10
            {
                answer = mainform.txtTonQA.Text;
                answerCount = Convert.ToInt32(answer);
            }
            catch(FormatException)
            {
                MessageBox.Show("You have entered the wrong data type");
                mainform.txtTonQA.Clear();
                mainform.txtTonQA.Focus();
                return; //escape from the method

            }

            verify = dataEntryVerification(answerCount, answerSymbol, true); // Check if the variables are reaching this point

            if (!verify)
            {
                MessageBox.Show("Incorrect Data Entry. Reenter a value greater than 0 and not greater than 1000");
                
                mainform.txtTonQA.Clear();
                mainform.txtTonQA.Focus();
            }
            else if (verify==true)
            {
                transaction(answerSymbol, answerCount, true);
            }
            else
            {
                mainform.lblTonQA.Text = "Warning Logic Error: This is the final else statement"; //Code should not reach this point
            }
        }

        //Non required helper method. This is used to control the selling process 
        public void readyToSellMineralCode()
        {
            Boolean verify;
            answerSymbol = mainform.txtMineralCode.Text;
            answerSymbol = answerSymbol.ToUpper();
            verify = symbolEntryVerification(answerSymbol);
            if (verify == false)
            {
                MessageBox.Show("You have entered an incorrect symbol");
                
                mainform.txtMineralCode.Text = "";
                mainform.txtMineralCode.Focus();
            }
            else
            {
                mainform.lblTonQA.Visible = true;
                mainform.txtTonQA.Visible = true;
                mainform.txtTonQA.Focus();
                mainform.lblTonQA.Text = "How many tons do you want to sell?";
            }
        }

        //called from Form1, used to check data entry. Not required
        public void readyToSellTonQA()
        {
            String answer;
            Boolean verify = false;
            mainform.txtTonQA.Focus();
            try   //SC10
            {
                answer = mainform.txtTonQA.Text;
                answerCount = Convert.ToInt32(answer);
            }
            catch (FormatException)
            {
                MessageBox.Show("You have entered the wrong data type");
                mainform.txtTonQA.Clear();
                mainform.txtTonQA.Focus();
                return; //escape from the method and forces user to have to enter in the correct tonnage values
            }

            mainform.label1.Text = answerCount.ToString();
            verify = dataEntryVerification(answerCount, answerSymbol, false); // Check if the variables are reaching this point
            if (!verify)
            {
                MessageBox.Show("Incorrect Data Entry. Reenter a value greater than 0, and less-or-equal to amount in the inventory");
                mainform.txtTonQA.Clear();
                mainform.txtTonQA.Focus();
            }
            else if (verify == true)
            {
                transaction(answerSymbol, answerCount, false);
            }
            else
            {
                mainform.lblTonQA.Text = "You have entered in the wrong value type";
            }
        }

        //Use this method to verifiy if the user is correctly entering symbols
        private Boolean symbolEntryVerification(String sym)  //SC8
        {

            for (int i = 0; i < list.Count; i++)
            {
                if ((sym.Equals(list[i].getSymbol())))
                    return true;
            }
            return false;
        }

        //Use this method to verifiy if the user is correctly entering numerical values
        private Boolean dataEntryVerification(int amt, String sym, Boolean mineOrSell)  //SC9
        {

            int temp = 0;
            if (mineOrSell) //true mines
            {
                if (amt <= 0 || amt > 1000)
                    return false;
                if (mineOrSell)
                    return true;
            }
            


            for (int i = 0; i < list.Count; i++) //generating a list of 
            {
                if ((sym.CompareTo(list[i].getSymbol()) == 0))
                {
                    temp = list[i].getTons();
                    if (amt > temp)
                        return false;
                    else
                        return true;
                }

            }
            return false;
        }

        //Not reuired method. This determines if the mining or selling, and then adds or subtracts via object methods.
        private void transaction(String sym, int amt, Boolean mineOrSell) //true mines...false sells
        {

            for (int i = 0; i < list.Count; i++) //generating a list of 
            {
                if (sym.CompareTo(list[i].getSymbol()) == 0)
                {
                    if (mineOrSell) list[i].mineTons(amt);
                    else { list[i].sellTons(amt); }
                }
            }
            getInventoryList();
        }

    }
}   