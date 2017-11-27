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

public class MainApp {
  public static void Main(){
    IntArrayList list = new IntArrayList();
    
    for(int i=0; i<25; i++){
      list.Add(i);
    }
    
    for(int i=0; i<list.Count; i++){
      Console.Write(list[i] + " ");
    }
    
    Console.WriteLine();
    
    try{
      list.Add("Hello World!");
    }catch(ArgumentException ae){
      Console.WriteLine(ae);
    }
  }
}