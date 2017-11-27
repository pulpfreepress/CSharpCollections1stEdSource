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

public class ArrayListDemo {
  public static void Main(){
    ArrayList list = new ArrayList();
    
    //Add elements using the Add() method
    list.Add("Hope Mesa");
    list.Add("Bill Hicks");
    list.Add("Secret Miller");
    list.Add("Alex Remily");
    list.Add("Pete Luongo");
    
    //access elements using array indexer notation
    for(int i=0; i<list.Count; i++){
      Console.WriteLine(list[i]);
    }
    
    Console.WriteLine("------------------------------");
    
    //or, use the foreach statement which hides the complexity of the enumerator
    foreach(string s in list){
      Console.WriteLine(s);
    }
  }
}