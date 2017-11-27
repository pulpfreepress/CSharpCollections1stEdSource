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

public class BalancedSymbolChecker {

  private const char OPEN_PAREN = '(';
  private const char CLOSE_PAREN = ')';
  private const char OPEN_BRACKET = '[';
  private const char CLOSE_BRACKET = ']';
  private const char OPEN_BRACE = '{';
  private const char CLOSE_BRACE = '}';
  
  
  public char GetNextSymbol(){
    char c;
    do {
      if((c = (char)Console.Read()) == '\r'){
        return '\0';
      }
    }while( (c != OPEN_PAREN) && (c != CLOSE_PAREN) && (c != OPEN_BRACKET) && (c != CLOSE_BRACKET)
            && (c != OPEN_BRACE) && (c != CLOSE_BRACE) );
      
      return c;
  } // end GetNextSymbol method
  
  public bool CheckMatch(char openSymbol, char closeSymbol){
    if((openSymbol == OPEN_PAREN) && (closeSymbol != CLOSE_PAREN) ||
       (openSymbol == OPEN_BRACKET) && (closeSymbol != CLOSE_BRACKET) ||
       (openSymbol == OPEN_BRACE) && (closeSymbol != CLOSE_BRACE) ) {
         Console.WriteLine("Open Symbol " + openSymbol + " does not match " + closeSymbol);
         return false;
       }
       return true;
  }
  
  public bool CheckBalance(){
    char c, match;
    int errors = 0;
    
    Stack pendingTokens = new Stack();
    while((c = GetNextSymbol()) != '\0'){
      switch(c){
        case OPEN_PAREN:
        case OPEN_BRACKET:
        case OPEN_BRACE: pendingTokens.Push(c);
                  break;
        case CLOSE_PAREN:
        case CLOSE_BRACKET:
        case CLOSE_BRACE: {
                    if(pendingTokens.Count == 0){
                      Console.WriteLine("Invalid symbol sequence: " + c);
                      return false;
                    }else{
                      match = (char)pendingTokens.Pop();
                      if(! CheckMatch(match, c)){
                       return false;
                      }else{
                        Console.WriteLine("Matching symbols {0} and {1} found", match, c);
                      }
                    }
                    break;
                  }
            
      }
    }
    
    while(pendingTokens.Count > 0){
       match = (char)  pendingTokens.Pop();
       Console.WriteLine("Unmatched symbol: " + match);
       errors++;
      }
      return (errors > 0) ? false:true;
  }
  
  
}