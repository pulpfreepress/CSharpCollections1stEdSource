/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

[Serializable]
public class PersonKey : IEquatable<String>, IComparable, IComparable<PersonKey> {

    private string _keyString = String.Empty;
    
    public PersonKey(string s){
      _keyString = s;
    }
    
    public PersonKey(){}
    
    public String KeyString {
      get { return _keyString; }
      set { _keyString = value; }
    }
    
    public bool Equals(string other){
      return _keyString.Equals(other);
    }
    
    public override string ToString(){
      return String.Copy(_keyString);
    }
    
    public override bool Equals(object o){
      if(o == null) return false;
      if(typeof(string) != o.GetType()) return false;
      return this.ToString().Equals(o.ToString());
    }
    
    public override int GetHashCode(){
      return this.ToString().GetHashCode();
    }
    
    public int CompareTo(object obj){
     return _keyString.CompareTo(obj);
    }
    
    
    public int CompareTo(PersonKey pk){
      return _keyString.CompareTo(pk._keyString);
    }

}