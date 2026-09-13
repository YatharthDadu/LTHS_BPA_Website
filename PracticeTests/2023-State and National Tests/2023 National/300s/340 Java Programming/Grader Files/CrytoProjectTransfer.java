

import java.util.*;
import java.text.NumberFormat;
import java.io.*;


public class CrytoProjectTransfer
{
 
   public static void main (String args [])
   {
   
      //All three instances of RecordReader below reference the same wrapper object
      MyWrapper wrp  = new MyWrapper(); 
         
      //This is one of the easiest tactics and most probable, but not the only way
      RecordReader rC = new RecordReader(wrp, "Coins.txt"); 
      RecordReader rT = new RecordReader(wrp,"Tokens.txt"); 
      RecordReader rN = new RecordReader(wrp,"NFT.txt" );
   
      //This is one of the easiest tactics and most probable, but not the only way
      //It allows all of the data to get read off of the three text files and 
      //consolodated into the wrapper arraylist.
      rC.inputFileReader();
      rT.inputFileReader();
      rN.inputFileReader();
      
      wrp.fileWriter();
   }
}

//////Assett Objects Information
//!!STUDENT WILL MAKE THIS  <===
class InvestmentProducts implements Assett_Interface 
{
  
   private String type;
   private String name;
   private String symbol;
   private double quantity;
   private double currentPrice;
   private double avgPrice;
   private double buyPrice;
     
  //1st Constructor that takes in the type of investment symbol. We don't use this in the file output 
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
      
  //2nd Constructor that ignores the type of investment symbol. We use this in the program
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

 //Required Get and Set functions per the interface implementation requirements
 //Set functions will not be used in the file output.      
   public String getType()
   {
      return type;
   }
   public void setType(String t)
   {
      type = t;
   }
   public String getName()
   {
      return name;
   }
   public void setName(String n)
   {
      name = n;
   }
   public String getSymbol()
   {
      return symbol;
   }
   public void setSymbol(String s)
   {
      symbol = s;
   }
   public double getQuantity()
   {
      return quantity;
   }
   public void setQuantity(double q)
   {
      quantity = q;
   }
   public double getCurrentPrice()
   {
      return currentPrice;
   }
   public void setCurrentPrice(double cp)
   {
      currentPrice = cp;
   }
   public double getAvgPrice()
   {
      return avgPrice;
   }
   public void setAvgPrice(double ap)
   {
      avgPrice = ap;
   }
   public double getBuyPrice()
   {
      return buyPrice;
   }
   public void setBuyPrice(double bp)
   {
      buyPrice = bp;
   }
   
   public String toString()
   {
      
       return "Name: " +getName()+ ", Sym: " + getSymbol()+ ", Qty: " + getQuantity()+ ", CP: " + 
       getCurrentPrice()+ ", AP: " + getAvgPrice()+ ", BP: " + getBuyPrice()+ " \n"; 
   }

      
}

//!!STUDENT WILL MAKE THIS  <===
class NFT extends InvestmentProducts  
{
   //These are basic and call super to construct and overrides toString inclusively
   public NFT(String n, String s, double q, double cp, double ap, double bp)    
   {
      super(n,s,q,cp,ap,bp);
   }

}

//!!STUDENT WILL MAKE THIS  <===
class Coins extends InvestmentProducts 
{
  //These are basic and call super to construct and overrides toString inclusively
   public Coins(String n, String s, double q, double cp, double ap, double bp)    
   {
      super(n,s,q,cp,ap,bp);
   }
    
      
}

//!!STUDENT WILL MAKE THIS  <===
class Tokens extends InvestmentProducts 
{
    
   //These are basic and call super to construct and overrides toString inclusively 
   public Tokens(String n, String s, double q, double cp, double ap, double bp)    
   {
      super(n,s,q,cp,ap,bp);
   }

}

//Wrapper Class////////////////////////////////////////////////////////
//Uses a generic ArrayList for the three types of investment objects///
//!!STUDENT WILL MAKE THIS  <=====================================
class MyWrapper implements Wrapper_Interface
{
   //Generic ArrayList: for the given circumstances of this program
   //it can store any object file type; this is one of many options
   ArrayList arraylist = new ArrayList();
   String temp = ""; //This instance variable will host all records for printing
   
