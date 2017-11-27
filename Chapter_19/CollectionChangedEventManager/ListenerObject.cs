/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;
using System.Windows;
using System.Collections.Specialized;
using System.Net.Mail;

public class ListenerObject : IWeakEventListener {

   public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e){
     if(managerType == typeof(CollectionChangedEventManager)){
	   CollectionChangedHandler(sender, (NotifyCollectionChangedEventArgs)e); 
	   return true;
	 }
	 return false;
   }
   
   private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e){
     try{
	  SmtpClient smtp_client = new SmtpClient("127.0.0.1", 25);
	  MailAddress from = new MailAddress("rick@pulpfreepress.com");
	  MailAddress to = new MailAddress("rick@pulpfreepress.com");
	  MailMessage email = new MailMessage(from, to);
	  email.Subject = sender.ToString() + " has changed...";
	  email.Body = "Tree has changed!";
	  smtp_client.Send(email);
	  Console.WriteLine("CollectionChangedEvent fired! Email notification sent to {0}!", to.ToString());
	 }catch(Exception ex){
	   Console.WriteLine("Collection has changed, email notification not sent. Check SMTP settings...");
	   Console.WriteLine(ex);
	 }
   }

}