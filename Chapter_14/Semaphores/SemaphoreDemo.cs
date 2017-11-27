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

public class SemaphoreDemo {

   private List<int> _list = new List<int>();
   private Random _random = new Random();
   private const int ITEM_COUNT = 10;
   private static Semaphore _inserterPool = new Semaphore(0, 2);
   private static int _semaphoreCount = 0;
  
   
   public void InserterMethod(){
    Console.WriteLine(Thread.CurrentThread.Name + " Starting execution...");
    _inserterPool.WaitOne();
    _semaphoreCount++;
     bool lockTaken = false;
     try{
       Console.WriteLine(Thread.CurrentThread.Name + " Attempting to acquire lock...");
       Monitor.Enter(_list, ref lockTaken);
       if(lockTaken){
         Console.WriteLine(Thread.CurrentThread.Name + " Lock Acquired");
         for(int i=0; i<ITEM_COUNT; i++){
           _list.Add(_random.Next(500));     
         }
         
         Console.WriteLine(Thread.CurrentThread.Name + " Sleeping");
         Thread.Sleep(10); 
         Console.WriteLine(Thread.CurrentThread.Name + " Pulse waiting threads...");
         Monitor.Pulse(_list);
         
         for(int i=0; i<ITEM_COUNT; i++){
           _list.Add(_random.Next(500));     
         }
       }
      }catch(Exception e){
         Console.WriteLine(e);
     }finally{
       if(lockTaken){
        Monitor.Exit(_list);
        Console.WriteLine(Thread.CurrentThread.Name + " Lock relinquished");
      }
     }
      Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
      _inserterPool.Release();
      _semaphoreCount--;
   }
   
   
   
   public void ReaderMethod(){
      Console.WriteLine(Thread.CurrentThread.Name + " Starting execution...");
     bool lockTaken = false;
     if(_semaphoreCount == 0){
       // Let's give the other threads a chance to get going
       Thread.Sleep(500);
     }
     try{
     while(!lockTaken){
       Console.WriteLine(Thread.CurrentThread.Name + " Attempting to acquire lock...");
       Monitor.Enter(_list, ref lockTaken);
       if(lockTaken){
         Console.WriteLine(Thread.CurrentThread.Name + " Lock Acquired");
         if(_list.Count == 0){
           Console.WriteLine(Thread.CurrentThread.Name + " List is currently empty. Releasing the lock.");
           Monitor.Wait(_list);
         }
         foreach(int i in _list){
           Console.Write(i + " ");    
           Console.Write(Thread.CurrentThread.Name + " Sleeping  ");
           Thread.Sleep(10);
         }
       }
     }
    }catch(Exception e){
      Console.WriteLine(e);
    }finally{
      if(lockTaken){
       Monitor.Exit(_list);
        Console.WriteLine(Thread.CurrentThread.Name + " Lock relinquished");
      }
    }
     Console.WriteLine(Thread.CurrentThread.Name + " Finished execution");
   }
   
   
   public static void Main(){
     SemaphoreDemo sd = new SemaphoreDemo();
     Thread t1 = new Thread(sd.InserterMethod);
     Thread t2 = new Thread(sd.ReaderMethod);
     Thread t3 = new Thread(sd.InserterMethod);
     Thread t4 = new Thread(sd.InserterMethod);
     t1.Name = "Inserter Thread 1";
     t2.Name = "Reader Thread";
     t3.Name = "Inserter Thread 2";
     t4.Name = "Inserter Thread 3";
     t2.Start();
     Thread.Sleep(10);
     SemaphoreDemo._inserterPool.Release(2);
     t1.Start();
     t3.Start();
     t4.Start();
     t1.Join();
     t2.Join();
     t3.Join();
     t4.Join();
   }

}