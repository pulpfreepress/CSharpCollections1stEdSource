/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

public class BindingListDataGridDemo : Form {

 #region Fields
  SortableBindingList<Person> _personList;
  DataGridView _dataGridView;
  TableLayoutPanel _mainPanel;
  TableLayoutPanel _buttonPanel;
  Button _button1;
  Button _button2;
 #endregion  
   
 #region Constructor
   public BindingListDataGridDemo(){
     InitializeBindingList();
     InitializeComponent();
   }
 #endregion
   
 #region InitializationMethods
   private void InitializeBindingList(){
      _personList = new SortableBindingList<Person>();
      _personList.AddingNew += AddingNew_Handler;
      _personList.ListChanged += ListChanged_Handler;
      _personList.AllowNew = true;
      _personList.AllowEdit = true;
      _personList.AllowRemove = true;
      _personList.RaiseListChangedEvents = true;
   }
   
   private void InitializeComponent(){
     _mainPanel = new TableLayoutPanel();
     _mainPanel.RowCount = 2;
     _mainPanel.ColumnCount = 1;
     _mainPanel.Dock = DockStyle.Fill;
     
     _buttonPanel = new TableLayoutPanel();
     _buttonPanel.RowCount = 1;
     _buttonPanel.ColumnCount = 2;
     _buttonPanel.Dock = DockStyle.Fill;
     
     InitializeDataGridView();
     
     _button1 = new Button();
     _button1.Text = "Sort";
     _button1.Click += SortButton_Handler;
     
     _button2 = new Button();
     _button2.Text = "Delete";
     _button2.Click += DeleteButton_Handler;
     
     _buttonPanel.Controls.Add(_button1);
     _buttonPanel.Controls.Add(_button2);
     
     _mainPanel.Controls.Add(_dataGridView);
     _mainPanel.Controls.Add(_buttonPanel);
     
     this.Controls.Add(_mainPanel);
     this.Width = 850;
     this.Height = 250;
     this.Text = "BindingListDataGridDemo";
   }
   
   
   private void InitializeDataGridView(){
     _dataGridView = new DataGridView();
     _dataGridView.Dock = DockStyle.Fill;
     DataGridViewComboBoxColumn genderColumn = new DataGridViewComboBoxColumn();
     genderColumn.DataSource = Enum.GetValues(typeof(Person.Sex));
     genderColumn.DataPropertyName = "Gender";
     genderColumn.HeaderText = "Gender";
     _dataGridView.Columns.Add(genderColumn);
     _dataGridView.DataSource = _personList;
     _dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
     _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
     _dataGridView.DataBindingComplete += DataBindingComplete_Handler;
   }
 #endregion
   
   
 #region EventHandlerMethods
  
   public void AddingNew_Handler(object sender, AddingNewEventArgs e){
      e.NewObject = new Person();
      Console.WriteLine("New Person object created!");
   }
   
   public void ListChanged_Handler(object sender, ListChangedEventArgs e){
     switch(e.ListChangedType){
       case ListChangedType.ItemDeleted: 
               Console.WriteLine("Item successfully deleted.");
               foreach(Person p in _personList){
                 Console.WriteLine(p);
               }
               break;
       case ListChangedType.ItemChanged: 
               ((CurrencyManager)_dataGridView.BindingContext[_personList]).Refresh();
               Console.Write("Item successfully updated. Property: " + e.PropertyDescriptor.Name );
               Console.WriteLine(" - Value: " + e.PropertyDescriptor.GetValue(_personList[e.NewIndex]));
                
               break;
     }
   }
   
   
  public void SortButton_Handler(object sender, EventArgs e){
    _personList.Sort();
    ((CurrencyManager)_dataGridView.BindingContext[_personList]).Refresh();
  }
  
  
  public void DeleteButton_Handler(object sender, EventArgs e){
      if(_personList.Count > 0){
        _personList.RemoveAt(_dataGridView.CurrentRow.Index);
        Console.WriteLine("Person object deleted!");
      }
  }
  
  public void DataBindingComplete_Handler(object sender, EventArgs e){
    _dataGridView.Columns["FullNameAndAge"].Visible = false;
    _dataGridView.Columns["FullName"].Visible = false;
    _dataGridView.Columns["Key"].Visible = false;
    _dataGridView.Columns["DNA"].ReadOnly = true;
    _dataGridView.Columns["DNA"].ToolTipText = "Read Only!";
    _dataGridView.Columns["Birthday"].ToolTipText = "Format: mm/dd/yyyy";
    
    for(int i=0; i<_dataGridView.Columns.Count; i++){
      _dataGridView.Columns[i].Width = 100;
    }
    
    _dataGridView.Columns["DNA"].Width = 225;
    _dataGridView.Columns["Age"].Width = 50;
    _dataGridView.Columns["FirstName"].DisplayIndex = 0;
    _dataGridView.Columns["MiddleName"].DisplayIndex = 1;
    _dataGridView.Columns["LastName"].DisplayIndex = 2;
  }
  
 #endregion
   
   
 #region MainMethod
   [STAThread]
   public static void Main(){
     Application.Run(new BindingListDataGridDemo());
   }
 #endregion
}

