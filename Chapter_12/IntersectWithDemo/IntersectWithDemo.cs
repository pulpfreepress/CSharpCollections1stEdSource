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

public class IntersectWithDemo {
  public static void Main(){
    HashSet<int> hs = new HashSet<int>();
    List<int> list = new List<int>();
    
    hs.Add(1);
    hs.Add(2);
    hs.Add(3);
    hs.Add(4);
    
    list.Add(4);
    list.Add(5);
    
    Console.WriteLine("Before intersection...");
    Console.Write("The items in HashSet include: ");
    foreach(int i in hs){
      Console.Write(i + " ");
    }
    Console.Write("\nThe items in List include: ");
    foreach(int i in list){
      Console.Write(i + " ");
    }
    Console.WriteLine("\nAfter intersection...");
    
    hs.IntersectWith(list);
    
    Console.Write("The items in HashSet include: ");
    foreach(int i in hs){
      Console.Write(i + " ");
    }
    
    
  }
}