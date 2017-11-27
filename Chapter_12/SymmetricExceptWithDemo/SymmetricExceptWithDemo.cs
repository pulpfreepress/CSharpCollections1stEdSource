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

public class SymmetricExceptWithDemo {
  public static void Main(){
    HashSet<int> A = new HashSet<int>();
    A.Add(1);
    A.Add(2);
    A.Add(3);
    
    HashSet<int> B = new HashSet<int>();
    B.Add(2);
    B.Add(3);
    B.Add(4);
    B.Add(5);
    
    Console.Write("Contents of set A: ");
    foreach(int i in A){
      Console.Write(i + " ");
    }
    
    Console.Write("\nContents of set B: ");
    foreach(int i in B){
      Console.Write(i + " ");
    }
    
    A.SymmetricExceptWith(B);
    
    Console.Write("\nContents of A after A.SymmetricExceptWith(B) = ");
    foreach(int i in A){
      Console.Write(i + " ");
    }
    
    
    
  }
}