/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class GenericMethodDemo {

  public T PrintValue<T, U>(T param1, U param2){
    T local_var = param1;
    Console.WriteLine("Parameter values are: param1 = " + param1 + " param2 = " + param2);
    Console.WriteLine("Local variable value is: local_var = " + local_var);
    return local_var;
  }


}