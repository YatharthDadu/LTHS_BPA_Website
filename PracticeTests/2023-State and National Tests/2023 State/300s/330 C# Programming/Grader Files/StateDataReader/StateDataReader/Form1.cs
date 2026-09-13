using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //Needed for process

namespace StateDataReader
{
    public partial class Form1 : Form
    {
        List<string> data = new List<string>();
        List<string> dataLastName = new List<string>();
        //List<Students> students = new List<Students>(); //This was not used in the solution, but it could have

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       // This button command will find all of the text files and read them into the program. 
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            //THE TEXT FILES HAVE BEEN PLACED IN THE BIN/DEBUG FOLDER WITH THE EXE FILES
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName); //GETS LOCATION OF THE EXE FILE
            
            //NOTE: students may try to manually link every text file. 
            string filter = "*.txt"; //This is used in next line to find all text files
            string[] files = Directory.GetFiles(folder, filter); //this is the absolute path 
                    //for the file for StreamReader which normally would have the path in "\\path\\etc."
            
            

            
            string line;
            int count = 1;
            for(int i = 0; i < files.Length; i++)
            {
                
                StreamReader sr = new StreamReader(files[i]);
                line = sr.ReadLine();
                while (line != null)
                {
                    data.Add(line);
                    lstNames.Items.Add(count + ") "+ line);
                    line = sr.ReadLine();
                    count++;
                }
            }   
            
            
        }

        //This command will sort the list A to Z with built in .Sort() method. 
        //This sorts based upon first character of the record
        private void btnAtoZ_Click(object sender, EventArgs e)
        {
            lstAtoZ.Items.Clear(); //list box should be cleared ahead but not required
            int count = 1;
            data.Sort();
            foreach (string s in data)
            {
                lstAtoZ.Items.Add(count+ ") "+s);   
                count++;
            }
        }

        //This command will sort the list Z to A with built in Reverse() method. 
        //This sorts based upon first character of the record
        private void btnZtoA_Click(object sender, EventArgs e)
        {
            lstZtoA.Items.Clear();
            int count = data.Count;
            //data.Sort(); //Ignore. 
            data.Reverse();
            foreach (string s in data)
            {
                lstZtoA.Items.Add(count + ") " + s);
                count--;
            }
        }

        //This command will break the record into the conventions, and reorganize it. 
        private void btnLastAtoZ_Click(object sender, EventArgs e)
        {
            string temp1 = null;
            string temp2 = null;
            string temp3 = null;
            int found = 0;
            int count = 1;
            foreach (string s in data)
            {
                
                string tempFullName = s.TrimStart();
                temp1 = null; 
                temp2 = null; 
                temp3 = null; 
                found = tempFullName.IndexOf(" ");
                

                if (temp1 == null) {
                    temp1 = tempFullName.Substring(0, found);
                    temp2 = tempFullName.Remove(0, found);
                        
                        
                }
                temp2.TrimStart();
                found = temp2.IndexOf(" "); //Checks for an extra space which indicates a prefix was used
                if (found > 0)
                {
                    string temp = temp2;
                    temp2 = temp.Substring(0, found+1);
                    temp3 = temp.Remove(0, found);

                }
                
                //Prints out convention names with NO prefix
                if (temp3 == null) {
                    dataLastName.Add(temp2 + ", "+temp1);
                }
                else //Prints out convention names with prefix
                {
                    dataLastName.Add(temp3 + ", " + temp2 + " " + temp1);
                }
                
                
            }

            dataLastName.Sort();
            foreach (string s in dataLastName)
            {
                lstLastName.Items.Add(count+ ") "+s);
                count++;
            }
            btnWordTotal.Enabled = true;
        }

        //Counts all of the words and characters in the list. 
        private void btnWordTotal_Click(object sender, EventArgs e)
        {
            
            int countWords = 0;
            int countChars = 0;
            foreach (string s in data)
            {
                countWords += s.Trim().Split(' ').Length;
                countChars += s.Trim().Replace(" ","").Replace(".","").Length; //Does not count the '.' and spaces
            }
            lblWordTotal.Text = "Words: " + countWords.ToString();
            lblCharTotal.Text = "Chars: " + countChars.ToString();

        }
    }
}
