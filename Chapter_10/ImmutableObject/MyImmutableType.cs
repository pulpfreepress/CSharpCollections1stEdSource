/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MyImmutableType {
  private readonly string _stringVal;
  private readonly int _intVal;
  
  public MyImmutableType(string s, int i){
    _stringVal = s;
    _intVal = i;
  }
  
  public string StringValue {
    get { return string.Copy(_stringVal); }
  }
  
  public int IntVal {
    get { return _intVal; }
  }
  
  public override string ToString(){
    return _stringVal + " " + _intVal;
  }
}