
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;
import java.util.List;
import java.util.Scanner;


public class AIChatBotGenerator_National 
{
   //National Point
   static Scanner sc = new Scanner(System.in); 
   static ArrayList<Chat_Bots> chat_Bots = new ArrayList<Chat_Bots>(); //SC2
   static ArrayList<String> languagesComplete = new ArrayList<String>();//SC1
   
   public static void main (String args [])
   {
      //National Point to use BufferedReader to read this file
      BufferedReader in = getReader("ExperimentalLanguageBots.txt");//SC3
      
      Chat_Bots cB = readChatBotPremadeFrameworks(in); //SC3
      
      chat_Bots.add(cB);
      while (cB != null)	
      {
         cB = readChatBotPremadeFrameworks(in);//SC3
         if(cB != null)
            chat_Bots.add(cB);
      }
      //National Point to use Scanner to read this file. Use Try/Catch is points
      try{   //SC10
         readChatBotLanguages();
      
      } catch (IOException e){
         System.out.print("Error reading file Supported_Languages.txt");
      }
   
      setChat_Bots(10); //Given
      ChatBotReporter.chatBotReporter(chat_Bots); 
               
   }
   
   
   
          
    //Given
   private static void setChat_Bots(int cB)
   {
      Random rand = new Random();
      Chat_Bots s;
     
      DecimalFormat df = new DecimalFormat("#.0000");
      int languageCount = cB;
      double complexity;
      int tokenRate;
      String primaryLanguage; String secondaryLanguage;
   
      for(int i =0; i<languageCount; i++)
      {
         
         do{
         
            primaryLanguage = languagesComplete.get(rand.nextInt(languagesComplete.size()));
            secondaryLanguage = languagesComplete.get(rand.nextInt(languagesComplete.size()));
         }while(primaryLanguage.equals(secondaryLanguage));
         tokenRate = rand.nextInt(10)+11;
         double tempComplexity = rand.nextDouble()*10.0 + 1.0;
         String  tempString =df.format(tempComplexity);
         complexity = Double.parseDouble(tempString);
         s = new Chat_Bots(primaryLanguage,secondaryLanguage,tokenRate,complexity);
         chat_Bots.add(s);
      }
      
   }
 
 
      
      //National Points 
    ////////////////////////NATIONAL METHOD//////////////////////
   private static Chat_Bots readChatBotPremadeFrameworks(BufferedReader in) 
   {
      Chat_Bots cB;
      String primaryLanguage; String secondaryLanguage; int tokenRate; Double complexity; 
      String line =""; 
      String[] data; 
    
      //catches errors in the read but not required since test files will not be corrupted
      try
      {
         line = in.readLine(); //SC4
        
      }
      catch (IOException e)
      {
         System.out.println("I/O Error");
         System.exit(0);
      }
      
      //ends the read once it gets to the end
      if (line == null){
         
         return null;   
      }
      else
      { 
         data = line.split(","); //SC5A //"," is the delimeter to seperate the fields for the records
         primaryLanguage = data[0].trim();
         secondaryLanguage = data[1].trim(); 
         tokenRate = Integer.parseInt(data[2].trim());  //SC5B
         complexity = Double.parseDouble(data[3]); //SC5C
         
      }
      cB = new Chat_Bots(primaryLanguage,secondaryLanguage,tokenRate,complexity);
   
      return cB;
   }

  //National Points
 //use this method for Nationals. Must use Scanner and throws IOException (part of the points)
   public static void readChatBotLanguages()throws IOException
   {
      Scanner sc2 = new Scanner(new File("Supported_Languages.txt"));  //SC7
      sc2.useDelimiter(",");  //SC8
      
      while(sc2.hasNext())//SC8
      {
         String tempLanguage = sc2.next().trim(); //SC9
         languagesComplete.add(tempLanguage);
      }
      
   }
  //National Points    
   private static BufferedReader getReader(String language)	
   {
      BufferedReader in = null;
      try  //SC6
      {
         File file = new File(language);
         in = new BufferedReader(
            new FileReader(file) );
      }
      catch (FileNotFoundException e) //SC6
      {
         System.out.println(
            "The ExperimentalLanguageBots.txt file doesn't exist.");
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
class Chat_Bots
{
   String primaryLanguage;
   String secondaryLanguage;
   int tokenRate_Level;
   double complexity;
         
   public Chat_Bots()
   {
      primaryLanguage = "Esperanto";
      secondaryLanguage =  "Java";
      tokenRate_Level = 0;
      complexity = 0.0;
   }
   
   public Chat_Bots(String primaryLanguage, String secondaryLanguage, int tR, double complexity)
   {
      this.primaryLanguage = primaryLanguage;
      this.secondaryLanguage =  secondaryLanguage;
      this.tokenRate_Level = tR;
      this.complexity = complexity;
   }
      

   public String getDefaultLanguages()
   {
      return secondaryLanguage + ", "+primaryLanguage;
   }
         
   public String getPrimaryLanguage()
   {
      return primaryLanguage;
   }
         
   public String getSecondaryLanguage()
   {
      return secondaryLanguage;
   }
     //Using an ArrayList Sort requires a Double wrapper    
   public Double getComplexity()
   {
      return (Double)complexity;
   }
         
   public int getTokenRate()
   {
      return tokenRate_Level;
   }

      
}