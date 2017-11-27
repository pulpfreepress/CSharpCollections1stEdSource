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
using System.Drawing;

namespace EmployeeTraining.VO {
[Serializable]
  public class EmployeeVO : PersonVO {

  // private instance fields
  private Guid     _employeeID;
  private Image  _picture;

  //default constructor
  public EmployeeVO(){}

  public EmployeeVO(Guid employeeid, String firstName, String middleName, String lastName, 
                Sex gender, DateTime birthday):base(firstName, middleName, lastName, gender, birthday){
     EmployeeID = employeeid;
  }

  // public properties
  public Guid EmployeeID {
    get { return _employeeID;  }
    set { _employeeID = value; }
  }

  public Image Picture {
    get { return _picture;  }
    set { _picture = value; }
  }
  
  public override String ToString(){
    return (EmployeeID + " " + base.ToString());
  }
} // end EmployeeVO class
} // end namespace 
