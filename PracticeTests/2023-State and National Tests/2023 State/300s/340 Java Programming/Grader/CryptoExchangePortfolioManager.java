
import java.util.*;
import java.io.*;
import java.util.Locale;


public class CryptoExchangePortfolioManager
{

 //GIVEN
   public static void main (String args [])
   {
      
   
      BufferedReader coinsIO = getReader("Coins.txt");	
      List<ExchangeWrapper> cryptoPortfolio = new ArrayList<>();  //Contains the customer objects
      ExchangeWrapper wrappedPosition = readCoinTextFiles(coinsIO);
      cryptoPortfolio.add(wrappedPosition);
      System.out.println("=========POSITIONS=========");
      while (wrappedPosition != null)	
      {
         wrappedPosition = readCoinTextFiles(coinsIO);
         if(wrappedPosition != null)
            cryptoPortfolio.add(wrappedPosition);
      }
      for (ExchangeWrapper c : cryptoPortfolio){
         System.out.println(c.getInfo()); 
      }
   
      
   }
   
   //!!STUDENT WILL MAKE THIS  <===================================== 
   /*Reads the information from the file and breaks it into each of the 
   objects that go into the ExchangeWrapper object*/            
   private static ExchangeWrapper readCoinTextFiles(BufferedReader coinsIO)	
   {
      //Positions Class plus Fields
      Positions pos; 
      String type;
      String name;
      String symbol;
      double quantity;
      double currentPrice;
      double avgCost;
      double buyPrice;
      BlockInfo blkInfo;
               
      String line = "";
      String[] data;  
       
      
      //catches errors in the read
      try
      {
         line = coinsIO.readLine();
      }
      catch (IOException e)
      {
         System.out.println("I/O Error Coins");
         System.exit(0);
      }
      //ends the read once it gets to the end
      if (line == null)
         return null;
      else
      {
         data = line.split(";");  //";" is the delimiter to seperate the fields for the records
         type = data[0];
         name = data[1];    //each field goes in escalating arithmetic sequence 0 to 6
         symbol = data[2];
         quantity = Double.parseDouble(data[3]);
         currentPrice = Double.parseDouble(data[4]);
         avgCost = Double.parseDouble(data[5]);
         buyPrice = Double.parseDouble(data[6]);
         
         /*Construct the objects to be placed in the Positions object; 
         the symbol will need to be trimmed */
         String temp = symbol+".txt";
         temp = temp.trim();
         
         //Read the Block Files to be constructed and added to the Positions
         BufferedReader block = getReader(temp);
         blkInfo = readBlockTextFiles(block);
         
         pos = new Positions(type.trim(), name.trim(), symbol.trim(), quantity, 
                              currentPrice, avgCost, buyPrice, blkInfo);
         return new ExchangeWrapper(pos);
      }
   }
   
   //!!STUDENT WILL MAKE THIS  <=====================================
   /*Reads the information from the file and breaks it into each of the objects that 
   go into the Positions object */
   private static BlockInfo readBlockTextFiles(BufferedReader blockIO)	
   {
      //Positions Class plus Fields
      //The long value will need to be trimmed 
      BlockInfo blkInfo; 
      String web;
      String source;
      String trimHold;
      long market;
      String tag;
   
      String line = "";
      String[] data;  
       
      
      //catches errors in the read
      try
      {
         line = blockIO.readLine();
      }
      catch (IOException e)
      {
         System.out.println("I/O Error Block");
         System.exit(0);
      }
      //ends the read once it gets to the end
      if (line == null)
         return null;
      else
      {
         data = line.split(";");  //"," is the delimeter to seperate the fields for the records
         web = data[0];
         source = data[1];    //each field goes in escalating arithmetic sequence 0 to 3
         trimHold = data[2];
         market = Long.parseLong(trimHold.trim());
         tag = data[3];   
         
         blkInfo = new BlockInfo(web, source, market, tag);
         return blkInfo;
      }
   }

   //!!STUDENT WILL MAKE THIS  <=====================================
   //imports the file properly for BufferedReader for reading all .txt files
   private static BufferedReader getReader(String name)	
   {
      BufferedReader coinsIO = null;
      try
      {
         File file = new File(name);
         coinsIO = new BufferedReader(
            new FileReader(file) );
      }
      catch (FileNotFoundException e)
      {
         System.out.println(
            "The file doesn't exist.");
         System.exit(0);
      }
      
   
      return coinsIO;
   }
}
   
   



////// ExchangeWrapper Information: GIVEN
class ExchangeWrapper
{
   public Positions positions;  

   
   public ExchangeWrapper(Positions p)    
   {
      this.positions = p;
         
   }
   
   public String getInfo(){
   
      return this.positions.getInfo();
   }
}

////// Positions: Partially Given 
class Positions
{
   private String type; //This is not used
   private String name;
   private String symbol;
   private double quantity;
   private double currentPrice;
   private double avgCost;
   private double buyPrice;
   public BlockInfo blkInfo;  
   private double percentChange;
   
   
   //GIVEN
   public Positions(String t, String n, String s, double q, double cp, double ac, 
                     double bp, BlockInfo bi)
   {
      type = t;
      name = n;
      symbol = s;
      quantity = q;
      currentPrice = cp;
      avgCost = ac;
      buyPrice = bp;
      blkInfo = bi;
   }
  
   //!!STUDENT WILL MAKE THIS  <=====================================
   public String getInfo()
   {
      return "\nName: " + name + " | Symbol: " + symbol + " | Quantity: " + String.format("%,.4f",quantity) + 
            "| Current Price: $" + String.format("%,.4f",currentPrice) + "\n\tAverage Price $" + 
            String.format("%,.4f",avgCost) + " | Purchase Price: $" + String.format("%,.4f",buyPrice) + 
             " | Percent Change: " + percentChange() + "% \n\t" + blkInfo.getInfo();
   }
   
   //!!STUDENT WILL MAKE THIS  <===================================== 
   private String percentChange(){
      percentChange = ((currentPrice - buyPrice)/buyPrice) *100;
      String temp = String.format("%,.2f",percentChange);
      return temp;
   }
}

////// BlockInfo: Partially Given
class BlockInfo
{
   private String website;
   private String sourceCode;
   private long marketCap;
   private String tag;
   
   public BlockInfo(String w, String sc, long mc,  String t)
   {
      website = w;
      sourceCode = sc;
      marketCap = mc;
      tag = t;
   }
   
   //!!STUDENT WILL MAKE THIS  <===================================== 
   public String getInfo()
   {
      return "Web URL: " + website + " | SourceCode URL: " + sourceCode + 
      " | Market Cap: $" + String.format("%,d", marketCap) + " | Tag: " + tag;
   }     

}
