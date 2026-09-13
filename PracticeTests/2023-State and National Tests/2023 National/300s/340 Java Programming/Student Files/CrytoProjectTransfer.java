

import java.util.*;
import java.text.NumberFormat;
import java.io.*;

public class CrytoProjectTransfer
{
 
   public static void main (String args [])
   {
   
      
         
      //Hint: There are multiple pathways to get this done
      /*One easy tactic is to create a RecordReader object for each object type
        and have each one write to a single MyWrapper object that has a data structure to take
        generic objects
      */
   }
}

//!!STUDENT WILL MAKE THIS  <=====================================
 //Only parent class skeleton with a couple constructor options
 //Remember the interface
class InvestmentProducts
{
   //Suggested variables
   private String type;
   private String name;
   private String symbol;
   private double quantity;
   private double currentPrice;
   private double avgPrice;
   private double buyPrice;
     
  //1st possible constructor that takes in the type of investment symbol that is not used in the output
   public InvestmentProducts(String type, String name, String symbol, double quantity, double currentPrice,
                               double avgPrice, double buyPrice)
   {
      this.type = type;
      this.name=name;
      this.symbol=symbol;
      this.quantity=quantity;
      this.currentPrice=currentPrice;
      this.avgPrice=avgPrice;
      this.buyPrice=buyPrice;
   }
      
  //2nd possible constructor that ignores the type of investment symbol
   public InvestmentProducts(String name, String symbol, double quantity, double currentPrice,
                               double avgPrice, double buyPrice)
   {
      this.type = "";
      this.name=name;
      this.symbol=symbol;
      this.quantity=quantity;
      this.currentPrice=currentPrice;
      this.avgPrice=avgPrice;
      this.buyPrice=buyPrice;
   }

       
}

//!!STUDENT WILL MAKE THIS  <=====================================
//Remember the inheritance
class NFT 
{
      
}

//!!STUDENT WILL MAKE THIS  <=====================================
//Remember the inheritance
class Coins
{
  
}

//!!STUDENT WILL MAKE THIS  <=====================================
//Remember the inheritance
class Tokens 
{
 
}

//!!STUDENT WILL MAKE THIS  <=====================================
//Remember to use a generic ArrayList for the three types of investment objects
//Remember the interface
class MyWrapper
{
   
}

//File Input///////////////////////////////////////////////////////////
//!!STUDENT WILL MAKE THIS  <=====================================    
//Remember the interface
class RecordReader 
{

   private BufferedReader in;  
              
  ////////////////////////////////////////////// 
  //PARTIALLY GIVEN
   public Object readBlock(BufferedReader in)	
   {
       
      String type ="";
      String name ="";
      String symbol ="";
      double quantity;
      double currentPrice;
      double avgCost;
      double buyPrice;
      
               
      String line = "";
      String[] data;  
      
      //catches errors in the read
      try
      {
         line = in.readLine();
      }
      catch (IOException e)
      {
         System.out.println("I/O Error");
         System.exit(0);
      }
      //terminates the file read once it gets to the end
      if (line == null)
         return null;
      else
      {
         //each field goes in escalating arithmetic sequence 0 to 6      
         data = line.split(";");
         type = data[0];
         name = data[1];    
         symbol = data[2];
         quantity = Double.parseDouble(data[3]);
         currentPrice = Double.parseDouble(data[4]);
         avgCost = Double.parseDouble(data[5]);
         buyPrice = Double.parseDouble(data[6]);
      
         
         //!!STUDENT WILL MAKE THE REST OF THIS METHOD <===========================
                       
      }
   }

//GIVEN
   public BufferedReader getReader(String name)	
   {
      BufferedReader in = null;
      try
      {
         File file = new File(name);
         in = new BufferedReader(
               new FileReader(file) );
      }
      catch (FileNotFoundException e)
      {
         System.out.println(
               "The file doesn't exist.");
         System.exit(0);
      }
      return in;
   }

}

//Interfaces////////////////////
//GIVEN   
interface Assett_Interface
{
   public String getType();
   public void setType(String t);
   public String getName();
   public void setName(String n);
   public String getSymbol();
   public void setSymbol(String s);
   public double getQuantity();
   public void setQuantity(double q);
   public double getCurrentPrice();
   public void setCurrentPrice(double cp);
   public double getAvgPrice();
   public void setAvgPrice(double ap);
   public double getBuyPrice();
   public void setBuyPrice(double bp);
   public String toString();


}
   
interface FileReader_Interface
{
   public void inputFileReader(); 
   public Object readBlock(BufferedReader in);
   public BufferedReader getReader(String name);	
}

interface Wrapper_Interface
{
   public void exportDate(PrintWriter out); 
   public PrintWriter openWriter(String w); 
   public void fileWriter();
}