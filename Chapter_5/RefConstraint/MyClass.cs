/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

public class MyClass {
  private int _field;
  
  public MyClass():this(0){ }
  
  public MyClass(int val){
    _field = val;
  }
 
  public int Value {
     get { return _field; }
     set { _field = value; }
  }
}
