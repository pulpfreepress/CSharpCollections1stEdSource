/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class EqualityChecker<T> where T: IComparable, IComparable<T> {

   public bool CheckEquality(T a, T b){
     bool return_val = false ;
     int result = a.CompareTo(b);
     if(result == 0){
       return_val = true;
     }
     Console.WriteLine(return_val + ": {0} is " + (return_val?"":"not ") + "equal to {1}", a, b);
     return return_val;
   }
}