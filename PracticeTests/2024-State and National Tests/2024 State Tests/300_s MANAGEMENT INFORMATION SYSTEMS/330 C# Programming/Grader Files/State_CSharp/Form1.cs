/*
lithium cobalt oxide (LCO), lithium manganese oxide (LMO), lithium iron phosphate (LFP), 
lithium nickel cobalt aluminum oxide (NCA) and lithium nickel manganese cobalt oxide (NMC).

*/
namespace SanJaunBasinMining
{
    public partial class Form1 : Form 
    {
        Resources port1 = new Resources();
        String mineralSymbol;
        String mineralName;
        double productionCost;
        int mineralVolume;
        public Form1()
        {
            InitializeComponent();
            readFile();
        }

        //STUDENT POINT
        private void readFile()
        {
            try //STUDENT POINT  //SC1
            {
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                TextReader tr = new StreamReader(_filePath + "/Resources/mineralsText.txt");   //SC1

                mineralSymbol = tr.ReadLine();

                while (!mineralSymbol.ToUpper().Equals("STOP"))  //SC1
                {
                    mineralName = tr.ReadLine();
                    productionCost = Double.Parse(tr.ReadLine());
                    mineralVolume = Int32.Parse(tr.ReadLine());

                    port1.mineralProcurement(mineralSymbol,mineralName,productionCost,mineralVolume);  //SC1
                    mineralSymbol = tr.ReadLine();
                }

                consoleBox.Text = port1.ToString(); 
            }
            catch (FileNotFoundException)
            {
                consoleBox.Text = "The text file was not found.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}