/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 


using System;

public class MinuteEventArgs : EventArgs {
  private DateTime date_time;
  
  public MinuteEventArgs(DateTime date_time){
    this.date_time = date_time;
  }
  
  public int Minute {
    get { return date_time.Minute; }
  }
}
