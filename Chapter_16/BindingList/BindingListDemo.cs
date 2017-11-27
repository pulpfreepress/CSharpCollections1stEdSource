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

public class BindingListDemo : Form {

#region Fields
   private SortableBindingList<Person> _personList;
   private TableLayoutPanel _mainPanel;
   private TableLayoutPanel _subPanel1;
   private TableLayoutPanel _subPanel2;
   private ListBox _listBox;
   private Label _label1;
   private Label _label2;
   private Label _label3;
   private Label _label4;
   private Label _label5;
   private TextBox _textbox1;
   private TextBox _textbox2;
   private TextBox _textbox3;
   private DateTimePicker _dateTimePicker;
   private RadioButton _radioButton1;
   private RadioButton _radioButton2;
   private GroupBox _groupBox;
   private Button _button1;
   private Button _button2;
   private Button _button3;
   private Button _button4;
   private Button _button5;
   private Button _button6;
 #endregion  
   
 #region Constructor
   public BindingListDemo(){
     InitializeComponent();
     InitializeBindingList();
     SetupListBox();
   }
 #endregion
   
 #region InitializationMethods
   private void InitializeComponent(){
     _mainPanel = new TableLayoutPanel();
     _mainPanel.RowCount = 2;
     _mainPanel.ColumnCount = 2;
     _subPanel1 = new TableLayoutPanel();
     _subPanel1.RowCount = 5;
     _subPanel1.ColumnCount = 2;
     _subPanel2 = new TableLayoutPanel();
     _subPanel2.RowCount = 2;
     _subPanel2.ColumnCount = 3;
     
     _listBox = new ListBox();
     _listBox.Height = 200;
     _listBox.Width = 200;
     
     _label1 = new Label();
     _label1.TextAlign = ContentAlignment.MiddleRight;
     _label1.Text = "First Name:";
     _label2 = new Label();
     _label2.TextAlign = ContentAlignment.MiddleRight;
     _label2.Text = "Middle Name:"; 
     _label3 = new Label();
     _label3.TextAlign = ContentAlignment.MiddleRight;
     _label3.Text = "Last Name:";
     _label4 = new Label();
     _label4.TextAlign = ContentAlignment.MiddleRight;
     _label4.Text = "Birthday:";
     _label5 = new Label();
     _label5.TextAlign = ContentAlignment.MiddleRight;
     _label5.Text = "Sex:";
     
     _textbox1 = new TextBox();
     _textbox2 = new TextBox();
     _textbox3 = new TextBox();
     
     _dateTimePicker = new DateTimePicker();
     
     _radioButton1 = new RadioButton();
     _radioButton1.Text = "Male";
     _radioButton1.Checked = true;
     _radioButton1.Location = new Point(10, 10);
     
     _radioButton2 = new RadioButton();
     _radioButton2.Text = "Female";
     _radioButton2.Location = new Point(10, 30);
     
     _groupBox = new GroupBox();
     _groupBox.Controls.Add(_radioButton1);
     _groupBox.Controls.Add(_radioButton2);
     _groupBox.Height = 75;
     _groupBox.Width = 150;
     
     _button1 = new Button();
     _button1.Text = "Clear";
     _button1.Click += ClearButton_Handler;
     
     _button2 = new Button();
     _button2.Text = "Submit";
     _button2.Click += SubmitButton_Handler;
     
     _button3 = new Button();
     _button3.Text = "Next";
     _button3.Click += NextButton_Handler;
     
     _button4 = new Button();
     _button4.Text = "Delete";
     _button4.Click += DeleteButton_Handler;
     
     _button5 = new Button();
     _button5.Text = "Edit";
     _button5.Click += EditButton_Handler;
     
     _button6 = new Button();
     _button6.Text = "Sort";
     _button6.Click += SortButton_Handler;
     
     _subPanel1.Controls.Add(_label1);
     _subPanel1.Controls.Add(_textbox1);
     _subPanel1.Controls.Add(_label2);
     _subPanel1.Controls.Add(_textbox2);
     _subPanel1.Controls.Add(_label3);
     _subPanel1.Controls.Add(_textbox3);
     _subPanel1.Controls.Add(_label4);
     _subPanel1.Controls.Add(_dateTimePicker);
     _subPanel1.Controls.Add(_label5);
     _subPanel1.Controls.Add(_groupBox);
    
     _subPanel2.Controls.Add(_button1);
     _subPanel2.Controls.Add(_button3);
     _subPanel2.Controls.Add(_button4);
     _subPanel2.Controls.Add(_button5);
     _subPanel2.Controls.Add(_button6);
     _subPanel2.Controls.Add(_button2);
     
     _mainPanel.Controls.Add(_listBox);
     _mainPanel.Controls.Add(_subPanel1);
     _mainPanel.Controls.Add(_subPanel2);
     _mainPanel.SetCellPosition(_subPanel2, new TableLayoutPanelCellPosition(1, 2));
    
     _subPanel1.Dock = DockStyle.Fill;
     _subPanel2.Dock = DockStyle.Fill;
     _subPanel2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
     
     _mainPanel.Dock = DockStyle.Fill;
    
     this.Controls.Add(_mainPanel);
     this.Height = 300;
     this.Width = 550;
     this.MinimumSize = new Size(550, 300);
     this.MaximumSize = new Size(550, 300);
     this.Text = "Binding List Demo";
   }
   
   
   private void InitializeBindingList(){
      _personList = new SortableBindingList<Person>();
      _personList.AddingNew += AddingNew_Handler;
      _personList.ListChanged += ListChanged_Handler;
      _personList.AllowNew = true;
      _personList.AllowEdit = true;
      _personList.AllowRemove = true;
      _personList.RaiseListChangedEvents = true;
   }
   
