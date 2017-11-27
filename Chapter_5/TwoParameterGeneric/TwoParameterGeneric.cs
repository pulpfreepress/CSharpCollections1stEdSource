/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class TwoParameterGeneric<T, U> {
  
  //fields
  private T _field1;
  private U _field2;
  
  //constructors
  public TwoParameterGeneric(T arg1, U arg2){
    _field1 = arg1;
    _field2 = arg2;
  }
  
  private TwoParameterGeneric(){
    // effectively disable the default constructor
  }
  
  //properties
  public T PropertyOne {
    get { return _field1; }
    set { _field1 = value; }
  }
  
  public U PropertyTwo {
    get { return _field2; }
    set { _field2 = value; }
  }
  
  public U PrintValue(){
    Console.WriteLine("T is a " + (_field1.GetType()).ToString() + " with value: " + _field1);
    Console.WriteLine("U is a " + (_field2.GetType()).ToString() + " with value: " + _field2);
    return _field2;
  }
  
  
}