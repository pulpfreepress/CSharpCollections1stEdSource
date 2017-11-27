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
public class LogEntry {
  private string _subsystem;
  private int _severity;
  private string _text;
  private DateTime _timestamp;
  
  public DateTime TimeStamp {
    get { return _timestamp; }
    set { _timestamp = value; }
  }
  
  public string SubSystem {
    get { return _subsystem; }
    set { _subsystem = value; }
  }

  public int Severity {
    get { return _severity; }
    set { _severity = value; }
  }

  public string Text {
    get { return _text; }
    set { _text = value; }
  }
  
  public LogEntry(DateTime timestamp, string subsystem, int severity, string text){
    TimeStamp = timestamp;
    SubSystem = subsystem;
    Severity = severity;
    Text = text;
  }
  
  public override String ToString(){
    return TimeStamp.ToString() + " " + SubSystem + " " + Severity + " " + Text;
  }
} // end LogEntry class definition