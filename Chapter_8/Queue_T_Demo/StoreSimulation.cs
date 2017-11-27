/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;

public class StoreSimulation {

  private Queue<DateTime> _queue;
  private TimeSpan _simulationRunTime;
  private int _totalServed;
  private TimeSpan _totalWaitingTime;
  private TimeSpan _maximumWaitingTime;
  private Random _rand;
  
  public StoreSimulation(int runtimeMinutes){
    _queue = new Queue<DateTime>();
    _simulationRunTime = new TimeSpan(0, runtimeMinutes, 0);
    _rand = new Random();
  }
  
  public StoreSimulation():this(10){}
  
  public void Go(){
    DateTime startTime = DateTime.Now;
    Console.WriteLine("Simulation started at: {0}", startTime);
    while((DateTime.Now - startTime) < _simulationRunTime){
      
      if((_queue.Count > 0) && ((_rand.Next() % 6) == 3)){ 
        DateTime t = _queue.Dequeue();
        TimeSpan ts = DateTime.Now - t;
        _totalServed++;
        _totalWaitingTime += ts;
        Console.Write("P");
        if(_maximumWaitingTime < ts){
          _maximumWaitingTime = ts;
        }
      }
      
      switch(_rand.Next() % 4){
        case 1 : _queue.Enqueue(DateTime.Now);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(".");
                Console.ResetColor();
                 break;
        case 2 : _queue.Enqueue(DateTime.Now);
                 _queue.Enqueue(DateTime.Now);
                 Console.Beep(88, 200);
                 Console.ForegroundColor = ConsoleColor.Blue;
                 Console.Write("..");
                 Console.ResetColor();
                 break;
        default: break;
      }
    
    }
    
    // Print Statistics
    
    Console.WriteLine();
    Console.WriteLine("--------Simulation Complete ------------");
    Console.WriteLine("Simulation ended at: {0}", DateTime.Now);
    Console.WriteLine("Customers served: {0}", _totalServed);
    Console.WriteLine("Average wait time: {0}", (double)_totalWaitingTime.Minutes/_totalServed);
    Console.WriteLine("Longest wait time: {0}", _maximumWaitingTime);
    Console.WriteLine("Customers still in line: {0}", _queue.Count);
  }
  
  public static void Main(){
    StoreSimulation ss = new StoreSimulation(5);
    ss.Go();
  }

   

}