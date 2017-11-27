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
    Person p1 = new Person("Rick", "Warren", "Miller", Person.Sex.MALE, 
                          new DateTime(1961, 2, 3), Guid.NewGuid());
    Console.WriteLine("p1.Equals(p1) : {0}", p1.Equals(p1));
    Console.WriteLine("p1.Equals(string) : {0}", p1.Equals("Hello!"));
    Person p2 = new Person("Steve", "Jacob", "Hester", Person.Sex.MALE, 
                          new DateTime(1972, 1, 1), Guid.NewGuid());
    Console.WriteLine("p1.Equals(p2) : {0}", p1.Equals(p2));
    Console.WriteLine("p2.Equals(p1) : {0}", p2.Equals(p1));
    Console.WriteLine("p1.GetHashCode() = {0}", p1.GetHashCode());
    Console.WriteLine("p2.GetHashCode() = {0}", p2.GetHashCode());
    Console.WriteLine("p1 == p1 : {0}", p1 == p1);
    Console.WriteLine("p1 == p2 : {0}", p1 == p2);
    Console.WriteLine("p1 != p1 : {0}", p1 != p1);
    Console.WriteLine("p1 != p2 : {0}", p1 != p2);
  }
}