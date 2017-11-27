/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public class MainApp {
  public static void Main(string[] args) {
    bool debugOn = false;
    if (args.Length > 0) {
      try {
        debugOn = Convert.ToBoolean(args[0]);
      } catch (Exception) {
        debugOn = false;
      }
    }

    RedBlackTree<PersonKey, Person> tree = new RedBlackTree<PersonKey, Person>(debugOn);
    
    Person p1 = new Person("Deekster", "Willis", "Jaybones", Person.Sex.MALE, new DateTime(1966, 02, 19));
    Person p2 = new Person("Knut", "J", "Hampson", Person.Sex.MALE, new DateTime(1972, 04, 23));
    Person p3 = new Person("Katrina", "Kataline", "Kobashar", Person.Sex.FEMALE, new DateTime(1982, 09, 3));
    Person p4 = new Person("Dreya", "Babe", "Weber", Person.Sex.FEMALE, new DateTime(1978, 11, 25));
    Person p5 = new Person("Sam", "\"The Guitar Man\"", "Miller", Person.Sex.MALE, 
                           new DateTime(1988, 04, 16));
                           
    tree.Add(p1.Key, p1);
    tree.Add(p2.Key, p2);
    tree.Add(p3.Key, p3);
    tree.Add(p4.Key, p4);
    tree.Add(p5.Key, p5);    

    tree.PrintTreeStats();
    Console.WriteLine("Original insertion order:");
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);
    Console.WriteLine(p5);
  
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine("Sorted Order:");
    tree.PrintTreeToConsole();
    
    
    /***********************************************
            Serializer Tree with XML Serializer
          ***********************************************/
    TextWriter writer = null;  
    FileStream fs = null;
    
    try{
      XmlSerializer serializer = new XmlSerializer(typeof(RedBlackTree<PersonKey, Person>));
      writer = new StreamWriter("datafile.xml");
      serializer.Serialize(writer, tree);
      writer.Close();
      
    
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(writer != null){
        writer.Close();
      }
    }
    
    
    try{
      XmlSerializer serializer = new XmlSerializer(typeof(RedBlackTree<PersonKey, Person>));
      fs = new FileStream("datafile.xml", FileMode.Open);
      tree = null;
      tree = (RedBlackTree<PersonKey, Person>)serializer.Deserialize(fs);
      fs.Close();
      
    
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(fs != null){
        fs.Close();
      }
    }
    
    Console.WriteLine("-----------Tree after XML deserialization -----------");
    tree.PrintTreeToConsole();
    
    Console.WriteLine("--------- Using HighToLow Named Iterator ----------");
    foreach(KeyValuePair<PersonKey, Person> kvp in tree.HighToLow){
      Console.WriteLine(kvp.Value);
    }
          
          
    
  } // end Main() method
} // end MainApp class definition