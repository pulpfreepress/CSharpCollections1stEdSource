/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class DynamicArray {
  private Object[] _object_array = null;
  private int _next_open_element = 0;
  private int _growth_increment = 10;
  private const int INITIAL_SIZE = 25;
  
  
  public int Count { 
		get { return _next_open_element; }
  }
  
  
  public object this[int index] {
	  get {
	    if((index >= 0) && (index < _object_array.Length)){
			  return _object_array[index];
      }else throw new ArgumentOutOfRangeException(); 
	  }
	  set {
	   if(_next_open_element < _object_array.Length){
		        _object_array[_next_open_element++] = value;
		     }else{
		 	GrowArray();
		 	_object_array[_next_open_element++] = value;
     }
	  }
	}
	
  public DynamicArray(int size){
    _object_array = new Object[size];
  }

  public DynamicArray():this(INITIAL_SIZE){ }

  public void Add(Object o){
    if(_next_open_element < _object_array.Length){
       _object_array[_next_open_element++] = o;
    }else{
	GrowArray();
	_object_array[_next_open_element++] = o;
     }
  } // end add() method;


  private void GrowArray(){
    Object[] temp_array = _object_array;
    _object_array = new Object[_object_array.Length + _growth_increment];
    for(int i=0, j=0; i<temp_array.Length; i++){
      if(temp_array[i] != null){
        _object_array[j++] = temp_array[i];
       }
       _next_open_element = j;
     }
     temp_array = null;
  } // end growArray() method
  

} // end DynamicArray class definition
