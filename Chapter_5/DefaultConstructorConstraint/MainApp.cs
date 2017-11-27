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
    MyClass mc1 = GenericFactory<MyClass>.Instance.NewObject();
    MyClass mc2 = GenericFactory<MyClass>.Instance.NewObject();
    Console.WriteLine(mc1.PropertyOne);
    Console.WriteLine(mc2.PropertyOne);
    Console.WriteLine("----------------------------");
    mc1.PropertyOne = "A slightly different message string...";
    Console.WriteLine(mc1.PropertyOne);
    Console.WriteLine(mc2.PropertyOne);    
  }
}