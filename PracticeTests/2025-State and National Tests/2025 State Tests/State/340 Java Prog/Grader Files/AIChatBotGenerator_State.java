
import java.io.FileNotFoundException;
import java.io.File;
import java.util.*; 
import java.text.DecimalFormat;

public class AIChatBotGenerator_State
{
   
   static Scanner sc = new Scanner(System.in);  //SC2
   static ArrayList<ChatBots> chat_Bots = new ArrayList<ChatBots>(); //SC2
   public static void main (String args [])
   {
      
   
      inputManager(); //Given
     
      printChatBots();
      printHighestComplexity(); //Given
      printLowestComplexity(); //Given
      searchByLanguage();
   }
  
   
   
   //ChatBots will create. Signature only
   private static void printHighestComplexity() //ArrayList<ChatBots> stuList
   {
      int index = 0; 
      double number = 0;
   
      for(int i = 1; i < chat_Bots.size(); i++)
      {
         if(chat_Bots.get(i).getComplexity()>chat_Bots.get(index).getComplexity()) //SC3
         {
            index = i;
            number = chat_Bots.get(i).getComplexity();
         
         }
      
      }
      System.out.println("\n\nMost Expensive Complexity Rate: "+ chat_Bots.get(index).getComplexity()+ " "+chat_Bots.get(index).getSupportedLanguages());
   }
      
   //STATE POINT
   //ChatBots will create. Signature only         
   private static void printLowestComplexity() 
   {
      int index = 0; 
      double number = 0;
   
      for(int i = 1; i < chat_Bots.size(); i++)
      {
         if(chat_Bots.get(i).getComplexity()<chat_Bots.get(index).getComplexity()) //SC4
         {
            index = i;
            number = chat_Bots.get(i).getComplexity();
         
         }
      
      }
      System.out.println("\n\nLeast Expensive Complexity Rate: "+ chat_Bots.get(index).getComplexity()+ " "+chat_Bots.get(index).getSupportedLanguages());
   }

    //Given  
   private static void setChatBots(int bC)
   {
      Random random = new Random();
      ChatBots cB;
      DecimalFormat df = new DecimalFormat("#.0000");
      int botCount = bC;
      double complexity;
      int token_Rate;
      String native_Language; String secondary_Language;
      
      String [] supportedLanguages ={"English", "French", "Chinese", "Spanish", "Arabic", "Russian", "German", "Japanese", "Portuguese", "Hindi", "Italian", "Dutch", "Korean", "Turkish", "Vietnamese", "Swedish", "Polish", "Indonesian", "Greek", "Hebrew", "Thai", "Czech", "Romanian", "Hungarian", "Finnish"};
          
      for(int i =0; i<botCount; i++)
      {
         
         do{
         
            native_Language = supportedLanguages[random.nextInt(supportedLanguages.length)];
            secondary_Language = supportedLanguages[random.nextInt(supportedLanguages.length)];
         }while(native_Language.equals(secondary_Language));
         token_Rate = random.nextInt(16)+5;
         double tempComplexity = random.nextDouble()*7.1 + 2.0;
         if(tempComplexity > 9.0) tempComplexity = Math.floor(tempComplexity);
         String  tempString =df.format(tempComplexity);
         complexity = Double.parseDouble(tempString);
         cB = new ChatBots(native_Language,secondary_Language,token_Rate,complexity);
         chat_Bots.add(cB);
      }
      
   }
   
