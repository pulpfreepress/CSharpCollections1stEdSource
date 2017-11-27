/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

public class Dog {
  private string _first_name;
  private string _last_name;
  private string _breed;

  public Dog(string breed, string f_name, string l_name){
    _breed = breed;
    _first_name = f_name;
    _last_name = l_name;
  }
  
  public string FirstName {
    get { return _first_name; }
    set { _first_name = value; }
  }
  
  public string LastName {
    get { return _last_name; }
    set { _last_name = value; }
  }
  
  public string Breed {
    get { return _breed; }
    set { _breed = value; }
  }
  
  public string FullName {
    get { return FirstName + " " + LastName; }
  }
  
  public string BreedAndFullName {
    get { return Breed + ": " + FullName; }
  }
  
}