import java.util.*;
import java.text.NumberFormat;
import java.io.*;

//For State they will read the entire file and break it into the other objects
public class TollwayCustomerDataBaseNational
   {

 
   public static void main (String args [])
      {
      
      
      BufferedReader in = getReader("Names.txt");	
      List<Customer> customers = new ArrayList<>();  //Contains the customer objects
      List<Customer> clonedCustomers = new ArrayList<>(); 
      Customer cust = readCustomer(in);
      customers.add(cust);
      while (cust != null)	
         {
         cust = readCustomer(in);
         if(cust != null)
            customers.add(cust);
         }
      for (Customer c : customers){
         System.out.println(c);
         System.out.println(c.getInfo());
         clonedCustomers.add((Customer)c.clone());
         }
      System.out.println("*******************CLONES*******************");
      for (Customer c : clonedCustomers){
         System.out.println(c);
         System.out.println(c.getInfo());
         }
           
      //This block will export the data to the text file. 
      PrintWriter out = openWriter("Clones.txt");
      exportDate(out);
      for (Customer c : clonedCustomers)
              exportClones(c, out);
      out.close();   
      }
 
  //These two methods write to the file. exportDate prints the current date at the top
   private static void exportDate(PrintWriter out)
      {
      java.util.Date date = new java.util.Date();  
      out.println(date);
      }
  
  //exportClones prints each cloned Customer record to the text file   
   private static void exportClones(Customer c, 	
       PrintWriter out)
      {
      String line = c.getInfo();
      out.println(line);
      }
  
  //Creates the proper file for the text to be written to
   private static PrintWriter openWriter(String name)
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
    

//Reads the information from the file and breaks it into each of the objects that go into the Customer object            
   private static Customer readCustomer(BufferedReader in)	
      {
      //Name Class plus Fields
      Name name; String firstN; String lastN;
      //CarInfo Class plus Fields
      CarInfo carinfo; String make; String model; String plates;
      //Payment Class plus Fields
      Payment payment;double deposit; String creditcard;
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
      //ends the read once it gets to the end
      if (line == null)
         return null;
      else
         {
         data = line.split(",");  //"," is the delimeter to seperate the fields for the records
         firstN = data[0];    //each field goes in escalating arithmetic sequence 0 to 6
         lastN = data[1];
         make = data[2];
         model = data[3];
         plates = data[4];
         deposit = Double.parseDouble(data[5]);
         creditcard = data[6];
         //construct the objects to be placed in the Customer object
         name = new Name(firstN, lastN);
         carinfo = new CarInfo(make, model, plates);
         payment = new Payment(deposit, creditcard);
         return new Customer(name, carinfo, payment);
         }
      }
   
   

//imports the file properly for BufferedReader
   private static BufferedReader getReader(String name)	
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

//////////HELPER CLASSES////////////////////////////////////////////////////////////
/*  The four helper classes are basically the same layout excluding the differences
*   which are in their fields of data. Each one must use the interfaces. 
*/

//////Customer Objects Information/////////////////////////////////////
class Customer implements InformationRetrieval, Cloneable
   {
   public Name name;
   public CarInfo carinfo;
   public Payment pay;
   private String cloned ="";  //this is just a flag to help quickly identify if the record was cloned
   
   public Customer(Name n, CarInfo c, Payment p)    
      {
      this.name = n;
      this.carinfo = c;
      this.pay = p;
      }
   
   //Required method from the interface
   public String getInfo()
      {
   
      return  cloned + this.name.getInfo() + "\n" + this.carinfo.getInfo() + "\n" + this.pay.getInfo() + "\n" ;
      }
   
   //Required method from the interface
   public Object clone()
      {
      Customer customer;
      try
         {
         cloned = confirmed();
         customer = (Customer) super.clone();
         customer.name = (Name)name.clone();
         customer.carinfo = (CarInfo)carinfo.clone();
         customer.pay = (Payment)pay.clone();
         }
      catch (CloneNotSupportedException e)
         {
         return null;  
         }
      return customer;
      }
   // This method only supplies the cloned variable with a string literal. It is only called in the clone() method   
   public String confirmed()
      {
      return "DUPLICATES \n";
      };  
   }

//////Name Object Information/////////////////////////////////////
class Name implements InformationRetrieval, Cloneable
   {
   private String last_Name;
   private String first_Name;
   private String cloned ="";
   
   public Name(String fn, String ln)
      {
      this.last_Name = ln;
      this.first_Name = fn;
      }
   
   public String getInfo()
      {
      return cloned + " Name: " + this.first_Name + " " + this.last_Name;
      }     
   public Object clone()
      {
      try
         {
         cloned = confirmed();
         return super.clone();
      
         }
      catch (CloneNotSupportedException e)
         {
         return null;  
         }
   
      }
   public String confirmed()
      {
      return "CLONED";
      }; 

   }

//////CarInfo Object Information/////////////////////////////////////
class CarInfo implements InformationRetrieval, Cloneable
   {
   private String make;
   private String model;
   private String plates;
   private String cloned ="";
   
   public CarInfo(String ma, String mo, String pl)
      {
      this.make = ma;
      this.model = mo;
      this.plates = pl;
      }
   
   public String getInfo()
      {
      return cloned + " Car Information: " + this.make + " " + this.model + " " + this.plates ;
      }     
   public Object clone()
      {
      try
         {
         cloned = confirmed();
         return super.clone();
         
         }
      catch (CloneNotSupportedException e)
         {
         return null;  
         }
      
      }
   public String confirmed()
      {
      return "CLONED";
      }; 
   }

//////Payment Object Information/////////////////////////////////////
class Payment implements InformationRetrieval, Cloneable
   {
   private double deposit;
   private String creditCard;
   private NumberFormat depositFormat = NumberFormat.getCurrencyInstance();  
   private String cloned ="";
    
   public Payment(double de, String cc)
      {
      this.deposit = de;
      this.creditCard = cc;
      }
      
   public String getInfo()
      {
      return cloned + " Payment: " + depositFormat.format(this.deposit) + " " + this.creditCard;
      }     
      
   public Object clone()
      {
      try
         {
         cloned = confirmed();
         return super.clone();
      
         }
      catch (CloneNotSupportedException e)
         {
         return null;  
         }
   
      }
      
   public String confirmed()
      {
      return "CLONED";
      }; 
   }
   
//////InformationRetrieval Interface/////////////////////////////////////
interface InformationRetrieval
   {
   public String getInfo();  //this returns the strings for printing to the console and to write the file
   public String confirmed();   //returns a string to fill an empty String object to append the word CLONED to each line of
                                //data that is printed.  
   
   }