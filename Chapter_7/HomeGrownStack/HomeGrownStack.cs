/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class HomeGrownStack {
  
  private object[] stack_contents;
  private int top = -1;
  private const int INITIAL_SIZE = 25;
  
  public HomeGrownStack(int initial_size){
    stack_contents = new object[initial_size];
  }
  
  public HomeGrownStack():this(INITIAL_SIZE){  }
  
  public bool IsEmpty {
    get { return (top == -1); }
  }
  
  public void Push(object item){
    if(item == null){
      throw new ArgumentException("Cannot push null item onto stack!" );
    }
    
    if((++top) >= stack_contents.Length){
      GrowStack();
    }else{
      stack_contents[top] = item;
    }
  } // end Push method
  
  public object Pop(){
    if(IsEmpty){
      throw new InvalidOperationException("The stack is empty!");
    }
    object return_object = stack_contents[top];
    stack_contents[top--] = null;
    return return_object;
  } // end Pop method
  
  public object Peek(){
    if(IsEmpty){
      throw new InvalidOperationException("The stack is empty!");
    }
    return stack_contents[top];
    
  } // end Peek method
  
  private void GrowStack(){
    object[] temp_array = new object[stack_contents.Length];
    for(int i = 0; i < stack_contents.Length; i++){
      temp_array[i] = stack_contents[i];
    }
    
    stack_contents = new object[stack_contents.Length * 2];
    
    for(int i = 0; i < temp_array.Length; i++){
      stack_contents[i] = temp_array[i];
    }
  } // end GrowArray method
  
  
} // end class definition