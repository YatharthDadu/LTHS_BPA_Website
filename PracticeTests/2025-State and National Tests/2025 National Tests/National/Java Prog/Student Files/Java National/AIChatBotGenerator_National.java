
import java.io.FileNotFoundException;
import java.io.File;
import java.io.*;
import java.util.*; 
import java.text.DecimalFormat;
import java.util.List;
import java.util.Scanner;


public class AIChatBotGenerator_National 
{
      
   public static void main (String args [])
   {
     
                    
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
         chat_Bots.add(s); //HINT Make an array list object called chat_Bots
      }
      
   }
 
 
      
      
   private static Chat_Bots readChatBotPremadeFrameworks(BufferedReader in) 
   {
     
   }

 
 
   public static void readChatBotLanguages()throws IOException
   {
      
            
   }
  
    
   private static BufferedReader getReader(String language)	
   {
     
     
   }

}


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