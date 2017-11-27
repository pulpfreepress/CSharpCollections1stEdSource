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
    SortedDictionary<PersonKey, Person> _people = new SortedDictionary<PersonKey, Person>();
    
   Person p1 = new Person("Rick", "Warren", "Miller", Person.Sex.MALE, new DateTime(1961, 2, 3), Guid.NewGuid());
    Person p2 = new Person("Steve", "Jacob", "Hester", Person.Sex.MALE, new DateTime(1972, 1, 1), Guid.NewGuid());
    Person p3 = new Person("Coralie", "Sylvia", "Miller", Person.Sex.FEMALE, new DateTime(1974, 8, 8), Guid.NewGuid());
    Person p4 = new Person("Katherine", "Sport", "Reid", Person.Sex.FEMALE, new DateTime(1970, 5, 6), Guid.NewGuid());
    Person p5 = new Person("Kathleen", "KayakKat", "McMamee", Person.Sex.FEMALE, new DateTime(1983, 2, 3), Guid.NewGuid());
    Person p6 = new Person("Kyle", "Victor", "Miller", Person.Sex.MALE, new DateTime(1986, 10, 15), Guid.NewGuid());
    
    _people.Add(p1.Key, p1);
    _people.Add(p2.Key, p2);
    _people.Add(p3.Key, p3);
    _people.Add(p4.Key, p4);
    _people.Add(p5.Key, p5);
    _people.Add(p6.Key, p6);
    
    
    Console.WriteLine("----- Ordered upon insertion by comparing PersonKeys ------");
    foreach(KeyValuePair<PersonKey, Person> kvp in _people){
      Console.WriteLine(kvp.Value);
    }
    
    
    Console.WriteLine("----- Ordered by age with PersonAgeComparer object ------");
    
    SortedDictionary<Person, Person> _peopleByAge = 
                                       new SortedDictionary<Person, Person>(new PersonAgeComparer());
    
    _peopleByAge.Add(p1, p1);
    _peopleByAge.Add(p2, p2);
    _peopleByAge.Add(p3, p3);
    _peopleByAge.Add(p4, p4);
    _peopleByAge.Add(p5, p5);
    _peopleByAge.Add(p6, p6);
    
    foreach(KeyValuePair<Person, Person> kvp in _peopleByAge){
      Console.WriteLine(kvp.Value);
    }
    
    
  }
}