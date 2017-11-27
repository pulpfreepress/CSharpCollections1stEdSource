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
  }
}