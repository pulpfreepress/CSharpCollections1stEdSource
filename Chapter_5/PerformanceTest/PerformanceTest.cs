/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;
using System.Collections.Generic;

public class PerformanceTestOne {
  public static void Main(){
    ArrayList list = new ArrayList();
    List<int> generic_list = new List<int>();
    int NUMBER = 1000000;
    
    Console.WriteLine("Adding {0:N0} integers to lists", NUMBER);
    Console.WriteLine("---------------------------------");
    Random random = new Random();
    for(int i=0; i<NUMBER; i++){
      int temp = random.Next();
      list.Add(temp);
      generic_list.Add(temp);
      
    }
    DateTime start = DateTime.Now;
    Console.WriteLine("Sorting ArrayList -> Start time: " + start);
    list.Sort();
    TimeSpan array_list_elapsed_time = (DateTime.Now - start);
    Console.WriteLine("ArrayList sorted in: " + array_list_elapsed_time);
    
    Console.WriteLine("-----------------------------------");
    
    start = DateTime.Now;
    Console.WriteLine("Sorting List<int> -> Start time: " + start);
    generic_list.Sort();
    TimeSpan list_elapsed_time = (DateTime.Now - start);
    Console.WriteLine("ArrayList sorted in: " + list_elapsed_time);
    
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("Time difference: " + (array_list_elapsed_time - list_elapsed_time));
  }
 }
