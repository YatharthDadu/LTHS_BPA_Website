
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;


public class SeatingChartBuilderNATL 
   {
   //National Point
   static Scanner sc = new Scanner(System.in); 
   static ArrayList<Students> students = new ArrayList<Students>(); //SC1
   static ArrayList<String> namesAll = new ArrayList<String>();//SC1
   
   public static void main (String args [])
      {
      //National Point to use BufferedReader to read this file
      BufferedReader in = getReader("NationalTestRecords.txt");//SC3
      	
      Students stu = readNationalTestRecords(in); //SC3
      students.add(stu);
      while (stu != null)	
         {
         stu = readNationalTestRecords(in);//SC3
         if(stu != null)
            students.add(stu);
         }
      //National Point to use Scanner to read this file. Use Try/Catch is points
      try{   //SC10
         readNationalStudentNames();
      
      } catch (IOException e){
         System.out.print("Error reading file NationalStudentNames.txt");
         }
   
      setStudents(10); //Given
      
      System.out.println("---------IMPORT SUCCESS---------");
      printStudents();
      System.out.println("\n");
      System.out.println("---------Highest GPA---------");
      printHighestGPA();
      System.out.println("\n");
      System.out.println("---------Lowest GPA---------");
      printLowestGPA(); 
      System.out.println("\n");
       
      System.out.println("---------GPA High to Low Range---------");
      print_GPAHightoLow_Range(students);
      System.out.println("\n");
      System.out.println("---------GPA Low to High Range---------");
      print_GPALowtoHigh_Range(students);
      System.out.println("\n");
      System.out.println("---------Alpha Last Name Low to High Range---------");
      print_AlphaLowtoHigh_Range(students);
      System.out.println("\n");
      System.out.println("---------Alpha Last Name High to Low Range---------");
      print_AlphaHightoLow_Range(students);
      
      }
   
   
   
   private static void print_GPAHightoLow_Range(ArrayList<Students> stuList) //SC11
      {
      stuList.sort((o1, o2)-> o2.getGPA().compareTo(
                      o1.getGPA()));
      printStudents();
      }
     
   private static void print_GPALowtoHigh_Range(ArrayList<Students> stuList) //SC12
      {
      stuList.sort((o1, o2)-> o1.getGPA().compareTo(
                      o2.getGPA()));
      printStudents();
      }
    
   private static void print_AlphaLowtoHigh_Range(ArrayList<Students> stuList) //SC13
      {
      stuList.sort((o1, o2)-> o1.getLastName().compareTo(
                      o2.getLastName()));
      printStudents();
      }
     
   private static void print_AlphaHightoLow_Range(ArrayList<Students> stuList)  //SC14
      {
      stuList.sort((o1, o2)-> o2.getLastName().compareTo(
                      o1.getLastName()));
      printStudents();
      }
   
   
   //Given
   private static void printHighestGPA() 
      {
      int ind = 0; 
      double num = 0;
   
      for(int i = 1; i < students.size(); i++)
         {
         if(students.get(i).getGPA()>students.get(ind).getGPA())
            {
            ind = i;
            num = students.get(i).getGPA();
         
            }
      
         }
      System.out.println("Max GPA: "+ students.get(ind).getGPA()+ " "+students.get(ind).getWholeName());
      }
      
    //Given
   private static void printLowestGPA() 
      {
      int ind = 0; 
      double num = 0;
   
      for(int i = 1; i < students.size(); i++)
         {
         if(students.get(i).getGPA()<students.get(ind).getGPA())
            {
            ind = i;
            num = students.get(i).getGPA();
         
            }
      
         }
      System.out.println("Min GPA: "+ students.get(ind).getGPA()+ " "+students.get(ind).getWholeName());
      }
      
    //Given
   private static void setStudents(int nc)
      {
      Random rand = new Random();
      Students s;
     
      DecimalFormat df = new DecimalFormat("#.00");
      int nameCount = nc;
      double gpa;
      int grade;
      String fn; String ln;
   
      for(int i =0; i<nameCount; i++)
         {
         
         do{
         
            fn = namesAll.get(rand.nextInt(namesAll.size()));
            ln = namesAll.get(rand.nextInt(namesAll.size()));
            }while(fn.equals(ln));
         grade = rand.nextInt(4)+9;
         double tempGPA = rand.nextDouble()*3.0 + 1.0;
         String  tempString =df.format(tempGPA);
         gpa = Double.parseDouble(tempString);
         s = new Students(fn,ln,grade,gpa);
         students.add(s);
         }
      
      }
  //Given   
   private static void printStudents(){
      int i = 1;
      for (Students n : students)
         {
         System.out.println(i+") "+n.getWholeName() + " | Grade Level: "+n.getGradeLevel()+" | GPA: "+n.getGPA());
         i++;
         }
   
      
      }
      
      //National Points 
    ////////////////////////NATIONAL METHOD//////////////////////
   private static Students readNationalTestRecords(BufferedReader in) //SC4
      {
      Students stu;
      String fn; String ln; int grade; Double gpa; 
      String line =""; 
      String[] data; 
    
      //catches errors in the read but not required since test files will not be corrupted
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
         data = line.split(","); //SC5 //"," is the delimeter to seperate the fields for the records
         fn = data[0].trim();
         ln = data[1].trim(); 
         grade = Integer.parseInt(data[2].trim());  //SC5
         gpa = Double.parseDouble(data[3]); //SC5
         }
      stu = new Students(fn,ln,grade,gpa);
      return stu;
      }

  //National Points
 //use this method for Nationals. Must use Scanner and throws IOException (part of the points)
   public static void readNationalStudentNames()throws IOException
      {
      Scanner sc2 = new Scanner(new File("NationalStudentNames.txt"));  //SC7
      sc2.useDelimiter(",");  //SC8
      
      while(sc2.hasNext())//SC8
         {
         String nameTemp = sc2.next().trim(); //SC9
         namesAll.add(nameTemp);
         }
      
      }
  //National Points    
   private static BufferedReader getReader(String name)	
      {
      BufferedReader in = null;
      try  //SC6
         {
         File file = new File(name);
         in = new BufferedReader(
            new FileReader(file) );
         }
      catch (FileNotFoundException e) //SC6
         {
         System.out.println(
            "The NationalTestRecords.txt file doesn't exist.");
         System.exit(0);
         }
      return in;
      }

   }

///////////////////////////////////////////////////
///////////////////////////////////////////////////
///////////////////////////////////////////////////
  //National Points. Get Points for Completing all of the required methods. 
  //However, they need to figure out how to make this work with the sort
class Students
   {
      String first_Name;
      String last_Name;
      int grade_Level;
      double GPA;
         
      public Students()
         {
         first_Name = "Dee";
         last_Name =  "Fault";
         grade_Level = 0;
         GPA = 0.0;
         }
   
      public Students(String fn, String ln, int gl, double gpa)
         {
         first_Name = fn;
         last_Name =  ln;
         grade_Level = gl;
         GPA = gpa;
         }
      

      public String getWholeName()
         {
         return last_Name + ", "+first_Name;
         }
         
      public String getFirstName()
         {
         return first_Name;
         }
         
      public String getLastName()
         {
         return last_Name;
         }
     //Using an ArrayList Sort requires a Double wrapper    
      public Double getGPA()
         {
         return (Double)GPA;
         }
         
      public int getGradeLevel()
         {
         return grade_Level;
         }

      
   }