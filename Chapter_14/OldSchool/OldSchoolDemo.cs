/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Threading;
using System.Collections;

public class OldSchoolDemo {
   private ArrayList _list = new ArrayList();
   private ArrayList _synchronizedList = null; 
   private const int ITEM_COUNT = 100;
   private Random _random = new Random();
   
   public OldSchoolDemo(){
     _synchronizedList = ArrayList.Synchronized(_list);

   }
   
   public void PrintListStats(){
     Console.WriteLine("The _list field IsSynchronized value: " 
                                              + _list.IsSynchronized);
     Console.WriteLine("The _synchronizedList field IsSynchronized value: " 
                                              + _synchronizedList.IsSynchronized);
   }
   
   public void InserterMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution...");
     for(int i=0; i<ITEM_COUNT; i++){
       _synchronizedList.Add(_random.Next(500));
     }
     
     Thread.Sleep(10);
     
     for(int i=0; i<ITEM_COUNT; i++){
       _synchronizedList.Add(_random.Next(500));
     }
     Console.WriteLine(Thread.CurrentThread.Name + " Finished execution...");
   }
   
   
   private void ReaderMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution...");
     try{
       foreach(int i in _synchronizedList){
         Console.Write(i + " ");
       }
     }catch(Exception e){
       Console.WriteLine(e);
     }
     Console.WriteLine(Thread.CurrentThread.Name + " Finsihed execution...");
   }

  public static void Main(){
    OldSchoolDemo osd = new OldSchoolDemo();
    osd.PrintListStats();
    Thread t1 = new Thread(osd.InserterMethod);
    Thread t2 = new Thread(osd.ReaderMethod);
    t1.Name = "Inserter thread";
    t2.Name = "Reader thread";
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
  } 
}