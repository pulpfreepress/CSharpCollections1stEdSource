/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public struct BitwiseTest {

  private object _objectVal;
  private int _intVal;
  
  public object ObjectVal {
    get { return _objectVal; }
    set { _objectVal = value; }
  }
  
  public int IntVal {
    get { return _intVal; }
    set { _intVal = value; }
  }
  
  

  public static void Main(){
    BitwiseTest bt1 = new BitwiseTest();
    bt1.ObjectVal = new Object();
    bt1.IntVal = 2;
    BitwiseTest bt2 = new BitwiseTest();
    bt2.ObjectVal = new Object();
    bt2.IntVal = 2;
    Console.WriteLine(bt1.Equals(bt2));
    Console.WriteLine(1.00D == 1.0D);
  }

}