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

public class SortedListDemo {
  public static void Main(){
  
    const string MACBETH_KEY = "MacBeth";
    const string MACBETH_QUOTE = "I have done the deed. - Didst thou not hear a noise?";
    const string MACARTHUR_KEY = "MacAuthur";
    const string MACARTHUR_QUOTE = "Age wrinkles the body. Quitting wrinkles the soul.";
    const string CHURCHILL_KEY = "Churchill";
    const string CHURCHILL_QUOTE = "A fanatic is one who can't change his mind and " +
                                   "won't change the subject.";
    const string DE_SADE_KEY = "de Sade";
    const string DE_SADE_QUOTE = "All universal moral principles are idle fancies.";
    
    
    SortedList<string, string> _quotes = new SortedList<string, string>();
    
    _quotes.Add(MACBETH_KEY, MACBETH_QUOTE);
    _quotes.Add(MACARTHUR_KEY, MACARTHUR_QUOTE);
    _quotes.Add(CHURCHILL_KEY, CHURCHILL_QUOTE);
    _quotes.Add(DE_SADE_KEY, DE_SADE_QUOTE);
    
    foreach(KeyValuePair<string, string> kvp in _quotes){
      Console.WriteLine(kvp.Key + " said:  " + kvp.Value);
    }
  }
}