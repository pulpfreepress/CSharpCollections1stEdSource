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

public class OverlapsDemo {
  public static void Main(){
   
    HashSet<int> emptySet = new HashSet<int>();
  
    HashSet<int> A = new HashSet<int>();
    A.Add(1);
    A.Add(2);
    A.Add(3);
    A.Add(4);
    
    HashSet<int> B = new HashSet<int>();
    B.Add(1);
    B.Add(2);
    B.Add(3);
    B.Add(4);
    B.Add(5);
    
    Console.Write("Empty Set Contents: ");
    foreach(int i in emptySet){
      Console.Write(i + " ");
    }
    
    Console.Write("\nSet A Contents: ");
    foreach(int i in A){
      Console.Write(i + " ");
    }
    
    Console.Write("\nSet B Contents: ");
    foreach(int i in B){
      Console.Write(i + " ");
    }
    
    Console.WriteLine("\n");
    
    Console.WriteLine("A.Overlaps(B) = " + A.Overlaps(B));
    Console.WriteLine("emptySet.Overlaps(A) = " + emptySet.Overlaps(A));
    Console.WriteLine("emptySet.Overlaps(B) = " + emptySet.Overlaps(B));
    Console.WriteLine("B.Overlaps(A) = " + B.Overlaps(A));
    
    Console.WriteLine("\nAdding the number 5 to set A...");
    A.Add(5);
    
    Console.Write("\nSet A Contents: ");
    foreach(int i in A){
      Console.Write(i + " ");
    }
    
    Console.Write("\nSet B Contents: ");
    foreach(int i in B){
      Console.Write(i + " ");
    }
    
    Console.WriteLine("\nA.Overlaps(B) = " + A.Overlaps(B));
    
    Console.WriteLine("\nAdding the number 6 to set A...");
    A.Add(6);
    
    Console.Write("\nSet A Contents: ");
    foreach(int i in A){
      Console.Write(i + " ");
    }
    
    Console.Write("\nSet B Contents: ");
    foreach(int i in B){
      Console.Write(i + " ");
    }
    
    Console.WriteLine("\nA.Overlaps(B) = " + A.Overlaps(B));
    
  }
}