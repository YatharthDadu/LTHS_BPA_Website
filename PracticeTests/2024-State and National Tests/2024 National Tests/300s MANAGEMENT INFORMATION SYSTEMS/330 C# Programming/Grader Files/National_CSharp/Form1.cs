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

        private void Form1_Load(object sender, EventArgs e)
        {
            
            inventory = new Inventory(this);
            lblGreeting.Visible = true;
            txtCommand.Visible = true;
            lblGreeting.Text = "What do you want to do today: MINE, SELL, LIST, or END ? ";
            txtCommand.Focus();
            readFile();
            
        }
        //STUDENT_POINT
        //SC1
        private void readFile()
        {
            String temp = "";
            int counter = 0;
            String temp2 = "";
            String temp3 = "";
     
            foreach (String line in System.IO.File.ReadLines(@"InventoryText.txt"))
            {
                temp += line;
            }
            foreach(Char c in temp)
            {
                temp2 += c;
                if (temp2.ToUpper().Equals("STOP")==false)  //SC1
                {
                    if(temp2.Contains(",")==true)  //SC1
                    {
                        if(counter % 5 ==0)
                        {
                            temp3 = temp2.Remove(temp2.Length-1, 1); // Check to see if it removes the comma from the end of the string
                            productType = temp3;
                            temp2 = "";
                            temp3 = "";
                            counter++;
                        }
                        else if (counter % 5 == 1)
                        {
                            temp3 = temp2.Remove(temp2.Length - 1, 1);
                            MetalSymbol = temp3;
                            temp2 = "";
                            temp3 = "";
                            counter++;
                        }
                        else if (counter % 5 == 2)
                        {
                            temp3 = temp2.Remove(temp2.Length - 1, 1);
                            MetalName = temp3;
                            temp2 = "";
                            temp3 = "";
                            counter++;
                        }
                        else if (counter % 5 == 3)
                        {
                            temp3 = temp2.Remove(temp2.Length - 1, 1);
                            Double.TryParse(temp3, out MetalPrice);
                            temp2 = "";
                            temp3 = "";
                            counter++;
                        }
                        else if (counter % 5 == 4)
                        {
                            temp3 = temp2.Remove(temp2.Length - 1, 1);
                            int.TryParse(temp3, out MetalVolume);
                            temp2 = "";
                            temp3 = "";
                            counter++;
                            if (productType.ToUpper().Equals("P"))
                            {
                                inventory.addPreciousMetals(MetalSymbol, MetalName, MetalPrice, MetalVolume); //SC1
                            }
                            else if (productType.ToUpper().Equals("B"))
                            {
                                inventory.addBaseMetals(MetalSymbol, MetalName, MetalPrice, MetalVolume); //SC1
                            }
                        }
                    }
                }
            }        
        }

        //Gathers information from the text box when enter key is pressed.
        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)  //SC2
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                inventory.getCommand();
                e.Handled = true; //Stops dinging Windows sound

            }
            
        }

        //Gathers information from the text box when enter key is pressed.
        public void txtSymbol_KeyPress(object sender, KeyPressEventArgs e)  //SC3
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                if(txtCommand.Text.ToUpper().Contains("SELL"))
                {
 
                    inventory.readyToSellMineralCode();
                    e.Handled = true;
                }
                else if(txtCommand.Text.ToUpper().Contains("MINE"))
                {

                    inventory.readyToMineMineralCode();
                    e.Handled = true;
                }
            }
            
        }

        //Gathers information from the text box when enter key is pressed.
        private void txtTonnage_KeyPress(object sender, KeyPressEventArgs e)  //SC4
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                if (txtCommand.Text.ToUpper().Contains("SELL"))
                {
                    inventory.readyToSellTonQA();
                    e.Handled = true;
                }
                else if (txtCommand.Text.ToUpper().Contains("MINE"))
                {
                    inventory.readyToMineTonQA();
                    e.Handled = true;
                }
            }
            
        }

       
    }
}