   private void SetupListBox(){
     _listBox.DataSource = _personList;
     _listBox.DisplayMember = "FullNameAndAge";
     _listBox.SelectedIndexChanged += SelectedIndexChanged_Handler;
     _listBox.SelectionMode = SelectionMode.One;
   }
   
   #endregion
   
   #region UtilityMethods
   private void ClearEntryControls(){
     _textbox1.Text = string.Empty;
     _textbox2.Text = string.Empty;
     _textbox3.Text = string.Empty;
     _dateTimePicker.Value = DateTime.Now;
     _radioButton1.Checked = true;
   }
   
   private void UpdateEntryControls(int selectedIndex){
     _textbox1.Text = _personList[selectedIndex].FirstName;
     _textbox2.Text = _personList[selectedIndex].MiddleName;
     _textbox3.Text = _personList[selectedIndex].LastName;
     _dateTimePicker.Value = _personList[selectedIndex].Birthday;
     ConvertGenderToRadioButtonSelection(_personList[selectedIndex].Gender);
   }
   
   private Person.Sex ConvertRadioButtonToGender(){
     return _radioButton1.Checked?Person.Sex.MALE:Person.Sex.FEMALE;
   }
   
   private void ConvertGenderToRadioButtonSelection(Person.Sex gender){
     switch(gender){
       case Person.Sex.MALE: _radioButton1.Checked = true;
                  break;
       case Person.Sex.FEMALE: _radioButton2.Checked = true;
                  break;  
     }
   }
   
   #endregion
   
   
   #region EventHandlerMethods
   public void SelectedIndexChanged_Handler(object sender, EventArgs e){
     UpdateEntryControls(_listBox.SelectedIndex);
   }
   
   public void ClearButton_Handler(object sender, EventArgs e){
     ClearEntryControls();
   }
   
   
   
   public void SubmitButton_Handler(object sender, EventArgs e){
     Person p = _personList.AddNew();
     if((p.FirstName == string.Empty) || (p.LastName == string.Empty)){
       MessageBox.Show("First Name and Last Name cannot be blank!");
       _personList.CancelNew(_personList.IndexOf(p));
     } else {
        ClearEntryControls();
       }
   }
   
   public void NextButton_Handler(object sender, EventArgs e){
     if(_personList.Count > 0){
     try{
       ++_listBox.SelectedIndex;
     }catch(ArgumentOutOfRangeException){
       //We tried to go beyond the bounds of the listbox index
       //reset SelectedIndex to zero.
       _listBox.SelectedIndex = 0;
     }
       UpdateEntryControls(_listBox.SelectedIndex);
     }else{
         MessageBox.Show("There are no items in the list!", "No Items Alert", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     }
   }
   
   public void DeleteButton_Handler(object sender, EventArgs e){
     if(_listBox.SelectedIndex > -1){
        DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", 
                                              "Delete Warning", MessageBoxButtons.OK, 
                                              MessageBoxIcon.Exclamation);
        if(result == DialogResult.OK){
          _personList.RemoveAt(_listBox.SelectedIndex);
        }
        ClearEntryControls();
     }else{
        MessageBox.Show("There are no items to delete!", "No Items Alert", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     }
   }
   
   
   public void AddingNew_Handler(object sender, AddingNewEventArgs e){
      e.NewObject = new Person(_textbox1.Text, _textbox2.Text, _textbox3.Text,
                               ConvertRadioButtonToGender(), _dateTimePicker.Value);
   }
   
   
   public void ListChanged_Handler(object sender, ListChangedEventArgs e){
     switch(e.ListChangedType){
       case ListChangedType.ItemDeleted: 
               MessageBox.Show("Item successfully deleted.");
               break;
       case ListChangedType.ItemChanged: 
               MessageBox.Show("Item successfully updated.");
               break;
     }
   }
   
   
   public void EditButton_Handler(object sender, EventArgs e){
     if(_listBox.SelectedIndex > -1){      
     
       //update the person's properties 
      _personList[_listBox.SelectedIndex].FirstName = _textbox1.Text;
      _personList[_listBox.SelectedIndex].MiddleName = _textbox2.Text;
      _personList[_listBox.SelectedIndex].LastName = _textbox3.Text;
      _personList[_listBox.SelectedIndex].Birthday = _dateTimePicker.Value;
      _personList[_listBox.SelectedIndex].Gender = ConvertRadioButtonToGender();
      //then refresh the listbox to display our updated person
      ((CurrencyManager)_listBox.BindingContext[_personList]).Refresh();
      
     } else {
        MessageBox.Show("There are no items to edit!", "No Items Alert", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     }
   }
   
   
   public void SortButton_Handler(object sender, EventArgs e){
      _personList.Sort();
      ((CurrencyManager)_listBox.BindingContext[_personList]).Refresh();
      if(_personList.Count > 0){
        UpdateEntryControls(_listBox.SelectedIndex = 0);
      }
   }
   
  #endregion
   
   
   
 #region MainMethod

   [STAThread]
   public static void Main(){
     Application.Run(new BindingListDemo());
   }
 #endregion
}

