/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class HomeGrownHashtable {
  
  private float _loadFactor = 0;
  private List<string> _keys = null;
  private List<KeyValuePair>[] _table = null;
  private int _tableSize = 0;
  private int _loadLimit = 0;
  private int _count = 0;
  
  private const float MIN_LOAD_FACTOR = .65F;
  private const float MAX_LOAD_FACTOR = 1.0F;
  
  
  // Constructor methods
  public HomeGrownHashtable(float loadFactor, int initialSize){
    if((loadFactor < MIN_LOAD_FACTOR) || (loadFactor > MAX_LOAD_FACTOR)){
      Console.WriteLine("Load factor must be between {0} and {1}." +  
                        "Load factor adjusted to {1}", MIN_LOAD_FACTOR, MAX_LOAD_FACTOR);
      _loadFactor = MAX_LOAD_FACTOR;
    } else {
      _loadFactor = loadFactor;
      }
    
    _keys = new List<string>();
    _tableSize = this.DoublePrime(initialSize/2);
    _table = new List<KeyValuePair>[_tableSize];
    _loadLimit = (int)Math.Ceiling(_tableSize * _loadFactor);
    
    for(int i = 0; i<_table.Length; i++){
      _table[i] = new List<KeyValuePair>();
    }
  } // end constructor
  
  
  public HomeGrownHashtable():this(MAX_LOAD_FACTOR, 6){  }
  
  
  public string[] Keys {
    get { return _keys.ToArray(); }
  } // end Keys property
  
  
  public void Add(string key, string value){
    if((key == null) || (value == null)){
      throw new ArgumentException("Key and Value cannot be null.");
    }
    
    string upperCaseKey = key.ToUpper();
    
    if(_keys.Contains(upperCaseKey)){
      throw new ArgumentException("No duplicate keys allowed in HomeGrownHashtable!");
    }
    
    _keys.Add(upperCaseKey);
    _keys.Sort();
    int hashValue = this.GetHashValue(upperCaseKey);
    KeyValuePair item = new KeyValuePair(upperCaseKey, value);
    _table[hashValue].Add(item);
    _table[hashValue].Sort();
    
    if((++_count) >= _loadLimit){
      this.GrowTable();
    }
  }// end Add() method
  
  
  public string Remove(string key){
    if(key == null){
      throw new ArgumentException("Key string cannot be null!");
    }
    
    string upperCaseKey = key.ToUpper();
    
    if(_keys.Contains(upperCaseKey)){
      _keys.Remove(upperCaseKey);
    } else {
      throw new ArgumentException("Key does not exist in table!");
    }
    
    _keys.Sort();
    int hashValue = this.GetHashValue(upperCaseKey);
    string return_value = string.Empty;
    for(int i = 0; i<_table[hashValue].Count; i++){
      if(_table[hashValue][i].Key == upperCaseKey){
        return_value = _table[hashValue][i].Value;
        _table[hashValue].RemoveAt(i);
        _table[hashValue].Sort();
        break;
      }
    }
  
    return return_value;
  } // end Remove() method
  
  
  private void GrowTable(){
    List<KeyValuePair>[] temp = new List<KeyValuePair>[_table.Length];
    for(int i=0; i<_table.Length; i++){
      temp[i] = _table[i];
    }

    _table = new List<KeyValuePair>[this.DoublePrime(_tableSize)];
    
    for(int i=0; i<temp.Length; i++){
      _table[i] = temp[i];
    }
    
    for(int i=temp.Length; i<_table.Length; i++){
      _table[i] = new List<KeyValuePair>();
    }
  } // end GrowTable() method
  
  
  public string this[string key]{
    get { 
          if((key == null) || (key == string.Empty)){
            throw new ArgumentException("Index key value cannot be null or empty!");
          }
          string return_value = string.Empty;
          string upperCaseKey = key.ToUpper();
          if(_keys.Contains(upperCaseKey)){
            int hashValue = this.GetHashValue(upperCaseKey);
            for(int i = 0; i<_table[hashValue].Count; i++){
              if(_table[hashValue][i].Key == upperCaseKey){
                return_value = _table[hashValue][i].Value;
                break;
              }
            }
          }
          return return_value;
        }
        
    set { 
         if((key == null) || (key == string.Empty)){
            throw new ArgumentException("Index key value cannot be null or empty!");
          }
          
          if((value == null) || (value == string.Empty)){
            throw new ArgumentException("String value cannot be null or empty!");
          }
         string upperCaseKey = key.ToUpper();
          if(_keys.Contains(upperCaseKey)){
            int hashValue = this.GetHashValue(upperCaseKey);
            for(int i = 0; i<_table[hashValue].Count; i++){
              if(_table[hashValue][i].Key == upperCaseKey){
               KeyValuePair kvp = new KeyValuePair(upperCaseKey, value);
               _table[hashValue].RemoveAt(i);
               _table[hashValue].Add(kvp);
               _table[hashValue].Sort();
                break;
              }
            }
          }
    }
  } // end indexer 
 
  
  private int DoublePrime(int currentPrime){
    currentPrime *= 2;
    int limit = 0; 
    bool prime = false;
    while(!prime){
      currentPrime++;
      prime = true;
      limit = (int)Math.Sqrt(currentPrime);
      for(int i = 2; i<=limit; i++){
        if((currentPrime % i) == 0){
        prime = false;
        break;
        }      
      }
    }
    return currentPrime;
  } // end DoublePrime() method
  
  
  private int GetHashValue(string key){
    int hashValue = ( Math.Abs(key.GetHashCode()) % _tableSize );
    return hashValue;
  } // end GetHashValue() method
  
  
  public void DumpContentsToScreen(){
    foreach(List<KeyValuePair> element in _table){
      foreach(KeyValuePair kvp in element){
        Console.Write(kvp.Value + " ");
      }
      Console.WriteLine();
    }
  } // end DumpContentsToScreen() method
} // end class definition
