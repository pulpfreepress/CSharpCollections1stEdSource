/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;


using System.Collections.Specialized;


public class HybridDictionaryDemo  {
  public static void Main(){
    HybridDictionary hd = new HybridDictionary();
	hd.Add("Rick", "Aquarius: The time is right to travel! Stay receptive, " +
           "new opportunities will present themselves.");
	hd.Add("Coralie", "Aries: Move forward with your big plans! The time is right to stike.");
	hd.Add("Kyle", "Leo: Your mind's made up! Don't procrastinate.");
	hd.Add("Tati", "Sagittarius: Finish college before it's too late!");
    hd.Add("Sport", "Gemini: Take charge! Ask him to marry you!");
    hd.Add("John", "Gemini: Surrender yourself! Say yes when a beautiful woman asks you to marry her!");
	
	Console.WriteLine("Name \t\t Horoscope");
    Console.WriteLine("------------------------");
	

   foreach(string s in hd.Keys){
    Console.WriteLine(s + "\t\t" + hd[s]);
   }   

  } // end Main()
} // end class definition