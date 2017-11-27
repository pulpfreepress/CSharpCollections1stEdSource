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

public class DogList : IEnumerable {
   private ArrayList _list = null;
   
   
   public DogList(int size){
     _list = new ArrayList(size);
   }
   
   public DogList():this(25){  }
   
   public int Count {
     get { return _list.Count; }
   }
   
   
   public Dog this[int index] {
     get {
        return (Dog)_list[index];
     }
     set {
       _list[index] = value;
     }
   
   }
   
   public int Add(Dog d){
     return _list.Add(d);
   }
   
   public void Remove(Dog d){
     _list.Remove(d);
   }
   
   public void RemoveAt(int index){
     _list.RemoveAt(index);
   }
   
   public void Reverse(){
     _list.Reverse();
   }
   
   public IEnumerator GetEnumerator(){
    return _list.GetEnumerator();
   }
   
   public void Sort(){
     _list.Sort();
   }

}