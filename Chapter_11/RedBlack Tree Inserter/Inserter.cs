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

public class Inserter {
  public static void Main(){
    FileStream fs = new FileStream("inserts.txt", FileMode.Create);
    StreamWriter writer = new StreamWriter(fs);
    Random rand = new Random();
    int val = 0;
    for(int i = 500; i>0; i--){
    // val = rand.Next(500);
    // writer.Write("tree.Insert(" + val + ", " + val + ");\r\n");
     writer.Write("tree.Insert(" + i + ", " + i + ");\r\n");
    }
    writer.Flush();
  }
}