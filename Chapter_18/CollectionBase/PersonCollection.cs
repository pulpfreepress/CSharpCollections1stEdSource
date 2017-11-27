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

public class PersonCollection : CollectionBase {

  public Person this[int index] {
    get { return (Person) List[index]; }
    set { List[index] = value; }
  }
  
  public int Add(Person value){
    return List.Add(value); // List.Add() adds value to end of list and returns its index
  }
  
  public int IndexOf(Person value){
    return List.IndexOf(value);
  }
  
  public void Insert(int index, Person value){
    List.Insert(index, value); // May throw ArgumentOutOfRange exception 
                               // if index falls outside array boundaries
  }
  
  public void Remove(Person value){
    List.Remove(value); //May throw ArgumentException if value not found
  }
  
  public bool Contains(Person value){
    return List.Contains(value); 
  }
  
  protected override void OnInsert(int index, object value){
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("object inserted at index {0} is {1}", index, value);
    Console.ForegroundColor = ConsoleColor.Gray;
  }
  
  protected override void OnRemove(int index, object value){
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("object removed from index {0} is {1}", index, value);
    Console.ForegroundColor = ConsoleColor.Gray;
  }
  
  protected override void OnSet(int index, object oldValue, object newValue){
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("object set at index {0} was {1} but is now {2}", index, oldValue, newValue);
    Console.ForegroundColor = ConsoleColor.Gray;
  }
  
  protected override void OnValidate(object value){
    if((value == null) || (value.GetType() != typeof(Person))){
      throw new ArgumentException("value must be of type Person and cannot be null!");
    }
  }
} // end class definition