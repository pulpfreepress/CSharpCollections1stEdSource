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

public class PalindromeTester {
 
  private int _letterCount;
  private int _checkedCharacters;
  private char _fromStack;
  private char _fromQueue;
  private bool _stillPalindrome;
  private Stack _stack;
  private Queue _queue;
  
  // Default constructor - Nothing to do, really
  public PalindromeTester(){ } 
  
  public bool Test(String inputString){
    
    _stack = new Stack();
    _queue = new Queue();
    _letterCount = 0;
    
    foreach(char c in inputString){
      if(Char.IsLetter(c)){
        _letterCount++;
        char _c = Char.ToLower(c);
        _stack.Push(_c);
        _queue.Enqueue(_c);
      }
    }
    
    _stillPalindrome = true;
    _checkedCharacters = 0;
    while(_stillPalindrome && (_checkedCharacters < _letterCount)){
      _fromStack = (char)_stack.Pop();
      _fromQueue = (char)_queue.Dequeue();
      if(_fromStack != _fromQueue){
        _stillPalindrome = false;
      }
      _checkedCharacters++;
    }
    return _stillPalindrome;
  }
  
  public static void Main(){
    
     PalindromeTester pt = new PalindromeTester();
     string input_string = String.Empty;
     while(true){
       Console.Write("Please enter a possible palindrome for testing or \"Quit\" to exit: ");
       input_string = Console.ReadLine();
       
       if(input_string == "Quit") {
         return;
       }
       
       if(pt.Test(input_string)){
         Console.BackgroundColor = ConsoleColor.DarkBlue;
         Console.Beep(400, 600);
         Console.WriteLine("YES!!! \"{0}\" is a palindrome!", input_string);
         Console.BackgroundColor = ConsoleColor.Black;
         Console.ResetColor();
       }else{
         Console.BackgroundColor = ConsoleColor.Red;
         Console.Beep(78, 3000);
         Console.WriteLine("Sorry, \"{0}\" is not a palindrome...", input_string);
         Console.ResetColor();
         
         
       }
     }
  }
}