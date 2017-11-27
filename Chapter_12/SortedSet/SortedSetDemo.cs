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

public class SortedSetDemo {
  public static void Main(){
    SortedSet<int> ss = new SortedSet<int>();
    List<int> list = new List<int>();
    
    ss.Add(1);
    ss.Add(2);
    ss.Add(3);
    ss.Add(4);
    
    list.Add(4);
    list.Add(5);
    
    Console.WriteLine("Overlaps = " + ss.Overlaps(list));
    ss.IntersectWith(list);
    
    foreach(int i in ss){
      Console.Write(i + " ");
    }
  }
}