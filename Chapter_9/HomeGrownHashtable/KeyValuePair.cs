/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public struct KeyValuePair : IComparable<KeyValuePair>, IComparable<string> {

  private string _key;
  private string _value;
  
  public KeyValuePair(string key, string value){
    _key = key;
    _value = value;
  }
  
  public string Key {
    get { return _key; }
    set { _key = value; }
  }
  
  public string Value {
    get { return _value; }
    set { _value = value; }
  }
  
  public int CompareTo(KeyValuePair other){
    return this._key.CompareTo(other.Key);
  }
  
  public int CompareTo(string other){
    return this._key.CompareTo(other);
  }
} // End KeyValuePair class definition