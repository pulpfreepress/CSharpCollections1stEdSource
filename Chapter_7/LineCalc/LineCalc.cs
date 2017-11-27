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

public class LineCalc {

   private Stack<double> stack = new Stack<double>();
   private const char ADD = '+';
   private const char SUB = '-';
   private const char MULT = '*';
   private const char DIV = '/';
   private const char EXP = '^';
   private const char EQUALS = '=';
  
   
   public void ProcessLine(string input){
     
     try {
      double operand = Double.Parse(input);
      stack.Push(operand);
       
     }catch(Exception){
        this.ProcessOperator(input);
     }
   }
   
   public void ProcessOperator(string input){
     switch(input[0]){
       case ADD: Add();
                 break;
       
       case SUB: Sub();
                 break;
       
       case MULT: Mult();
                  break;
       
       case DIV:  Div();
                  break;
       
       case EXP:  Exp();
                  break;
                  
       case EQUALS: Equals();
                    break;
       
       default: Console.WriteLine("Invalid Operator!");
                break;
     }
   }
   
   public void Add(){
     if(stack.Count >= 2){
      double operand_1 = stack.Pop();
      double operand_2 = stack.Pop();
      double result = operand_1 + operand_2;
      stack.Push(result);
      Console.WriteLine("Add result: {0}", result);
     }else{
       Console.WriteLine("Note enough operands on stack!");
     }
   }
   
   public void Sub(){
     if(stack.Count >= 2){
      double operand_1 = stack.Pop();
      double operand_2 = stack.Pop();
      double result = operand_2 - operand_1;
      stack.Push(result);
      Console.WriteLine("Sub result: {0}", result);
     }else{
       Console.WriteLine("Note enough operands on stack!");
     }
   }
   
   public void Mult(){
     if(stack.Count >= 2){
      double operand_1 = stack.Pop();
      double operand_2 = stack.Pop();
      double result = operand_1 * operand_2;
      stack.Push(result);
      Console.WriteLine("Mult result: {0}", result);
     }else{
       Console.WriteLine("Note enough operands on stack!");
     }
   }
   
   public void Div(){
     if(stack.Count >= 2){
      double operand_1 = stack.Pop();
      double operand_2 = stack.Pop();
      double result = operand_2 / operand_1;
      stack.Push(result);
      Console.WriteLine("Div result: {0}", result);
     }else{
       Console.WriteLine("Note enough operands on stack!");
     }
   }
   
   public void Exp(){
     if(stack.Count >= 2){
      double operand_1 = stack.Pop();
      double operand_2 = stack.Pop();
      double result = 1;
      for(int i = 0; i< operand_1; i++){
       result *= operand_2;
      }
      stack.Push(result);
      Console.WriteLine("Exp result: {0}", result);
     }else{
       Console.WriteLine("Note enough operands on stack!");
     }
   }
   
   public void Equals(){
     if(stack.Count >= 1){
      Console.WriteLine("Total: {0}", stack.Pop());
     }else{
       Console.WriteLine("Stack empty!");
     }
   }
   
   
   public static void Main(){
     LineCalc lc = new LineCalc();
     string input = String.Empty;
     Console.Write("Enter operand, operator, or \"quit\" to exit  --> ");
     while((input = Console.ReadLine()) != "quit"){
        if(input.Length > 0){
          lc.ProcessLine(input);
        }
        Console.Write("Enter operand, operator, or \"quit\" to exit --> ");
         
     }
   }



}