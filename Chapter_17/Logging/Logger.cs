/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 


using System;
using System.IO;
using System.IO.Log;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

public class Logger {
  private string _logfilename;
  private FileRecordSequence _sequence;
  private SequenceNumber _previous;
  
  
  public Logger(string logfilename){
    _logfilename = logfilename;
    _sequence = new FileRecordSequence(logfilename, FileAccess.ReadWrite);
    _previous = SequenceNumber.Invalid;
  }
  
  public Logger():this("logfile.log"){ }
  
  public void Append(LogEntry entry){
    _previous = _sequence.Append(ToArraySegment(entry), SequenceNumber.Invalid, _previous, RecordAppendOptions.ForceFlush);   
  }

  public ArraySegment<byte> ToArraySegment(LogEntry entry) {       
    MemoryStream stream = new MemoryStream();
    BinaryFormatter formatter = new BinaryFormatter();
    formatter.Serialize(stream, entry);
    stream.Flush();
    return new ArraySegment<byte>(stream.GetBuffer());
  }
 
  public String GetLogRecords() {
    StringBuilder sb = new StringBuilder();
    BinaryFormatter formatter = new BinaryFormatter();
    IEnumerable<LogRecord> records = _sequence.ReadLogRecords(_sequence.BaseSequenceNumber, LogRecordEnumeratorType.Next);
    foreach (LogRecord record in records) {
      LogEntry entry = (LogEntry) formatter.Deserialize(record.Data);
      sb.Append(entry.ToString() + "\r\n");
    }
    return sb.ToString();
  }
  
  public void Dispose(){
    _sequence.Dispose();
  }
} // end class definition