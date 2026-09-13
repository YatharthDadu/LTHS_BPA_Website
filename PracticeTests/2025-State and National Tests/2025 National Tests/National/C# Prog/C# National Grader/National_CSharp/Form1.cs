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

            panel1.AutoScroll = true;  //SC1A
            panel1.BackColor = SystemColors.Window; //SC1D
            lblEstimatedValue.Font = new Font("Calibri", 12, FontStyle.Bold | FontStyle.Italic); //SC1B
            lblTotalCounts.Font = new Font("Calibri", 12, FontStyle.Bold | FontStyle.Italic);//SC1B
            lblList.Font = new Font("Calibri", 10, FontStyle.Bold); //SC1B
            panel1.BackgroundImage = null; //SC1C



            foodStock = new Inventory(this);
            lblGreeting.Visible = true;
            txtCommand.Visible = true;
            lblGreeting.Text = "What do you want to do today: IMPORT, DISTRO, LIST, or END ? ";
            txtCommand.Focus();
            readFile();
            
        }
        
        
        private void readFile()
        {
            
            string resourceFolderPath = Path.Combine(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "Resources");
            
            string[] files = Directory.GetFiles(resourceFolderPath, "*Text*.txt"); //SC2
            MessageBox.Show("FILEPATHWAY HELP MESSAGE \nYour file location and count: " + files[0],  "Total readable files:"+files.Length); //SC3
            foreach (string file in files)
            {
                String temp = "";
                int counter = 0;
                String temp2 = "";
                String temp3 = "";

                foreach (String line in System.IO.File.ReadLines(file))
                {
                    temp += line;
                }
                foreach (Char c in temp)
                {
                    temp2 += c;
                    if (temp2.ToUpper().Equals("STOP") == false)  //SC4B
                    {
                        if (temp2.Contains(",") == true)  //SC4D
                        {
                            if (counter % 5 == 0)
                            {
                                temp3 = temp2.Remove(temp2.Length - 1, 1); // Check to see if it removes the comma from the end of the string
                                foodCategory = temp3;
                                temp2 = "";
                                temp3 = "";
                                counter++;
                            }
                            else if (counter % 5 == 1)
                            {
                                temp3 = temp2.Remove(temp2.Length - 1, 1);
                                FoodSymbol = temp3;
                                temp2 = "";
                                temp3 = "";
                                counter++;
                            }
                            else if (counter % 5 == 2)
                            {
                                temp3 = temp2.Remove(temp2.Length - 1, 1);
                                FoodName = temp3;
                                temp2 = "";
                                temp3 = "";
                                counter++;
                            }
                            else if (counter % 5 == 3)
                            {
                                temp3 = temp2.Remove(temp2.Length - 1, 1);
                                Double.TryParse(temp3, out FoodCost);
                                temp2 = "";
                                temp3 = "";
                                counter++;
                            }
                            else if (counter % 5 == 4)
                            {
                                temp3 = temp2.Remove(temp2.Length - 1, 1);
                                int.TryParse(temp3, out FoodVolume);
                                temp2 = "";
                                temp3 = "";
                                counter++;
                                if (foodCategory.ToUpper().Equals("P")) //SC1A
                                {
                                    foodStock.produceListAdditions(FoodSymbol, FoodName, FoodCost, FoodVolume); //SC4A
                                }
                                else if (foodCategory.ToUpper().Equals("D")) //SC1A
                                {
                                    foodStock.dairyListAdditions(FoodSymbol, FoodName, FoodCost, FoodVolume); //SC4A
                                }
                            }
                        }
                    }
                }
            }
        }   

        //Gathers information from the text box when enter key is pressed.
        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)  //SC5
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                foodStock.getCommand();
                e.Handled = true; //Stops dinging Windows sound

            }
            
        }

        //Gathers information from the text box when enter key is pressed.
        public void txtSymbol_KeyPress(object sender, KeyPressEventArgs e)  //SC6
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                if(txtCommand.Text.ToUpper().Contains("DISTRO"))
                {
 
                    foodStock.distro_InventoryDataEntry();
                    e.Handled = true;
                }
                else if(txtCommand.Text.ToUpper().Contains("IMPORT"))
                {

                    foodStock.procure_InventoryDataEntry();
                    e.Handled = true;
                }
            }
            
        }

        //Gathers information from the text box when enter key is pressed.
        private void txtTonnage_KeyPress(object sender, KeyPressEventArgs e)  //SC7
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                if (txtCommand.Text.ToUpper().Contains("DISTRO"))
                {
                    foodStock.distro_InventoryFiles();
                    e.Handled = true;
                }
                else if (txtCommand.Text.ToUpper().Contains("IMPORT"))
                {
                    foodStock.procureInventory();
                    e.Handled = true;
                }
            }
            
        }

        private void txtSymbol_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
