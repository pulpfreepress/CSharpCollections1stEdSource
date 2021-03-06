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

public class MainApp {
  public static void Main(){
    PersonCollection pc = new PersonCollection();
    Person p1 = new Person("Deekster", "Willis", "Jaybones", Person.Sex.MALE, new DateTime(1966, 02, 19));
    Person p2 = new Person("Knut", "J", "Hampson", Person.Sex.MALE, new DateTime(1972, 04, 23));
    Person p3 = new Person("Katrina", "Kataline", "Kobashar", Person.Sex.FEMALE, new DateTime(1982, 09, 3));
    Person p4 = new Person("Dreya", "Babe", "Weber", Person.Sex.FEMALE, new DateTime(1978, 11, 25));
    Person p5 = new Person("Sam", "\"The Guitar Man\"", "Miller", Person.Sex.MALE, 
                           new DateTime(1988, 04, 16));
    Console.WriteLine("-------- Test the Add() method ---------------------------");
    pc.Add(p1);
    pc.Add(p2);
    pc.Add(p3);
    
    foreach(Person p in pc){
      Console.WriteLine(p.FullName);
    }
    
    Console.WriteLine("----- Remove: {0} ----------------------", p1.FullName);
    pc.Remove(p1);
    
    foreach(Person p in pc){
      Console.WriteLine(p.FullName);
    }
    
    Console.WriteLine("---------- Add another person ---------------");
    pc.Add(p4);
    
    foreach(Person p in pc){
      Console.WriteLine(p.FullName);
    }
    
    Console.WriteLine("--------- Test the indexer read -------------------------------");
    Console.WriteLine(pc[1].FullName);
    Console.WriteLine("--------- Test the indexer write -------------------------------");
    
    pc[0] = new Person("Slate", "Bo", "Hopkins", Person.Sex.MALE, new DateTime(1922, 05, 27));
    
    foreach(Person p in pc){
      Console.WriteLine(p.FullName);
    }
    
    Console.WriteLine("--------- Test the Insert() method -------------------------------");
    
    pc.Insert(0, p5);
    
    foreach(Person p in pc){
      Console.WriteLine(p.FullName);
    }
    
    Console.WriteLine("--------- Test the OnValidate() method -------------------------------");
    
    try {
      pc.Add(null);
    }catch(ArgumentException){
      Console.WriteLine("Exception thrown attempting to add null value!");
    }
  } // end Main() 
} // end class definition