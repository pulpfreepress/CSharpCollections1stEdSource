/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class KeyValuePair<TKey, TValue> : IComparable<KeyValuePair<TKey, TValue>> where TKey :
                                                                                     IComparable<TKey> {

  private TKey _key;
  private TValue _value;

  public KeyValuePair(TKey key, TValue value) {
    _key = key;
    _value = value;
  }

  public KeyValuePair() { }

  public TKey Key {
    get { return _key; }
    set { _key = value; }
  }

  public TValue Value {
    get { return _value; }
    set { _value = value; }
  }

  public int CompareTo(KeyValuePair<TKey, TValue> other) {
    return this._key.CompareTo(other.Key);
  }

  public override string ToString() {
    return _key.ToString() + " " + _value.ToString();
  }
} // End KeyValuePair class definition