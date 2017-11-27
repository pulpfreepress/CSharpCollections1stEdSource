/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace EmployeeTraining.VO {
  [Serializable]
  public class PersonVO {

  //enumeration
  public enum Sex {MALE, FEMALE};

  // private instance fields
  private String   _firstName;
  private String   _middleName;
  private String   _lastName;
  private Sex      _gender;       
  private DateTime _birthday;


  //default constructor
  public PersonVO(){}

  public PersonVO(String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday){
     FirstName = firstName;
     MiddleName = middleName;
     LastName = lastName;
     Gender = gender;
     BirthDay = birthday;
  }



  // public properties
  public String FirstName {
    get { return _firstName; }
    set { _firstName = value; }
  }

  public String MiddleName {
    get { return _middleName; }
    set { _middleName = value; }
  }

  public String LastName {
    get { return _lastName; }
    set { _lastName = value; }
  }

  public Sex Gender {
    get { return _gender; }
    set { _gender = value; }
  }

  public DateTime BirthDay {
    get { return _birthday; }
    set { _birthday = value; }
  }

  public int Age {
     get { 
     int years = DateTime.Now.Year - _birthday.Year;
       int adjustment = 0;
     if((DateTime.Now.Month <= _birthday.Month) && (DateTime.Now.Day < _birthday.Day)){
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

  public override String ToString(){
    return FullName + " is a " + Gender + " who is " + Age + " years old.";
  }

  } // end Person class
} // end namespace
