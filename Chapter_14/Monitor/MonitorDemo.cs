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
using System.Collections.Generic;

public class MonitorDemo {

   private List<int> _list = new List<int>();
   private Random _random = new Random();
   private const int ITEM_COUNT = 50;
   
   public void InserterMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution");
     Console.WriteLine(Thread.CurrentThread.Name + " Attempting to acquire lock...");
     Monitor.Enter(_list);
      Console.WriteLine(Thread.CurrentThread.Name + " Lock acquired");
     try{
         for(int i=0; i<ITEM_COUNT; i++){
           _list.Add(_random.Next(500));     
         }
         
          Console.WriteLine(Thread.CurrentThread.Name + " Sleeping...");
         Thread.Sleep(10); 
         
         for(int i=0; i<ITEM_COUNT; i++){
           _list.Add(_random.Next(500));     
         }
      }catch(Exception e){
         Console.WriteLine(e);
     }finally{
       Monitor.Exit(_list);
        Console.WriteLine(Thread.CurrentThread.Name + " Lock relinquished");
     }
      Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
   }
   
   public void ReaderMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution");
     Console.WriteLine(Thread.CurrentThread.Name + " Attempting to acquire lock...");
     Monitor.Enter(_list);
     Console.WriteLine(Thread.CurrentThread.Name + " Lock acquired");
     try{
       foreach(int i in _list){
         Console.Write(i + " ");
          Console.Write(Thread.CurrentThread.Name + " Sleeping...");         
         Thread.Sleep(10);
       }
     }catch(Exception e){
       Console.WriteLine(e);
     }finally{
       Monitor.Exit(_list);
        Console.WriteLine(Thread.CurrentThread.Name + " Lock relinquished");
     }
     Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
   }
   
   
   public static void Main(){
     MonitorDemo md = new MonitorDemo();
     Thread t1 = new Thread(md.InserterMethod);
     Thread t2 = new Thread(md.ReaderMethod);
     t1.Name = "Inserter Thread";
     t2.Name = "Reader Thread";
     t1.Start();
     t2.Start();
     t1.Join();
     t2.Join();
     
     
   }

}