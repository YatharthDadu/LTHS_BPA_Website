
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;


public class SeatingChartBuilderNATL 
   {

   
      public static void main (String args [])
         {
         
         }
      
   
      
      private static void print_GPAHightoLow_Range() 
         {
         
         }
        
      private static void print_GPALowtoHigh_Range() 
         {
      
         }
       
      private static void print_AlphaLowtoHigh_Range() 
         {
      
         }
        
      private static void print_AlphaHightoLow_Range()  
         {
         
         }
      
      
   
      private static void printHighestGPA() 
         {
         
         }
         
       
      private static void printLowestGPA() 
         {
         
         }
         
       
      private static void setStudents()
         {
         
         }
   
      private static void printStudents()
         {
         
         }
      
   
      private static Students readNationalTestRecords() 
         {
      
         }
   
   
      public static void readNationalStudentNames()
         {
      
         }
   
      private static BufferedReader getReader()	
         {
      
         }

   }

///////////////////////////////////////////////////
///////////////////////////////////////////////////
//STUDENT CLASS//
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
         
   
         getWholeName() //returns whole name
            
            
         getFirstName() //returns first name
            
            
         getLastName() //returns last name
            
           
         getGPA() //returns the GPA
            
            
         getGradeLevel() //the grade level
            
              
      
   }