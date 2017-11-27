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
  public class TrainingVO {
  
    // Status enumeration
    public enum TrainingStatus { Passed, Failed };
    // Private fields    
    private int _trainingID;
    private Guid _employeeID;
    private String _title;
    private String _description;
    private DateTime _startdate;
    private DateTime _enddate;
    private TrainingStatus _status;
    
    //Constructors
    public TrainingVO(){}
    
    public TrainingVO(int trainingID, Guid employeeID, String title, String description,
                       DateTime startdate, DateTime enddate, TrainingStatus status){ 
      TrainingID = trainingID;
      EmployeeID = employeeID;
      Title = title;
      Description = description;
      StartDate = startdate;
      EndDate = enddate;
      Status = status;
    }
    
    //Properties
    public int TrainingID {
      get { return _trainingID; }
      set { _trainingID = value; }
    }
    
    public Guid EmployeeID {
      get { return _employeeID; }
      set { _employeeID = value; }
    }
    
    public String Title {
      get { return _title; }
      set { _title = value; }
    }
    
    public String Description {
      get { return _description; }
      set { _description = value; }
    }
    
    public DateTime StartDate {
      get { return _startdate; }
      set {_startdate = value; }
    }
    
    public DateTime EndDate {
      get { return _enddate; }
      set { _enddate = value; }
    }
    
    public TrainingStatus Status {
      get { return _status; }
      set { _status = value; }
    }
    
    public override String ToString(){
      return Title + " " + Description + " " + EndDate.ToString() + " " + StartDate.ToString() +
             " " + Status;
    }

  } // end class definition
} // end namespace