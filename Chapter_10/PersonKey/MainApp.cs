/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;


public class MainApp {
  public static void Main(){
    Person p1 = new Person("Rick", "Warren", "Miller", Person.Sex.MALE, new DateTime(1961, 2, 3), Guid.NewGuid());
    Person p2 = new Person("Steve", "Jacob", "Hester", Person.Sex.MALE, new DateTime(1972, 1, 1), Guid.NewGuid());
    Person p3 = new Person("Coralie", "Sylvia", "Miller", Person.Sex.FEMALE, new DateTime(1974, 8, 8), Guid.NewGuid());
    Person p4 = new Person("Katherine", "Sport", "Reid", Person.Sex.FEMALE, new DateTime(1970, 5, 6), Guid.NewGuid());
    Person p5 = new Person("Kathleen", "KayakKat", "McMamee", Person.Sex.FEMALE, new DateTime(1983, 2, 3), Guid.NewGuid());
    Person p6 = new Person("Kyle", "Victor", "Miller", Person.Sex.MALE, new DateTime(1986, 10, 15), Guid.NewGuid());
    
    Dictionary<PersonKey, Person> directory = new Dictionary<PersonKey, Person>();
    directory.Add(p1.Key, p1);
    directory.Add(p2.Key, p2);
    directory.Add(p3.Key, p3);
    directory.Add(p4.Key, p4);
    directory.Add(p5.Key, p5);
    directory.Add(p6.Key, p6);
    
    foreach(KeyValuePair<PersonKey, Person> kvp in directory){
      Console.WriteLine("Key: {0} Value: {1}", kvp.Key, kvp.Value.FullName);
    }
    
  }
}