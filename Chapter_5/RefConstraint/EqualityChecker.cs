/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class EqualityChecker<T> where T: class {

   public bool CheckEquality(T a, T b){
     bool result = a.Equals(b);
     Console.WriteLine( result +  ": {0} is " + (result?"":"not ") + "equal to {1}", a, b);
     return ( a.Equals(b));
   }
}