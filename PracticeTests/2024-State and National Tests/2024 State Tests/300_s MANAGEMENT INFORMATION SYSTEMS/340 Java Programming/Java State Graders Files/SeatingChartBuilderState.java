
import java.io.FileNotFoundException;
import java.io.File;
import java.util.*; 
import java.text.DecimalFormat;

public class SeatingChartBuilderState
   {
   
   static Scanner sc = new Scanner(System.in);  //SC2
   static ArrayList<Students> students = new ArrayList<Students>(); //SC2
   public static void main (String args [])
      {
      
   
      inputManager(); //Given
     
      printStudents();
      printHighestGPA(); //Given
      printLowestGPA(); //Given
      
      }
  
   
   
   //Students will create. Signature only
   private static void printHighestGPA() //ArrayList<Students> stuList
      {
      int ind = 0; 
      double num = 0;
   
      for(int i = 1; i < students.size(); i++)
         {
         if(students.get(i).getGPA()>students.get(ind).getGPA()) //SC3
            {
            ind = i;
            num = students.get(i).getGPA();
         
            }
      
         }
      System.out.println("\n\nMax GPA: "+ students.get(ind).getGPA()+ " "+students.get(ind).getWholeName());
      }
      
   //STATE POINT
   //Students will create. Signature only         
   private static void printLowestGPA() 
      {
      int ind = 0; 
      double num = 0;
   
      for(int i = 1; i < students.size(); i++)
         {
         if(students.get(i).getGPA()<students.get(ind).getGPA()) //SC4
            {
            ind = i;
            num = students.get(i).getGPA();
         
            }
      
         }
      System.out.println("\n\nMin GPA: "+ students.get(ind).getGPA()+ " "+students.get(ind).getWholeName());
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
      
      String [] allNames ={"Walter","Jones","Rose","Wilson" ,"Jack", "Rodriguez" , "Elizabeth" , "Smith", "Earl", "Carter", "Linda", "Ward", "Christopher", 
         "Turner", "Martin", "Murphy", "Betty", "Garcia", "Shawn", "Taylor","Sean", "Simmons", "Joshua", "Evans", "Norma", "Mitchell", "Brenda", "Johnson", "Donna", 
         "Clark", "Irene", "Diaz","Marilyn", "Coleman","Arthur", "Collins","Henry", "Hall","Howard", "Robinson","Jerry", "Green","Maria", "Price", "Evelyn", "Bell", 
         "Janet", "Moore", "Susan", "Foster"};
          
      for(int i =0; i<nameCount; i++)
         {
         
         do{
         
            fn = allNames[rand.nextInt(allNames.length)];
            ln = allNames[rand.nextInt(allNames.length)];
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
   
      printHighestGPA(); 
      printLowestGPA();
      }
      
        
   private static void inputManager()
      {
      int temp =0;
      int grade =0; 
      double GPA =0.0;
      String firstName;
      String lastName;
      String  tempString;
      Students s;
      DecimalFormat df = new DecimalFormat("#.00"); //SC9
      
      
      while(true){   
         try{    //SC5
            do{
               temp =0;
               System.out.println("______________________________________________________________________");
               System.out.println("Hello. What would you like to do today?");
               System.out.println("Press [1] to create random students OR Press [2] to create a single student OR Press [3] to end the program");
               temp = sc.nextInt();
               if(temp <= 0 || temp > 3) System.out.println("Your entry is out of range."); //SC5
               sc.nextLine();
               } while(temp <= 0 || temp > 3);
            if(temp ==1){
               do{
                  temp =0;
                  try{  //SC6
                     do{
                        System.out.print("Please enter in a value between 1 and 50: ");
                        temp = sc.nextInt();
                        if(temp >50 || temp <1) System.out.println("Your entry is out of range.");  //SC6
                        sc.nextLine();
                        }while(temp>50|| temp<1); 
                     }
                  catch(InputMismatchException e) //SC6
                     {
                     sc.next();
                     System.out.println("\nERROR: Please enter valid data type.");
                     }
                  } while(temp >50 || temp <1);
               setStudents(temp);
               temp =0;
               System.out.println("______________________________________________________________________");
               printStudents();
               }
            if(temp ==2){
               
               System.out.println("You are now creating a single student");
               System.out.println("Enter in the first name");
               firstName = sc.nextLine().toLowerCase();
               
               System.out.println("Enter in the last name");
               lastName = sc.nextLine().toLowerCase();
               do{
                  try{   //SC7
                     do{
                        System.out.println("Enter in the student grade level 9th-12th");
                        grade = sc.nextInt();
                        if(grade >12 || grade <9) System.out.println("Your entry is out of range."); //SC7
                        }while(grade >12 || grade <9);
                     }
                  catch(InputMismatchException e) //SC7
                     {
                     sc.next();
                     System.out.println("\nERROR: Please enter valid data type.");
                     }
                  }while(grade >12 || grade <9);
               do{
                  try{ //SC8
                     do{
                        System.out.println("Enter in the GPA in its proper format (#.##)");
                        GPA = sc.nextDouble();
                        tempString =df.format(GPA); //SC9
                        GPA = Double.parseDouble(tempString);
                        if(GPA>4.0 || GPA <= 0.0) System.out.println("Your entry is out of range."); //SC8
                        }while(GPA>4.0 || GPA <= 0.0);
                     }
                  catch(InputMismatchException e) //SC8
                     {
                     sc.next();
                     System.out.println("\nERROR: Please enter valid data type.");
                     }
                  }while(GPA>4.0 || GPA <= 0.0);
               firstName = firstName.substring(0,1).toUpperCase() + firstName.substring(1).toLowerCase(); //SC10
               lastName = lastName.substring(0,1).toUpperCase() + lastName.substring(1).toLowerCase(); //SC10
               s = new Students(firstName,lastName,grade,GPA);
               students.add(s);
               System.out.println("______________________________________________________________________");
               printStudents();
               }
            if(temp ==3){
               System.out.println("Goodbye!");
               System.exit(0); //SC11
               }
            }
         catch(InputMismatchException e) //SC5
            {
            sc.next();
            System.out.println("\nERROR: Please enter valid data type.");
            }
         }
      
      }  


   }

 //SC1
class Students
   {
   //Create appropriately variables based upon constructor parameters
   String first_Name;
   String last_Name;
   int grade_Level;
   double GPA;
    //Generic Constructor  
   public Students()
      {
      first_Name = "Dee";
      last_Name =  "Fault";
      grade_Level = 0;
      GPA = 0.0;
      }
    //Constructor with Parameters
   public Students(String fn, String ln, int gl, double gpa)
      {
      first_Name = fn;
      last_Name =  ln;
      grade_Level = gl;
      GPA = gpa;
      }
      
    //Returns "last name, first name" with appropriate variables
   public String getWholeName()
      {
      return last_Name + ", "+first_Name;
      }
    //Returns first name
   public String getFirstName()
      {
      return first_Name;
      }
    //Returns last name  
   public String getLastName()
      {
      return last_Name;
      }
   //Returns the GPA   
   public double getGPA()
      {
      return GPA;
      }
    //Returns grade level  
   public int getGradeLevel()
      {
      return grade_Level;
      }
    

   }