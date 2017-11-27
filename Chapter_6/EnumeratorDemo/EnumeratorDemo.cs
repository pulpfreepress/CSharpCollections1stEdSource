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

public class EnumeratorDemo {

  public static void Main(){
    ArrayList list = new ArrayList();
    list.Add(1);
    list.Add(2);
    list.Add(3);
    list.Add(4);
    
    // Iterating over the list in the manner of old habits
    for(int i = 0; i<list.Count; i++){
      Console.Write(i + " ");
    }
    Console.WriteLine();
    
    // Iterating over the list whilst ignoring the messy details
    foreach(int i in list){
      Console.Write(i + " ");
    }
    Console.WriteLine();
    
    // Iterating over a list segment using overloaded GetEnumerator( ) method 
    // and directly manipulating the IEnumerator object via  IEnumerator.MoveNext() 
    IEnumerator e = list.GetEnumerator(1, 2);
    while(e.MoveNext()){
      Console.Write(e.Current + " ");
    }    
  }
}