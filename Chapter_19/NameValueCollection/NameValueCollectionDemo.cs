/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Specialized;
using System.Net;
using System.IO;

public class NameValueCollectionDemo {

  public static void Main(){
    NameValueCollection nvc = new NameValueCollection();
	FileStream fs = null;
	StreamWriter writer = null;
	
	for(int i = 122; i<123; i++){
	  for(int j = 183; j<184; j++){
	    for(int k = 97; k<99; k++){
		  for(int l = 50; l<88; l++){
			try{
			String ipaddress_string = i + "." + j + "." + k + "." + l;
			IPAddress ipaddress = IPAddress.Parse(ipaddress_string);
			string hostname = Dns.GetHostEntry(ipaddress).HostName;
			Console.WriteLine(hostname + " : " + ipaddress_string);
			nvc.Add(hostname, ipaddress_string);
			}catch(Exception){
			  // ignored
			}
		  }
		}
	  }
	}  // end outer for loop

    try{
	fs = new FileStream("hostnames.txt", FileMode.Create);
	writer = new StreamWriter(fs);
	foreach(string hostname in nvc.Keys){
	  writer.Write(hostname + " | " + nvc[hostname] + "\r\n");
	}
	writer.Flush();
	
	}catch(Exception e){
	   Console.WriteLine(e);
	}finally{
	  try{
	  if(writer != null){
	    writer.Close();
		fs.Close();
	  }
	  }catch(Exception){
	    //ignored
	  }
	}
	
  } // end Main()
}