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
  public static void Main(string[] args){
    HomeGrownHashtable ht = new HomeGrownHashtable();
    ht.Add("Rick", "Photographer, writer, publisher, handsome cuss");
    ht.Add("Coralie", "Gorgeous, smart, funny, gal pal");
    ht.Add("Kyle", "Tall, giant of a man! And a recent college graduate!");
    ht.Add("Tati", "Thai hot sauce!");
    Console.WriteLine(ht["Tati"]);
    Console.WriteLine(ht["Kyle"]);
    ht["Tati"] = "And a great cook, too!";
    ht.DumpContentsToScreen();
    ht.Remove("Tati");
    ht.DumpContentsToScreen();
  } // end Main() method


} 