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

public class ArrayListDemo {
  public static void Main(){
    ArrayList list = new ArrayList();
    
    //Add various types of objects to the ArrayList
    list.Add("Baba Beaton");
    list.Add(1);
    list.Add(new Dog("Boxer", "Sammy", "Socks"));
    
    //Access each object in the collection and print out its value
    foreach(object o in list){
      Console.WriteLine(o);
    }
  }
}