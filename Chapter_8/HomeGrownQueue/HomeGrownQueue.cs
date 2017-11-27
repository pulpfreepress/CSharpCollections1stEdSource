/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class HomeGrownQueue {
  private CircularArray _ca = null;
  private const int INITIAL_SIZE = 25;
  
  public HomeGrownQueue(int initial_size, bool debug){
    _ca = new CircularArray(initial_size, debug);
  }
  
  public HomeGrownQueue():this(INITIAL_SIZE, true){ }
  
  public bool IsEmpty {
    get { return _ca.IsEmpty; }
  }
  
  public int Count {
    get { return _ca.Count; }
  }
  
  public void Enqueue(object item){
    try{
      _ca.Insert(item);
    }catch(Exception){
      Console.WriteLine("Cannot enqueue null item!");
    }
  }
  
  public object Dequeue(){
    object return_object = null;
    try{
     return_object = _ca.Remove();
    }catch(Exception){
      throw new InvalidOperationException("Queue is empty!");
    }
    return return_object;
     
  }
  
  public object Peek(){
    object return_object;
    try{
     return_object = _ca.Peek();
    }catch(Exception){
      throw new InvalidOperationException("Queue is empty!");
    }
    return return_object;
  }

}