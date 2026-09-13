import java.util.List;
import java.util.Scanner;
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;


public class ChatBotReporter {

   public static void chatBotReporter(List<Chat_Bots> chat_Bots) {
      Scanner scanner = new Scanner(System.in);
      int choice;
   
      do {
         System.out.println("\n\n>>>>>>>>>>Choose a print option: <<<<<<<<<<");
         System.out.println("1. Print Chat_Bots");
         System.out.println("2. Highest Complex Chat_Bots");
         System.out.println("3. Lowest Complex Chat_Bots");
         System.out.println("4. Complexity Range (HIGH to LOW)");
         System.out.println("5. Complexity Range (LOW to HIGH)");
         System.out.println("6. Primary Language Range (A to Z)");
         System.out.println("7. Primary Language Range (Z to A)");
         System.out.println("0. Exit");
      
         choice = scanner.nextInt();
      
         switch (choice) {
            case 1:
               printChat_Bots(chat_Bots);
               break;
            case 2:
               consoleMostComplex(chat_Bots); //SC11B
               break;
            case 3:
               consoleLeastComplex(chat_Bots);//SC12A
               break;
            case 4:
               consoleComplexRange_HIGH_to_low(chat_Bots); //SC13A
               break;
            case 5:
               consoleComplexRange_LOW_to_high(chat_Bots); //SC14A
               break;
            case 6:
               consoleLanguageRange_LOW_to_high(chat_Bots);//SC15A
               break;
            case 7:
               consoleLanguageRange_HIGH_to_low(chat_Bots); //SC16A
               break;
            case 0:
               System.out.println("Exiting...");
               break;
            default:
               System.out.println("Invalid choice. Please try again.");
         }
      } while (choice != 0);
        
      scanner.close();
   }
   
   private static void consoleMostComplex(List<Chat_Bots> chat_Bots) {  //SC11B
        // Your implementation for consoleMostComplex method here
      System.out.println("\n");
      System.out.println("---------Highest Complexity-----------------------------------------");
      int index = -1;
      double highestComplexity = Double.MIN_VALUE;
   
      for (int i = 0; i < chat_Bots.size(); i++) {
         Chat_Bots currentBot = chat_Bots.get(i);
         if (!currentBot.getPrimaryLanguage().startsWith("_") && currentBot.getComplexity() > highestComplexity) {
            index = i;
            highestComplexity = currentBot.getComplexity();
         }
      }
   
      if (index != -1) {
         Chat_Bots highestComplexBot = chat_Bots.get(index);
         System.out.println("Highest Complexity: " + highestComplexity + " " + highestComplexBot.getDefaultLanguages());
      } else {
         System.out.println("No chat bot with valid complexity found.");
      }
    
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLeastComplex(List<Chat_Bots> chat_Bots) { //SC12B
        // Your implementation for consoleLeastComplex method here
      System.out.println("\n");
      System.out.println("---------Lowest Complexity-----------------------------------------");
      int index = -1; 
      double leastComplexity = Double.MAX_VALUE;
   
      for (int i = 0; i < chat_Bots.size(); i++) {
         if (!chat_Bots.get(i).getPrimaryLanguage().startsWith("_") && chat_Bots.get(i).getComplexity() < leastComplexity) {
            index = i;
            leastComplexity = chat_Bots.get(i).getComplexity();
         }
      }
   
      if (index != -1) {
         System.out.println("Least Complexity: " + chat_Bots.get(index).getComplexity() + " " + chat_Bots.get(index).getDefaultLanguages());
      } else {
         System.out.println("No chat_Bots found with valid complexity.");
      }
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleComplexRange_HIGH_to_low(List<Chat_Bots> chat_Bots) { //SC13B
        // Your implementation for consoleComplexRange_HIGH_to_low method here
      System.out.println("\n");
       
      System.out.println("---------Complexity High to Low Range-----------------------------------------");
      chat_Bots.sort((o1, o2)-> o2.getComplexity().compareTo(
                      o1.getComplexity()));
      printChat_Bots(chat_Bots);
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleComplexRange_LOW_to_high(List<Chat_Bots> chat_Bots) { //SC14B
        // Your implementation for consoleComplexRange_LOW_to_high method here
      System.out.println("\n");
      System.out.println("---------Complexity Low to High Range-----------------------------------------");
      chat_Bots.sort((o1, o2)-> o1.getComplexity().compareTo(
                      o2.getComplexity()));
      printChat_Bots(chat_Bots);
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLanguageRange_LOW_to_high(List<Chat_Bots> chat_Bots) { //SC15B
        // Your implementation for consoleLanguageRange_LOW_to_high method here
      System.out.println("\n");
      System.out.println("---------Primary Language Order (Low [A] to High Range [Z])-----------------------------------------");
      chat_Bots.sort((o1, o2)-> o1.getSecondaryLanguage().compareTo(
                      o2.getSecondaryLanguage()));
      printChat_Bots(chat_Bots);
      System.out.println("----------------------------------------------------------------");
      System.out.println("\n");
   }

   private static void consoleLanguageRange_HIGH_to_low(List<Chat_Bots> chat_Bots) { //SC16B
        // Your implementation for consoleLanguageRange_HIGH_to_low method here
      System.out.println("\n");
      System.out.println("---------Primary Language Order (High [Z] to Low Range [A])-----------------------------------------");
      chat_Bots.sort((o1, o2)-> o2.getSecondaryLanguage().compareTo(
                      o1.getSecondaryLanguage()));
      printChat_Bots(chat_Bots);
   }
   /*private static void printChat_Bots(List<Chat_Bots> chat_Bots){
      int i = 1;
      for (Chat_Bots cB : chat_Bots)
      {
         System.out.println(i+") "+cB.getDefaultLanguages() + " | Token Rate: "+cB.getTokenRate()+" | Complexity: "+cB.getComplexity());
         i++;
      }
   
      
   }*/
   private static void printChat_Bots(List<Chat_Bots> chat_Bots) {
    int i = 1;
    for (Chat_Bots cB : chat_Bots) {
        System.out.print("Chat Bot " + i + ": ");
        System.out.print("Default Languages: " + cB.getDefaultLanguages() + " | ");
        System.out.print("Token Rate: " + cB.getTokenRate() + " | ");
        System.out.println("Complexity: " + cB.getComplexity());
        i++;
    }
}

}
