/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class CircularArray {
  private object[] _array = null;
  private int _insertAt = 0;
  private int _removeAt = 0;
  private int _count = 0;
  private const int INITIAL_SIZE = 25;
  private bool _debug = true;
  
  public bool IsEmpty {
    get { return (_count == 0)?true:false; }
  }
  
  public int Count {
    get { return _count; }
  }
  
  public CircularArray(int initial_size, bool debug) {
    _array = new object[initial_size];
    _debug = debug;
  }
  
  public CircularArray():this(INITIAL_SIZE, true){ }
  
  
  public void Insert(object item){
    if(item == null){
      throw new ArgumentException("Cannot insert null items!");
    }
    
    if((_insertAt >= _array.Length) && (_removeAt == 0)) { // we've inserted elements and removed none 
      this.GrowArray();
    } else if((_insertAt >= _array.Length) && (_removeAt > 0)){ // There's room at the beginning
       _insertAt = 0; // reset
       _array[_insertAt++] = item;
       _count++;
       return;
    } else if((_insertAt > 0) && (_insertAt == _removeAt)){ // Queue is full - grow and reorgansize
       this.GrowAndReorganizeArray();
    }
     _array[_insertAt++] = item;
     _count++;
  } // end Insert() method
  
  
  public object Remove(){
    if(_count == 0){
      throw new InvalidOperationException("Array is empty!");
    }
    if(_removeAt >= _array.Length){
      _removeAt = 0;
    }
    object return_object = _array[_removeAt];
    _array[_removeAt++] = null;

    _count--;
    if((_count == 0) && (_removeAt == _insertAt)){ // reset insertion and removal points
      _removeAt = 0;
      _insertAt = 0; 
    }
    return return_object;
  } // end Remove() method
  
  
  public object Peek(){
    if(_count == 0){
      throw new InvalidOperationException("Array is empty!");
    } else {
      return _array[_removeAt];
    }
  } // end Peek() method
  
  
  private void GrowArray(){
    if(_debug){
      Console.WriteLine("-----Entering GrowArray Method------");
    }
    object[] temp_array = new object[_array.Length];
    for(int i = 0; i < _array.Length; i++){
      temp_array[i] = _array[i];
    }
    
    _array = new object[_array.Length * 2]; // double the size of the array
    
    for(int i = 0; i < temp_array.Length; i++){
      _array[i] = temp_array[i];
    }
    
    if(_debug){
      Console.WriteLine("-----Leaving GrowArray Method------");
    }
  } // end GrowArray() method
  
  private void GrowAndReorganizeArray(){
    if(_debug){
      Console.WriteLine("-----Entering GrowAndReorganizeArray Method------");
    }
  
    object[] temp_array = new object[_array.Length];
    for(int i = 0; i < _array.Length; i++){
      temp_array[i] = _array[i];
    }
    
    int old_length = _array.Length;
    
    _array = new object[old_length * 2]; // double the size of the array
    
    int j = 0;
    for(int i = _removeAt; i < old_length; i++){
      _array[j++] = temp_array[i];
    }
    
    for(int i = 0; i < _insertAt; i++){
      _array[j++] = temp_array[i];
    }
    
    _removeAt = 0;
    _insertAt = _count;
  
    if(_debug){
      Console.WriteLine("-----Leaving GrowAndReorganizeArray Method------");
    }
  }
  
  
} // end CircularArray class definition