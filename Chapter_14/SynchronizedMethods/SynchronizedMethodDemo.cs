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
using System.Runtime.CompilerServices;

public class SynchronizedMethodDemo {

   private List<int> _list = new List<int>();
   private Random _random = new Random();
   private const int ITEM_COUNT = 50;
   
   [MethodImpl(MethodImplOptions.Synchronized)]
   public void InserterMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution...");
     try {
       for(int i=0; i<ITEM_COUNT; i++){
         _list.Add(_random.Next(500));     
       }
       
       Thread.Sleep(10);
       
       for(int i=0; i<ITEM_COUNT; i++){
         _list.Add(_random.Next(500));     
       }
     }catch(Exception e){
       Console.WriteLine(e);
     }
     Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
   }
   
   [MethodImpl(MethodImplOptions.Synchronized)]
   public void ReaderMethod(){
     Console.WriteLine(Thread.CurrentThread.Name + " Starting execution");
     
     try{
       foreach(int i in _list){
         Console.Write(i + " ");   
         Thread.Sleep(10);
       }
     }catch(Exception e){
       Console.WriteLine(e);
     }
    
     Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
   }
   
   
   public static void Main(){
     SynchronizedMethodDemo smd = new SynchronizedMethodDemo();
     Thread t1 = new Thread(smd.InserterMethod);
     Thread t2 = new Thread(smd.ReaderMethod);
     t1.Name = "Inserter Thread";
     t2.Name = "Reader Thread";
     t1.Start();
     t2.Start();
     t1.Join();
     t2.Join();
     
     
   }

}