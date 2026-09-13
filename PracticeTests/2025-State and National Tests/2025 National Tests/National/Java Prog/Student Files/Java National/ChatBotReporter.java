import java.util.List;
import java.util.Scanner;
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;


public class ChatBotReporter {

   public static void chatBotReporter(List<Chat_Bots> chat_Bots) {
        
     
      System.out.println("\n\n>>>>>>>>>>Choose a print option: <<<<<<<<<<");
      System.out.println("1. Print Chat_Bots");
      System.out.println("2. Highest Complex Chat_Bots");
      System.out.println("3. Lowest Complex Chat_Bots");
      System.out.println("4. Complexity Range (HIGH to LOW)");
      System.out.println("5. Complexity Range (LOW to HIGH)");
      System.out.println("6. Primary Language Range (A to Z)");
      System.out.println("7. Primary Language Range (Z to A)");
      System.out.println("0. Exit");
      
   }
   
   private static void consoleMostComplex(List<Chat_Bots> chat_Bots) {  
        
      System.out.println("\n");
      System.out.println("---------Highest Complexity-----------------------------------------");
      
          
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLeastComplex(List<Chat_Bots> chat_Bots) { 
      
      System.out.println("\n");
      System.out.println("---------Lowest Complexity-----------------------------------------");
      
      
      
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleComplexRange_HIGH_to_low(List<Chat_Bots> chat_Bots) { 
        
      System.out.println("\n");
      System.out.println("---------Complexity High to Low Range-----------------------------------------");
      
      
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleComplexRange_LOW_to_high(List<Chat_Bots> chat_Bots) { 
      System.out.println("\n");
      System.out.println("---------Complexity Low to High Range-----------------------------------------");
      
      
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLanguageRange_LOW_to_high(List<Chat_Bots> chat_Bots) { 
      System.out.println("\n");
      System.out.println("---------Primary Language Order (Low [A] to High Range [Z])-----------------------------------------");
      
      
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLanguageRange_HIGH_to_low(List<Chat_Bots> chat_Bots) { 
       
       
      System.out.println("\n");
      System.out.println("---------Primary Language Order (High [Z] to Low Range [A])-----------------------------------------");
      
   }
   private static void printChat_Bots(List<Chat_Bots> chat_Bots) {
      
      
   }

}
