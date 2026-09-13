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

        //Below you will find some of the text that will be printed to the labels. You will need to figure out where to place them. :-)  
        //Command text: "MINE", "SELL", "LIST", "END"

        //NOTE: STEP 1 greeting can also be set in this section.
        //STEP 1 greeting message: "What do you want to do today: MINE, SELL, LIST, or END ? "

        //STEP 2 MINE message: "Which metal do you want to mine?"

        //STEP 2 SELL message: "Which metal do you want to sell?"
        //STEP 3 MINE message: "How many tons do you want to mine? (NOTE: 1000 tons is the maximum limit)"
        //STEP 3 SELL message "How many tons do you want to sell?";
        //STEP 4 line 1: "There are " + _______+ " veins of precious metals and " + _______+ " base metal ore deposits."
        //STEP 4 line 2:"This is the estimated value of the San Gabriel Chasma: " + ________

        private Form1 mainform;  //This variable can be used to access the form objects
        

        public Inventory(Form1 form1) //The constructor for this class. 
        {
            mainform = form1;   
        }

        
        //Creates PreciousMetal objects that are added to general list.
        //It could also be a good place to count how many are created.
        public void addPreciousMetals(String sym, String nam, double pri, int tons)
        {
            
        }


        //Creates BaseMetal objects that are added to general list. 
        //It could also be a good place to count how many are created.
        public void addBaseMetals(String sym, String nam, double pri, int tons)
        {
           
        }

        //Use this method to get the typed commands from the user and then perform actions based upon the input.
        //This could be a good place to also control how the text appears on the labels.
        //You can add arguments to this method if necessary.
        public void getCommand()  //SC5
        {


        }

        //Use this method to calculate the estimated value for the second line of the list print out. See pg. 7 of the test
        private double getInventoryTotalValue()  //
        {
            
        }

        //Use this to 
        private void getInventoryList()  
        {

            
        }

        //Use this method to verifiy if the user is correctly entering symbols
        private Boolean symbolEntryVerification( )  
        {

            
        }

        //Use this method to verifiy if the user is correctly entering numerical values 
        private Boolean dataEntryVerification( )  
        {

            
        }

        
        

    }
}   