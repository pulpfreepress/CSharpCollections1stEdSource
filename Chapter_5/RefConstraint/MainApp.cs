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
    EqualityChecker<string> eq1 = new EqualityChecker<string>();
    eq1.CheckEquality("Hello", "Hello");
    eq1.CheckEquality("Hello", "World");
    Console.WriteLine("------------------------------------");
    EqualityChecker<MyClass> eq2 = new EqualityChecker<MyClass>();
    eq2.CheckEquality(new MyClass(5), new MyClass(5));
  }
}