/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.ComponentModel;

public class Person : IComparable, IComparable<Person>, INotifyPropertyChanged {

  

  //enumeration
  public enum Sex {MALE, FEMALE};
  
  
  //event
  public event PropertyChangedEventHandler PropertyChanged;
  

  // private instance fields
  private String   _firstName;
  private String   _middleName;
  private String   _lastName;
  private Sex      _gender;       
  private DateTime _birthday;
  private Guid _dna;

  
  
  public Person(){
    _firstName = string.Empty;
    _middleName = string.Empty;
    _lastName = string.Empty;
    _gender = Person.Sex.MALE;
    _birthday = DateTime.Now;
    _dna = Guid.NewGuid();
  
  }

  public Person(String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday, Guid dna){
     FirstName = firstName;
     MiddleName = middleName;
     LastName = lastName;
     Gender = gender;
     Birthday = birthday;
     DNA = dna;
  }
  
  public Person(String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday){
     FirstName = firstName;
     MiddleName = middleName;
     LastName = lastName;
     Gender = gender;
     Birthday = birthday;
     DNA = Guid.NewGuid();
  }
  
  public Person(Person p){
     FirstName = p.FirstName;
     MiddleName = p.MiddleName;
     LastName = p.LastName;
     Gender = p.Gender;
     Birthday = p.Birthday;
     DNA = p.DNA;
  }

  // public properties
  public String FirstName {
    get { return _firstName; }
    set { _firstName = value;
          NotifyPropertyChanged("FirstName");
        }
  }
  
  public String MiddleName {
    get { return _middleName; }
    set { _middleName = value;
          NotifyPropertyChanged("MiddleName");
        }
  }
  
  public String LastName {
    get { return _lastName; }
    set { _lastName = value;
          NotifyPropertyChanged("LastName");
        }
  }
  
  public Sex Gender {
    get { return _gender; }
    set { _gender = value;
          NotifyPropertyChanged("Gender");
        }
  }
  
  public DateTime Birthday {
    get { return _birthday; }
    set { _birthday = value;
          NotifyPropertyChanged("Birthday");
        }
  }
  
  public Guid DNA {
    get { return _dna; }
    set { _dna = value; 
          NotifyPropertyChanged("DNA");
    }
  }
  
  public int Age {
     get { 
	     int years = DateTime.Now.Year - _birthday.Year;
       int adjustment = 0;
	     if(DateTime.Now.Month < _birthday.Month){
         adjustment = 1;
       }else if((DateTime.Now.Month == _birthday.Month) && (DateTime.Now.Day < _birthday.Day)){
           adjustment = 1;
       } 
	   return years - adjustment;
	   }
   }
  
  public String FullName {
    get { return FirstName + " " + MiddleName + " " + LastName; }
  }
  
  public String FullNameAndAge {
    get { return FullName + " " + Age; } 
  }
  
  protected String SortableName {
    get { return LastName + FirstName + MiddleName; }
  }
  
  public PersonKey Key {
    get { return new PersonKey(this.ToString()); }
  }
  
  public override String ToString(){
    return (FullName + "  " + Gender + "  " + Age + " " + DNA);
  }
  
  public override bool Equals(object o){
    if(o == null) return false;
    if(typeof(Person) != o.GetType()) return false;
    return this.ToString().Equals(o.ToString());
  }
  
  public override int GetHashCode(){
    return this.ToString().GetHashCode();
  }
  
  public static bool operator ==(Person lhs, Person rhs){
    return lhs.Equals(rhs);
  }
  
  public static bool operator !=(Person lhs, Person rhs){
    return !(lhs.Equals(rhs));
  }
  
  public int CompareTo(object obj){
    if((obj == null) || (typeof(Person) != obj.GetType()))  {
      throw new ArgumentException("Object is not a Person!");
    }
    return this.SortableName.CompareTo(((Person)obj).SortableName);
  }
  
  public int CompareTo(Person p){
    if(p == null){
      throw new ArgumentException("Cannot compare null objects!");
    }
    return this.SortableName.CompareTo(p.SortableName);
  }
  
 
  private void NotifyPropertyChanged(string propertyName){
    if(PropertyChanged != null){
      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
 
} // end Person class
