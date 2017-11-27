/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.Linq;

public class DictionaryDemo {

   public static void Main(){
     Dictionary<string, int> names_and_ages = new Dictionary<string, int>();
     names_and_ages.Add("Rick", 49);
     names_and_ages.Add("Kyle", 23);
     names_and_ages.Add("Sport", 39);
     names_and_ages.Add("Coralie", 39);
     names_and_ages.Add("Tati", 21);
     names_and_ages.Add("Schmoogle", 7);
     
     foreach(KeyValuePair<string, int> entry in names_and_ages){
       Console.WriteLine("{0} is {1} years old!", entry.Key, entry.Value);
     }
     
     Console.WriteLine("The average age is {0:F4}", names_and_ages.Values.Average());
   
   } //  end Main() method
} // end DictionaryDemo class