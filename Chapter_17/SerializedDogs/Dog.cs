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
public class Dog {

   private String name = null;
   private DateTime birthday;
   
   public Dog(String name, DateTime birthday){
        this.name = name;
        this.birthday = birthday;
   }
   
   public Dog():this("Dog Joe", new DateTime(2005,01,01)){ }
   
   public Dog(String name):this(name, new DateTime(2005,01,01)){ }

   
   public int Age {
     get { 
	     int years = DateTime.Now.Year - birthday.Year;
       int adjustment = 0;
	     if(DateTime.Now.Month < birthday.Month){
         adjustment = 1;
       }else if((DateTime.Now.Month == birthday.Month) && (DateTime.Now.Day < birthday.Day)){
           adjustment = 1;
       } 
	   return years - adjustment;
	   }
   }
   
   public DateTime Birthday {
    get { return birthday; }
    set { birthday = value; }
   
   }

   public String Name {
    get { return name; }
    set { name = value; }
   }


   public override String ToString(){
     return (name + "," + Age);     
   }

} // end class definition