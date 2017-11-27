/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

public class ObservableCollectionDemo {
  
  private ObservableCollection<Person> _oc = null;
  
  public ObservableCollectionDemo(){
    _oc = new ObservableCollection<Person>();
    _oc.CollectionChanged += CollectionChangedHandler;
  }
  
  public void InitializeCollection(){
     _oc.Add(new Person("Rick", "Warren", "Miller", Person.Sex.MALE, new DateTime(1961, 2, 3), Guid.NewGuid()));
     _oc.Add(new Person("Steve", "Jacob", "Hester", Person.Sex.MALE, new DateTime(1972, 1, 1), Guid.NewGuid()));
     _oc.Add(new Person("Coralie", "Sylvia", "Miller", Person.Sex.FEMALE, new DateTime(1974, 8, 8), Guid.NewGuid()));
     _oc.Add(new Person("Katherine", "Sport", "Reid", Person.Sex.FEMALE, new DateTime(1970, 5, 6), Guid.NewGuid()));
     _oc.Add(new Person("Kathleen", "KayakKat", "McMamee", Person.Sex.FEMALE, new DateTime(1983, 2, 3), Guid.NewGuid()));
     _oc.Add(new Person("Kyle", "Victor", "Miller", Person.Sex.MALE, new DateTime(1986, 10, 15), Guid.NewGuid()));
  }
  
   
  public void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e){
     
     if(e.NewItems != null){
       foreach(Person p in e.NewItems){
        Console.Write("Collection changed. New Person Added: ");
         Console.WriteLine(p.FullNameAndAge);
       }
      }else{
         foreach(Person p in e.OldItems){
            Console.Write("Collection changed. Person Removed: ");
           Console.WriteLine(p.FullNameAndAge);
         }
      }
  }
  
  public void DeleteSomeItems(){
    _oc.RemoveAt(0);
    _oc.RemoveAt(1);
  }
  
  public static void Main(){
    ObservableCollectionDemo pocd = new ObservableCollectionDemo();
    pocd.InitializeCollection();
    pocd.DeleteSomeItems();
  }
  
  
  

}
