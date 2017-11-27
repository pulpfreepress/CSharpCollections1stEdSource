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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

    RedBlackTree<int, int> tree = new RedBlackTree<int, int>(debugOn);
    Random random = new Random();
    int[] vals = new int[20];

    for (int i = 0; i < 20; i++) {
      vals[i] = random.Next(200);
      tree.Insert(vals[i], vals[i]);
    }

    tree.PrintTreeStats();
    Console.WriteLine("Original insertion order:");
    foreach(int i in vals){
      Console.Write(i + " ");
    }
    Console.WriteLine();
    Console.WriteLine("Sorted Order:");
    tree.PrintTreeToConsole();
    
    /*****************************************************
            Serialize the tree
          ****************************************************/
    FileStream fs = null;
    try {
      fs = new FileStream("tree.dat", FileMode.Create);
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fs, tree);
    
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(fs != null){
        fs.Close();
      }
    }
    
    
    /*****************************************************
            Deserialize the tree
          ****************************************************/
    fs = null;
    try {
      fs = new FileStream("tree.dat", FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      tree = null;
      tree = (RedBlackTree<int, int>)bf.Deserialize(fs);
      Console.WriteLine("------------------ After Deserialization -----------------");
      tree.PrintTreeToConsole();
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(fs != null){
        fs.Close();
      }
    }
    
    Console.WriteLine("------------------ Remove Some Items -----------------");
    tree.Remove(vals[2]);
    tree.Remove(vals[6]);
    tree.Remove(vals[10]);
    tree.Remove(vals[8]);
    
    tree.PrintTreeToConsole();
    
    
    Console.WriteLine("\n------------------ High-to-Low Traversal -----------------");
    foreach(KeyValuePair<int, int> kvp in tree.HighToLow){
      Console.Write(kvp.Value + " ");
    }
    
    
    
    
    
  } // end Main() method
} // end MainApp class definition