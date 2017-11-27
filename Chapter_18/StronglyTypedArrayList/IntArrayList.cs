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

public class IntArrayList : ArrayList {
    
    public override int Add(object value){
      if(value.GetType() != typeof(System.Int32)){
        throw new ArgumentException("Incoming object is not an Int32!");
      }
      return base.Add(value);
    }

    public new int this[int i]{
      get {return (int) base[i]; }
      set { base[i] = (int)value; }
    }
}