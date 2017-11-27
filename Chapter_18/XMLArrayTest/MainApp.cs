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

    List<Person> _list = new List<Person>();
    
    Person p1 = new Person("Deekster", "Willis", "Jaybones", Person.Sex.MALE, new DateTime(1966, 02, 19));
    Person p2 = new Person("Knut", "J", "Hampson", Person.Sex.MALE, new DateTime(1972, 04, 23));
    Person p3 = new Person("Katrina", "Kataline", "Kobashar", Person.Sex.FEMALE, new DateTime(1982, 09, 3));
    Person p4 = new Person("Dreya", "Babe", "Weber", Person.Sex.FEMALE, new DateTime(1978, 11, 25));
    Person p5 = new Person("Sam", "\"The Guitar Man\"", "Miller", Person.Sex.MALE, 
                           new DateTime(1988, 04, 16));
                           
    _list.Add(p1);
    _list.Add(p2);
    _list.Add(p3);
    _list.Add(p4);
    _list.Add(p5);
      
 
    /***********************************************
            Serializer Tree with XML Serializer
          ***********************************************/
    TextWriter writer = null;    
    
    try{
      XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
      writer = new StreamWriter("datafile.xml");
      serializer.Serialize(writer, _list);
      writer.Close();
      
    
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(writer != null){
        writer.Close();
      }
    }
          
          
    
  } // end Main() method
} // end MainApp class definition