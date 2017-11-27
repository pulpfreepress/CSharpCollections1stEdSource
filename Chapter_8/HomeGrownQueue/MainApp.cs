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
  public static void Main(){
   HomeGrownQueue queue = new HomeGrownQueue(); // default size of 25 elements
    
    for(int i = 0; i < 40; i++){ // test Growth Capability
      queue.Enqueue(i);
    }
    
    Console.WriteLine("Count = {0}", queue.Count);
    
    int itemsInQueue = queue.Count;
    
    Console.WriteLine("Next item to be removed from queue is: {0}", queue.Peek());
    
    for(int i = 0; i < itemsInQueue ; i++) {
      Console.Write(queue.Dequeue() + " ");
    }
    
    Console.WriteLine();
    
    try{
     queue.Dequeue(); // try to remove one more element
    
    }catch(Exception e){
      Console.WriteLine(e);
    }
    
   queue = new HomeGrownQueue(); // start again with 25 elements
   
   for(int i = 0; i < 23; i++){
     queue.Enqueue(i);
   }
   
   for(int i = 0; i < 10; i++){
     Console.Write(queue.Dequeue() + " ");
   }
   Console.WriteLine();
   
   queue.Enqueue(23);
   queue.Enqueue(24);
   queue.Enqueue(25);
   queue.Enqueue(26);
   queue.Enqueue(27);
   queue.Enqueue(28);
   queue.Enqueue(29);
   queue.Enqueue(30);
   queue.Enqueue(31);
   queue.Enqueue(32);
   queue.Enqueue(33);
   queue.Enqueue(34);
   queue.Enqueue(35);
   queue.Enqueue(36);
   queue.Enqueue(37);
   queue.Enqueue(38);
   queue.Enqueue(39);
   queue.Enqueue(40);
   queue.Enqueue(41);
   for(int i = 42; i < 134; i++){
     queue.Enqueue(i);
   }
   
   for(int i = 0; i< 83; i++){
     Console.Write(queue.Dequeue() + " ");
   }
   
   for(int i = 134; i < 289; i++){
     queue.Enqueue(i);
   }
   
   
   Console.WriteLine("Count = " + queue.Count);
   
   while(queue.Count > 0){
     Console.Write(queue.Dequeue() + " ");
   }
   
   Console.WriteLine("Count = " + queue.Count);
   
   
   
    
  }
}