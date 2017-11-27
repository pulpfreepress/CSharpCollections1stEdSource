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
    Person p1 = new Person("Rick", "Warren", "Miller", Person.Sex.MALE, new DateTime(1961, 2, 3), Guid.NewGuid());
    Person p2 = new Person("Steve", "Jacob", "Hester", Person.Sex.MALE, new DateTime(1972, 1, 1), Guid.NewGuid());
    Person p3 = new Person("Coralie", "Sylvia", "Miller", Person.Sex.FEMALE, new DateTime(1974, 8, 8), Guid.NewGuid());
    Person p4 = new Person("Katherine", "Sport", "Reid", Person.Sex.FEMALE, new DateTime(1970, 5, 6), Guid.NewGuid());
    Person p5 = new Person("Kathleen", "KayakKat", "McMamee", Person.Sex.FEMALE, new DateTime(1983, 2, 3), Guid.NewGuid());
    Person p6 = new Person("Kyle", "Victor", "Miller", Person.Sex.MALE, new DateTime(1986, 10, 15), Guid.NewGuid());
    
    Person[] people_array = new Person[6];
    people_array[0] = p1;
    people_array[1] = p2;
    people_array[2] = p3;
    people_array[3] = p4;
    people_array[4] = p5;
    people_array[5] = p6;
    
    Console.WriteLine("-------- Before Sorting ------------");
    
    foreach(Person p in people_array){
      Console.WriteLine(p.FullNameAndAge);
    }
    
    Array.Sort(people_array, new PersonAgeComparer());
    
    Console.WriteLine("-------- After Sorting ------------");
    
    foreach(Person p in people_array){
      Console.WriteLine(p.FullNameAndAge);
    }
  }
}