   public MyWrapper()
   {
      
   }
   public void addToList(Object a)
   {
      arraylist.add(a);
   }
  //Test prints the objects to console
  //Not Required method...just one of many ways   
   public void wrapperPrinter(String s)
   {
      System.out.print(s);
   }

   
   //Builds single String object with delimieters and headers
   //from generic structure. Called from fileTextReturn()
   //Not Required...just one of many ways  
   public void fileFeed()
   {
      for(Object o : arraylist)
      {   
         String temp2 = o.toString();
         temp += temp2;      
      }
      
   }
   //Calls the functions that builds the String object and returns it
   //Not Required
   public String fileTextReturn()
   {
      fileFeed();
      return "\n"+ temp; //instance String from above
   }

   ///////////////////////////////////////////////
   //Writes to the PrintWriter file object by using the fileTextReturn and fileFeed methods.
   //fileTextReturn and fileFeed methods are not reuired but this method MUST write to the file object
   //Interface method
   //!!STUDENT WILL MAKE THIS  <=====================================
   public void fileWriter()
   {
      PrintWriter out = openWriter("Portfolio.csv");
      exportDate(out); //This creates a consistend format for console and file
      String wraptemp = fileTextReturn();  //Not required method there's other solutions besideds this
      wrapperPrinter(wraptemp); //Not required method there's other solutions besideds this
      out.println(wraptemp); //This will have to happen to get the data to the file
      out.close(); //It's okay if they forget to close; not part of the rubric
   }

    /////////////////////////////////////////////
    //Prints the current date to console and to the file
    //Interface method
    //!!STUDENT WILL MAKE THIS  <=====================================
   public void exportDate(PrintWriter out)
   {
      java.util.Date date = new java.util.Date();  
      //Console print
      System.out.println("\n****************************************");
      System.out.println("****************************************");
      System.out.println(date+"\n****************************************");
      //.csv file print
      out.println("\n****************************************");
      out.println("****************************************");
      out.println(date+"\n****************************************");}

   /////////////////////////////////////////////
   //Creates the PrintWrite object file
   //Interface method
   //!!STUDENT WILL MAKE THIS  <=====================================  
   public PrintWriter openWriter(String name)
   {
      try
      {
         File file = new File(name);
         PrintWriter out =
            new PrintWriter(
                new BufferedWriter(
                    new FileWriter(file) ), true );
         return out;
      }
      catch (IOException e)
      {
         System.out.println("I/O Error");
         System.exit(0);
      }
      return null;
   
   }

}

//File Input///////////////////////////////////////////////////////////
//!!STUDENT WILL MAKE THIS  <=====================================    
class RecordReader implements FileReader_Interface
{
   //These are not required
   private BufferedReader in;  
   MyWrapper wrp;
   Object obj;
  
   //The constructor setup below is not required
   //NOTE: this MyWrapper object is still through reference via Main()
   public RecordReader(MyWrapper w, String r)
   {
      wrp = w;
      in = getReader(r);
      obj = null;
   }
   
      
   //!!STUDENT WILL MAKE THIS  <=====================================  
   //This method is called from the object in the Main class
   public void inputFileReader() 
   {
      obj = readBlock(in);  //old one was readCustomer
      wrp.addToList(obj);
      while ( obj != null)	
      {
         obj = readBlock(in);
         if( obj != null)
            wrp.addToList(obj);
      }
   
   }
              
  ////////////////////////////////////////////// 
  //PARTIAL STUDENT AND GIVEN
  
  //GIVEN
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
      
         //NOTE: removed this from the following condition checsk "type.trim()," 
         //!!STUDENT WILL MAKE THIS  <=====================================

         type = type.trim();
         //There's other ways to accomplish this
         //Code will have to be inspected to see if they create specific objects
         if(type.equals("C"))
         {
            return new Coins(name.trim(), symbol.trim(), quantity, currentPrice, avgCost, buyPrice);
         }
         else if(type.equals("T"))
         {
            return new Tokens(name.trim(), symbol.trim(), quantity, currentPrice, avgCost, buyPrice);
         }
         else
         {
            return new NFT(name.trim(), symbol.trim(), quantity, currentPrice, avgCost, buyPrice);
         }
      
               
      }
   }
/////////////////////////////////////////////////////////
//GOOD LEAVE ALONE
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

//////Interfaces///////////////////////////////////////////////////////

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
   public void inputFileReader(); //Pass this the text file for the getReader("txt")
   public Object readBlock(BufferedReader in);
   public BufferedReader getReader(String name);	
}
interface Wrapper_Interface
{
   public void exportDate(PrintWriter out); //PrintWriter out
   public PrintWriter openWriter(String w); //String name
   public void fileWriter();
}