   //Given 
   /*  
   private static void printChatBots(){
      int i = 1;
      for (ChatBots c : chat_Bots)
      {
         System.out.println(i+") "+c.getSupportedLanguages() + " | Token Rate: "+c.getTokenRate()+" | Complexity: "+c.getComplexity());
         i++;
      }
   
      printHighestComplexity(); 
      printLowestComplexity();
   }
   */
   private static void printChatBots() {   //SC11
    System.out.println("-----------------------------------------------------------------------------");
    System.out.printf("| %-4s | %-30s | %-10s | %-10s |\n", "No.", "Supported Languages", "Token Rate", "Complexity"); //SC11
    System.out.println("-----------------------------------------------------------------------------");
    int i = 1;
    for (ChatBots c : chat_Bots) {
        System.out.printf("| %-4d | %-30s | %-10d | %-10.4f |\n", i, c.getSupportedLanguages(), c.getTokenRate(), c.getComplexity());  //SC11
        i++;
    }
    System.out.println("-----------------------------------------------------------------------------");

    printHighestComplexity();
    printLowestComplexity();
}
   
        
   private static void inputManager()
   {
      int temp =0;
      int token_Rate =0; 
      double complexity =0.0;
      String native_Language;
      String secondary_Language;
      String  tempString;
      ChatBots cB;
      DecimalFormat df = new DecimalFormat("#.0000"); //SC9
      
      
      while(true){   
         try{    //SC5
            do{
               temp =0;
               System.out.println("______________________________________________________________________");
               System.out.println("Welcome to the BPA Chatbot Generator. Choose one of the options:");
               System.out.println("Press [1] to create random chatbots OR Press [2] to create a single chatbot \nOR Press [3] to search by language OR Press [4] to end the program");
               temp = sc.nextInt();
               if(temp <= 0 || temp > 4) System.out.println("Your entry is out of range."); //SC5
               sc.nextLine();
            } while(temp <= 0 || temp > 4);
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
               setChatBots(temp);
               temp =0;
               System.out.println("______________________________________________________________________");
               printChatBots();
            }
            if(temp ==2){
               
               System.out.println("You are now creating a single chatbot");
               System.out.println("Enter in the native language");
               native_Language = sc.nextLine().toLowerCase();
               
               System.out.println("Enter in the secondary language");
               secondary_Language = sc.nextLine().toLowerCase();
               do{
                  try{   //SC7
                     do{
                        System.out.println("Enter the token rate value (5 to 20): ");
                        token_Rate = sc.nextInt();
                        if(token_Rate >20 || token_Rate <5) System.out.println("Your entry is out of range."); //SC7
                     }while(token_Rate >20 || token_Rate <5);
                  }
                  catch(InputMismatchException e) //SC7
                  {
                     sc.next();
                     System.out.println("\nERROR: Please enter valid data type.");
                  }
               }while(token_Rate >20 || token_Rate <5);
               do{
                  try{ //SC8
                     do{
                        System.out.println("Enter in the toke complexity in its proper format (#.####) in a range of 2.0 to 9.0");
                        complexity = sc.nextDouble();
                        tempString =df.format(complexity); //SC9
                        complexity = Double.parseDouble(tempString);
                        if(complexity>9.0 || complexity < 2.0) System.out.println("Your entry is out of range."); //SC8
                     }while(complexity>9.0 || complexity < 2.0);
                  }
                  catch(InputMismatchException e) //SC8
                  {
                     sc.next();
                     System.out.println("\nERROR: Please enter valid data type.");
                  }
               }while(complexity>4.0 || complexity <= 0.0);
               native_Language = native_Language.substring(0,1).toUpperCase() + native_Language.substring(1).toLowerCase(); //SC10
               secondary_Language = secondary_Language.substring(0,1).toUpperCase() + secondary_Language.substring(1).toLowerCase(); //SC10
               cB = new ChatBots(native_Language,secondary_Language,token_Rate,complexity);
               chat_Bots.add(cB);
               System.out.println("______________________________________________________________________");
               printChatBots();
            }
            if(temp ==3 ){
               if (chat_Bots.size()==0){
                  System.out.println("You must create chatbots first.");
               } else {searchByLanguage();}
                              
            } 
            
            if(temp == 4){
               System.out.println("Goodbye!");
               System.exit(0); 
            }
         }
         catch(InputMismatchException e) //SC5
         {
            sc.next();
            System.out.println("\nERROR: Please enter valid data type.");
         }
      }
      
   }  
   private static void searchByLanguage() {
      System.out.println("Enter the language you want to search for:");
      String searchLanguage = sc.nextLine().toLowerCase();
    
      boolean found = false;
      for (ChatBots bot : chat_Bots) {
         if (bot.getSupportedLanguages().toLowerCase().contains(searchLanguage)) {
            System.out.println("Chatbot found: " + bot.getSupportedLanguages() + " | Token Rate: " + bot.getTokenRate() + " | Complexity: " + bot.getComplexity());
            found = true;
         }
      }
    
      if (!found) {
         System.out.println("No chatbot found for the specified language.");
      }
   }

}

 //SC1
class ChatBots
{
   //Create appropriately variables based upon constructor parameters
   String native_Language;
   String secondary_Language;
   int token_Rate;
   double complexity;
    //Generic Constructor  
   public ChatBots()
   {
      native_Language = "Esparanto";
      secondary_Language =  "Java";
      token_Rate = 0;
      complexity = 0.0;
   }
    //Constructor with Parameters
   public ChatBots(String nL, String sL, int tR, double co)
   {
      native_Language = nL;
      secondary_Language =  sL;
      token_Rate = tR;
      complexity = co;
   }
      
    //Returns "last name, first name" with appropriate variables
   public String getSupportedLanguages()
   {
      return secondary_Language + ", "+native_Language;
   }
    //Returns first name
   public String getNativeLanguage()
   {
      return native_Language;
   }
    //Returns last name  
   public String getSecondaryLanguage()
   {
      return secondary_Language;
   }
   //Returns the Complexity   
   public double getComplexity()
   {
      return complexity;
   }
    //Returns token_Rate level  
   public int getTokenRate()
   {
      return token_Rate;
   }
    

}