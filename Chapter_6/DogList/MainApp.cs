/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
  public static void Main(){
    DogList list = new DogList();
    list.Add(new Dog("Mutt", "Skippy", "Jones"));
    list.Add(new Dog("French Poodle", "Bijou", "Jolie"));
    list.Add(new Dog("Yellow Lab", "Schmoogle", "Miller"));
    list.Add(new Dog("Mutt Lab", "Dippy", "Miller"));
    
    for(int i = 0; i < list.Count; i++){
      Console.WriteLine(list[i]);
    }
    
    Console.WriteLine("-------------------------------");
    list.Sort();
    
    foreach(Dog d in list){
      Console.WriteLine(d);
    }
    
    Console.WriteLine("-------------------------------");
    list.Reverse();
    
    foreach(Dog d in list){
      Console.WriteLine(d);
    }
  }
}