/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

public class SimpleClass {

  private string _field1 = "Hello World";

  // default constructor generated by compiler
  
  public string PropertyOne {
    get { return _field1; }
    set { _field1 = value; }
  }
}