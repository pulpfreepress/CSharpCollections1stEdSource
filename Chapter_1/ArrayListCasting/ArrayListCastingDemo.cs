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

public class ArrayListCastingDemo {
  public static void Main(){
    ArrayList list = new ArrayList();
    list.Add(new Dog("Boxer", "Sammy", "Socks"));
    list.Add(new Dog("Golden Retriever", "Woody", "Miller"));
    list.Add(new Dog("Yellow Lab", "Austin", "Miller"));
    
    //explicitly cast each retrieved object to the Dog type
    for(int i=0; i<list.Count; i++){
      Console.WriteLine(((string)list[i]).BreedAndFullName);
    }
    
    Console.WriteLine("------------------------");
    
    //the foreach statement does the casting for you...
    foreach(Dog d in list){
      Console.WriteLine(d.BreedAndFullName);
    }
  }
}