/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class GenericFactory<T> where T: new() {

  private static GenericFactory<T> factory;
  
  public static GenericFactory<T> Instance {
    get { if (factory != null) {
            return factory;
          } else {
              factory = new GenericFactory<T>();
              return factory;
            }
        }
  }
  
  public T NewObject(){
    return new T();
  }
}