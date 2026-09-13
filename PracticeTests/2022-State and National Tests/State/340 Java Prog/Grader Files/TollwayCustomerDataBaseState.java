import java.util.*;
import java.text.NumberFormat;
import java.io.*;

//For State they will read the entire file and break it into the other objects
public class TollwayCustomerDataBaseState
   {

 
   public static void main (String args [])
      {
      
   
      BufferedReader in = getReader("Names.txt");	
      List<Customer> customers = new ArrayList<>();  //Contains the customer objects
      Customer cust = readCustomer(in);
      customers.add(cust);
      while (cust != null)	
         {
         cust = readCustomer(in);
         if(cust != null)
            customers.add(cust);
         }
      System.out.println(">>>>>>>>>>>>> There were " + customers.size()+ " created.<<<<<<<<<<<\n");
      for (Customer c : customers){
         System.out.println(c.getInfo()); 
         }
   
      
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
   

//////State Customer Information
class Customer
   {
   public Name name;
   public CarInfo carinfo;
   public Payment pay;
   
   public Customer(Name n, CarInfo c, Payment p)    
      {
      this.name = n;
      this.carinfo = c;
      this.pay = p;
      }
   
   public String getInfo(){
   
      return this.name.getInfo() + "\n" + this.carinfo.getInfo() + "\n" + this.pay.getInfo() + "\n" ;
      }
   }

class Name
   {
   private String last_Name;
   private String first_Name;
   
   public Name(String fn, String ln)
      {
      this.last_Name = ln;
      this.first_Name = fn;
      }
   
   public String getInfo()
      {
      return "Name: " + this.first_Name + " " + this.last_Name;
      }     

   }

class CarInfo
   {
   private String make;
   private String model;
   private String plates;
   
   public CarInfo(String ma, String mo, String pl)
      {
      this.make = ma;
      this.model = mo;
      this.plates = pl;
      }
   
   public String getInfo()
      {
      return "Car Information: " + this.make + " " + this.model + " " + this.plates ;
      }     

   }

class Payment
   {
   private double deposit;
   private String creditCard;
   private NumberFormat depositFormat = NumberFormat.getCurrencyInstance();   
   public Payment(double de, String cc)
      {
      this.deposit = de;
      this.creditCard = cc;
      }
      
   public String getInfo()
      {
      return "Payment: " + depositFormat.format(this.deposit) + " " + this.creditCard;
      }     
      
   public double getDeposit(){         
      return this.deposit; }
   
   }

