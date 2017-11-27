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
    GenericMethodDemo gmd = new GenericMethodDemo();
    gmd.PrintValue<string, int>("Hello World", 4); // explicit type arguments
    Console.WriteLine("---------------------------");
    gmd.PrintValue(125.25, 62); //using generic type inference
  }
}