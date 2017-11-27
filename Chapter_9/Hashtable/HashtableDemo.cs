/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;
using System.IO;
using System.Text;


public class HashtableDemo {

  public static void Main(string[] args){
    FileStream fs = null;
    StreamReader reader = null;
    Hashtable ht = new Hashtable();
    try {
       fs = new FileStream(args[0], FileMode.Open);
       reader = new StreamReader(fs);
       
       int line_count = 1;
       string input_line = string.Empty;
       while((input_line = reader.ReadLine()) != null){
         string line_number_string = (line_count++).ToString();
         if(!ht.Contains(line_number_string)){
           ht.Add(line_number_string, input_line);
         }
       }
       
       }catch(IndexOutOfRangeException){
         Console.WriteLine("Please enter the name of a text file on the command line " +
                           "when running the program!");
       }catch(Exception e){
          Console.WriteLine(e);
       } finally {
         if(fs != null){
           fs.Close();
         }
         if(reader != null){
           reader.Close();
         }
       }
       
      
      for(int i = 1; i<=ht.Keys.Count; i++){
        Console.WriteLine("Line {0}: {1}", i, ht[i.ToString()]);
      }
      
      Console.WriteLine("*********************************************");
      Console.WriteLine("Line {0}: {1}", 2567, ht[2567.ToString()]);
      Console.WriteLine("Line {0}: {1}", 193, ht[193.ToString()]);
      Console.WriteLine("Line {0}: {1}", 669, ht[669.ToString()]);
      Console.WriteLine("Line {0}: {1}", 733, ht[733.ToString()]);
      

    
  } // end Main() method
} // end HashtableDemo class 