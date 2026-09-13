using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace NationalBPA
{
    public partial class Form1 : Form, Controller
    {

        public bool onOff;
        public bool canMove;
        public int counter =0;
        public PictureBox pbSelect; //The PB that will be moving
        public PictureBox pbTarget; //The PB target we want to move towards
        public Label lblTarget; //Changes from False to True 
        
        ListDictionary stateDictionary = new ListDictionary();

        public Form1()
        {
            InitializeComponent();
        }
         
        
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLetters.Enabled = true; //Allows the combo box to be accessed
            onOff = true; //Used to toggle the combo box being visible and enabled
            canMove = true;
            //Original back color is transparent. (Alpha [0 to 255], RGB)
            //Students will be required to set Alpha Channel
            //SC2
            pb_Target_A.BackColor = Color.FromArgb(100, Color.Red);
            pb_Target_P.BackColor = Color.FromArgb(100, Color.HotPink);
            pb_Target_B.BackColor = Color.FromArgb(100, Color.Blue);
            //Send the targets (Keys) to backmost layer
            pb_Target_A.SendToBack(); pb_Target_B.SendToBack(); pb_Target_P.SendToBack();
            panel1.BackColor = Color.LightGreen;
            //Text boxes, lists, and buttons have to be disabled or the 
            //picture box cotrols will not work.
            txtID.Enabled = false; txtStateName.Enabled = false; 
            btnCreate.Enabled = false;  btnDelete.Enabled = false; btnUpdate.Enabled = false;
            lstStates.Enabled = false;  
            
        }

        //Interface implementation
        //NOTE picturebox has its XY coordinate center in the top left. 
        //SC1 1 of 5 
        public void MoveUp(PictureBox pb, bool canMove)
        {
            Point pos = pb.Location;
            if (pos.Y > 0 && canMove)
            {
                pos.Y -= 20;
                
            }
            pb.Location = pos;
            TargetCheck(); //Checking to see if we are in the target
        }

        //SC1 2 of 5 
        public void MoveDown(PictureBox pb, bool canMove)
        {
            Point pos = pb.Location;
            //This subtration of the pb.Height keeps the picture box in the panel
            if (pos.Y < panel1.Height - pb.Height && canMove)
            {
                pos.Y += 20;

            }
            pb.Location = pos;
            TargetCheck();
        }
        //SC1 3 of 5 
        public void MoveRight(PictureBox pb, bool canMove)
        {
            Point pos = pb.Location;
            //This subtration of the pb.Width keeps the picture box in the panel
            if (pos.X < panel1.Width- (pb.Width+10) && canMove)
            {
                pos.X += 20;

            }
            pb.Location = pos;
            TargetCheck();
        }
        //SC1 4 of 5 
        public void MoveLeft(PictureBox pb, bool canMove )
        {
            Point pos = pb.Location;
            if (pos.X > 0 && canMove)
            {
                pos.X -= 20;

            }
            pb.Location = pos;
            TargetCheck();
        }
        //Form driven key events that call on the methods from the Controller interface
        //Not given but they will have to use it
        //SC1 5 of 5
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveUp(pbSelect, canMove);
            }
            if (e.KeyCode == Keys.Down)
            {
                MoveDown(pbSelect, canMove);
            }
            if (e.KeyCode == Keys.Right)
            {
                MoveRight(pbSelect, canMove);
            }
            if (e.KeyCode == Keys.Left)
            {
                MoveLeft(pbSelect, canMove);
            }
        }
        //Combo box implementation
        //SC3
        private void cmbLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = cmbLetters.SelectedItem.ToString();
            
            Console.WriteLine(selection); //DELETE ME
            if(selection == "Letter A")
            {
                
                pbSelect = pb_letter_A; //Sets up the program to know which letter to move
                pbTarget = pb_Target_A; //Sets up which color target to aim for
                lblTarget = lbl_A_Key; //Sets up which label will change
            }
            else if(selection == "Letter B")
            {
                pbSelect = pb_letter_B;
                pbTarget = pb_Target_B;
                lblTarget = lbl_B_Key;
            } 
            else if(selection == "Letter P")
            {
                pbSelect = pb_letter_P;
                pbTarget = pb_Target_P;
                lblTarget = lbl_P_Key;
            }
            cmbLetters.Items.Remove(selection); //Removed the item options
            ComboOnOff();
        }

        //Toggles the Combo Box.
        //Students may do something different. 
        //This will be SC4
        private void ComboOnOff()
        {
            onOff = !onOff;
            cmbLetters.Enabled = onOff;
            if(counter >=3) 
            {
                cmbLetters.Visible = false; //Kill switch to make sure it turns off
            } else
            {
                cmbLetters.Visible = onOff;
            }
            
        }

        
        //This is SC5 suggestion. //Students results will be different since no method provided
        private bool TargetCheck()
        {
            //Checks to make sure the BPA letters clear the edge of the target
            //The calculation has to take into account the width/height of the moving shape
            //and the width/height of the target. PB's XY coordinates are the top left of the
            //shape. Y increases going down. 
            if (pbSelect.Location.X > pbTarget.Location.X && pbSelect.Location.X < pbTarget.Location.X+ pbTarget.Width - pbSelect.Width && pbSelect.Location.Y > pbTarget.Location.Y && pbSelect.Location.Y < pbTarget.Location.Y + pbTarget.Height - pbSelect.Height) 
            {
                counter++; //Keeping track of how many targets have been completed
                
                //Give the user two indicators they hit the target by changing label text
                //and changing the color alpha channel to 100%(255) opaque
                pbTarget.BackColor = Color.FromArgb(255, pbTarget.BackColor);
                lblTarget.Text = "TRUE!";
                
                ComboOnOff();
                cmbLetters.Focus();
                if (counter >= 3) //Three is the max. This could have been "==" 
                {
                    canMove = false; //a kill switch on the controls. 
                    EnableDB();
                    return true; 
                }
                else
                {
                    return false;

                }
            }
            return false;



        }



        //SC6 suggestion. //Students results will be different no method provided. 
        private void EnableDB()
        {
            
            btnCreate.Enabled = true; btnDelete.Enabled = true; btnUpdate.Enabled = true;
            lstStates.Enabled = true;
            btnCreate.Focus();


        }

       //We will be adding student home state and BPA ID; these are hard coded entries
       //Students will get the string information. The buttons will allow additional entries.
       //SC7
        private void HardCodeInfo()
        {
            stateDictionary.Add("Alabama", "AL");
            stateDictionary.Add("New Mexico", "NM");
            stateDictionary.Add("Montana", "MT");
            stateDictionary.Add("Delaware", "DE");
            stateDictionary.Add("Ohio", "OH");
            stateDictionary.Add("Idaho", "ID");
            stateDictionary.Add("Texas", "TX");
            

        }

        //This buttons adds the records to the dictionary. It can only run once!
        //Students need to make sure it does not run more than once which will
        //create errors.
        //SC8 1 of 2 (see populateList() below)
        private void btnCreate_Click(object sender, EventArgs e)
        {
            HardCodeInfo();
            btnCreate.Enabled = false;
            txtID.Enabled = true; txtStateName.Enabled = true;
            txtStateName.Focus();
            populateList();


        }
        //Students do not have to use this method by traversing the Dictionary.
        //This method is used to clear and populate the list for all buttons 
        //Will need to mention some of this code (adding to dictionary and header)
        //SC8 2 of 2
        private void populateList()
        {
            lstStates.Items.Clear();
            lstStates.Items.Add("BPA State Lists"); //header
            foreach (DictionaryEntry entry in stateDictionary) //adds to the dictionary
            {
                lstStates.Items.Add(entry.Key + ": " + entry.Value);
            }
        }
        //This adds the entry to the dictionary. Simple string checks
        //can determine if information is entered. 
        //SC9
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string idTemp = txtID.Text;
            string nameTemp = txtStateName.Text;
            if (stateDictionary.Contains(nameTemp))
            {
                MessageBox.Show("This state already exists!");
                txtStateName.Text = "";
                txtID.Text = "";
                txtStateName.Focus();
            }
            else if (txtStateName.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("You are missing data entry!");
                txtStateName.Text = "";
            }
            else
            {
                stateDictionary.Add(nameTemp, idTemp);
                MessageBox.Show("Your entry was successful\n" + "State:\t" + nameTemp + "\nID:\t" + idTemp);
                txtID.Text = ""; txtStateName.Text = "";
            }
            populateList();
        }

        //This buttons deletes the selected value. There are multiple ways to accomplish this
        //In this code we just check to see if there is a colon since that is added to 
        //the listed records. NOTE: students will need to solve how to ensure there is no
        //NullReferenceException(nothing is selected) and
        //ArgumentOutOfRangeException (thrown when they select a non dictionary record
        //which is BPA in this case.
        //SC10
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string tempDEL;
                if (lstStates.SelectedItem != null)
                { tempDEL = lstStates.SelectedItem.ToString();
                    tempDEL = tempDEL.Substring(0, tempDEL.IndexOf(":"));
                    if (stateDictionary.Contains(tempDEL))
                    {
                        stateDictionary.Remove(tempDEL);
                        populateList();
                        MessageBox.Show("Deletion was successful");
                    }
                    else
                    {
                        MessageBox.Show("This action cannot be performed on BPA.");
                    }
                }
                                         
                else
                {
                    MessageBox.Show("You did not make a selection.");
                }
                               
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                //MessageBox.Show($"Error: {argumentOutOfRangeException.Message}");
                MessageBox.Show($"Error: This action cannot be performed on BPA Header.");
            }
            
        }
             
        
        
    }
    
}
