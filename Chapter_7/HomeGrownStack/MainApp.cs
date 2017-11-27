/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
  public static void Main(){
    HomeGrownStack stack = new HomeGrownStack();
    for(int i = 0; i < 37; i++){
      stack.Push(i);
    }
    
    for(int i = 0; i < 37; i++){
      Console.Write(stack.Pop() + " ");
    }
    Console.WriteLine();
    
    // try one more Pop operation
    try{
      stack.Pop();
     }catch(Exception e){
       Console.WriteLine(e);
     }
    
  }
}