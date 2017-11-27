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

public class ListExtensionMethodsDemo {

  private static void PrintList(List<int> list){
    for(int i=1; i<list.Count + 1; i++){
      if((i%10) > 0){
         Console.Write(list[i-1] + "\t");
      }else{
         Console.WriteLine(list[i-1] );
       }
     }
    Console.WriteLine();
  }

  public static void Main(){
    List<int> list = new List<int>();
    Random random = new Random();
    
    for(int i=0; i<50; i++){
      list.Add(random.Next(0, 1000));
    }
  
    ListExtensionMethodsDemo.PrintList(list);
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("The sum of the list elements is: " + list.Sum());
    Console.WriteLine("The average of the list elements is: " + list.Average());
    Console.WriteLine("The maximum element value is: " + list.Max());
    Console.WriteLine("The minimum element value is: " + list.Min());
    Console.WriteLine("-----------------------------------");
    list.Sort();
    ListExtensionMethodsDemo.PrintList(list);
    
  
  }
}