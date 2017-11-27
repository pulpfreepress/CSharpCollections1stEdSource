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
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

public class SimpleConnection {
  public static void Main(){
    Console.WriteLine("Simple Connection!");
    Database database = DatabaseFactory.CreateDatabase();
    Console.WriteLine("Database created!");
    DbCommand command = database.GetSqlStringCommand("select table_name from information_schema.tables");
    IDataReader reader = database.ExecuteReader(command);
    while(reader.Read()){
      Console.WriteLine(reader.GetString(0));
    }
  } // end Main()
} // end class definition
