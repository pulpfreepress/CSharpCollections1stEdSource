/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

public class BackgroundWorkerDemo : Form {

   private Button button1;
   private Button button2;
   private Button button3;
   private Label label1;
   private Label label2;
   private Label label3;
   private BackgroundWorker bw1;
   private BackgroundWorker bw2;
   private BackgroundWorker bw3;
  
   public BackgroundWorkerDemo(){
     InitializeComponents();
   }
   
   private void InitializeComponents(){
     button1 = new Button();
	 button2 = new Button();
	 button3 = new Button();
	 label1 = new Label();
	 label2 = new Label();
	 label3 = new Label();
	 bw1 = new BackgroundWorker();
	 bw2 = new BackgroundWorker();
	 bw3 = new BackgroundWorker();
	 
	 button1.Text = "Do Something";
	 button1.AutoSize = true;
	 button1.Click += ButtonOne_Click;
	 label1.BackColor = Color.Green;
	 bw1.DoWork += DoWorkOne;
	 bw1.RunWorkerCompleted += ResetLabelOne;
	 
	 button2.Text = "Do Something Else";
	 button2.AutoSize = true;
	 button2.Click += ButtonTwo_Click;
	 label2.BackColor = Color.Green;
	 bw2.DoWork += DoWorkTwo;
	 bw2.RunWorkerCompleted += ResetLabelTwo;
	 
	 button3.Text = "Do Something Different";
	 button3.AutoSize = true;
	 button3.Click += ButtonThree_Click;
	 label3.BackColor = Color.Green;
	 bw3.DoWork += DoWorkThree;
	 bw3.RunWorkerCompleted += ResetLabelThree;
	 
	 TableLayoutPanel tlp1 = new TableLayoutPanel();
	 tlp1.RowCount = 2;
	 tlp1.ColumnCount = 3;
	 tlp1.SuspendLayout();
	 this.SuspendLayout();
	 tlp1.AutoSize = true;
	 tlp1.Dock = DockStyle.Left;
	 tlp1.Controls.Add(button1);
	 tlp1.Controls.Add(button2);
	 tlp1.Controls.Add(button3);
	 tlp1.Controls.Add(label1);
	 tlp1.Controls.Add(label2);
	 tlp1.Controls.Add(label3);
	 this.Controls.Add(tlp1);
	 this.AutoSize = true;
	 this.AutoSizeMode = AutoSizeMode.GrowOnly;
	 this.Height = tlp1.Height;
	 tlp1.ResumeLayout();
	 this.ResumeLayout();
   }
   
   private void ButtonOne_Click(Object sender, EventArgs e){
    if(!bw1.IsBusy){
      bw1.RunWorkerAsync(((Button)sender).Text);
	 }
   }
   
   private void ButtonTwo_Click(Object sender, EventArgs e){
     if(!bw2.IsBusy){     
	   bw2.RunWorkerAsync(((Button)sender).Text);
	 }
   }
   
   private void ButtonThree_Click(Object sender, EventArgs e){
      if(!bw3.IsBusy){
	    bw3.RunWorkerAsync(((Button)sender).Text);
	  }
   }
   
   private void DoWorkOne(Object sender, DoWorkEventArgs e){
     label1.BackColor = Color.Black;
	 for(int i=0; i<30000; i++){
	   Console.Write(e.Argument + " ");
	 }
   }
   
    private void DoWorkTwo(Object sender, DoWorkEventArgs e){
     label2.BackColor = Color.Black;
	 for(int i=0; i<30000; i++){
	   Console.Write(e.Argument + " ");
	 }
   }
   
    private void DoWorkThree(Object sender, DoWorkEventArgs e){
      label3.BackColor = Color.Black;
	  for(int i=0; i<30000; i++){
	   Console.Write(e.Argument + " ");
	 }
   }
   
   private void ResetLabelOne(Object sender, RunWorkerCompletedEventArgs e){
      label1.BackColor = Color.Green;
   }
   
   private void ResetLabelTwo(Object sender, RunWorkerCompletedEventArgs e){
      label2.BackColor = Color.Green;
   }
   
   private void ResetLabelThree(Object sender, RunWorkerCompletedEventArgs e){
      label3.BackColor = Color.Green;
   }

   
  [STAThread]
  public static void Main(){
    Application.Run(new BackgroundWorkerDemo());
  }// end main

} // end class definition