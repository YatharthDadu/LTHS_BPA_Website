
import java.util.*;
import java.io.*;
import java.util.Locale;


public class CryptoExchangePortfolioManager
{

 //GIVEN
   public static void main (String args [])
   {
      
   
      BufferedReader coinsIO = getReader("Coins.txt");	
      List<ExchangeWrapper> cryptoPortfolio = new ArrayList<>();  
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
   //Reads the information from the file and breaks it into each of the objects that go into the ExchangeWrapper object            
   private static ExchangeWrapper readCoinTextFiles(BufferedReader coinsIO)	
   {
   
   }
   
   //!!STUDENT WILL MAKE THIS  <=====================================
   //Reads the information from the file and breaks it into each of the objects that go into the Positions object 
   private static BlockInfo readBlockTextFiles(BufferedReader blockIO)	
   {
   
   }

   //!!STUDENT WILL MAKE THIS  <=====================================
   //imports the file properly for BufferedReader for reading all .txt files
   private static BufferedReader getReader(String name)	
   {
   
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

////// Position Information
//PARTIAL STUDENT AND GIVEN
//PARTIAL GIVEN
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
   public Positions(String t, String n, String s, double q, double cp, double ac, double bp, BlockInfo bi)
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
      //program and replace the return String
      return "You need to program this"
   }
   
   //!!STUDENT WILL MAKE THIS  <===================================== 
   private String percentChange(){
      //program and replace the return String
      return "You need to program this";
   }
}

//PARTIALLY GIVEN
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
      //program and replace the return String
      return "You need to program this"
   }     

}
