/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;
using System.Collections.Generic;

public class PersonAgeComparer : IComparer, IComparer<Person> {

  public int Compare(object x, object y){
    if((x == null) || (y == null) || (typeof(Person) != x.GetType()) || (typeof(Person) != y.GetType())){
      throw new ArgumentException("Both objects must be of type Person!");
    }
    
    return ((Person)x).Age.CompareTo(((Person)y).Age);
  }
  
  public int Compare(Person x, Person y){
   if((x == null) || (y == null)){
      throw new ArgumentException("Both objects must be of type Person!");
    }
    
    return x.Age.CompareTo(y.Age);
  }
 
}