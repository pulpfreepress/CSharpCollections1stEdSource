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

public class ListManipulationDemo {
  public static void Main(){
    List<String> list = new List<String>();
    
    //Add elements using the Add() method
    list.Add("Hope Mesa");
    list.Add("Bill Hicks");
    list.Add("Secret Miller");
    list.Add("Alex Remily");
    list.Add("Pete Luongo");
    
    //Access elements using array indexer notation
    for(int i=0; i<list.Count; i++){
      Console.WriteLine(list[i]);
    }
    
    Console.WriteLine("------------------------------");
    
    //Sort the list using the natural ordering of the String class
    list.Sort();
   
    //Print the sorted list to the console
    foreach(string s in list){
      Console.WriteLine(s);
    }
    
     Console.WriteLine("------------------------------");
     
     //Search the list for a specific string
     Console.WriteLine("The string \"Hope Mesa\" is located at index number " + list.BinarySearch("Hope Mesa") + " in the list.");
     
     Console.WriteLine("------------------------------");
     
     //Now, reverse the list
     list.Reverse();
     
     //Print the reversed list to the console
    foreach(string s in list){
      Console.WriteLine(s);
    }
    
  }
}