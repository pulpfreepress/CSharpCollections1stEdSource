/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;
using System.Collections.Generic;

public class PushValueTypeDemo {
  public static void Main(){
    Stack stack1 = new Stack();
    Stack<int> stack2 = new Stack<int>();
    const int COUNT = 25000000;
    
    DateTime start = DateTime.Now;
    for(int i = 0; i < COUNT; i++){
      stack1.Push(i);
    }
    TimeSpan elapsed_time = (DateTime.Now - start);
    Console.WriteLine("Time to push {0:N} integers to non-generic stack: {1}", COUNT, elapsed_time);
    
    start = DateTime.Now; // reset start time
    for(int i = 0; i < COUNT; i++){
      stack2.Push(i);
    }
    elapsed_time = (DateTime.Now - start);
    Console.WriteLine("Time to push {0:N} integers to generic stack of integers: {1}", 
                      COUNT, elapsed_time);
  }
}