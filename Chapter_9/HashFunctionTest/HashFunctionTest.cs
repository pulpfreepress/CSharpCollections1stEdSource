/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class HashFunctionTest {
  
  
  public int GetKeySum(string key){
    int sum = 0;
    for(int i = 0; i<key.Length; i++){
      sum += (int)key[i];
    }
    return sum;
  }
  
  public string StripPunctuationFromKey(string key){
    StringBuilder sb = new StringBuilder();
    foreach(char c in key.ToUpper()){
      int ascii_val = (int)c;
      if((ascii_val >= 65) && (ascii_val <= 90)){
         sb.Append((char)ascii_val);
       }   
    }
    return sb.ToString(); 
  }
  
  
  public static void Main(string[] args){
    Dictionary<string, string> keys = new Dictionary<string, string>();
    int[] hash_values = new int[2477];
    int key_count = 0;
    int word_count = 0;
    HashFunctionTest hft = new HashFunctionTest();
    
    
    FileStream fs = new FileStream(args[0], FileMode.Open);
    StreamReader reader = new StreamReader(fs);
    
    string input_line = String.Empty;
    
    while((input_line = reader.ReadLine()) != null){
      string[] words = input_line.Split();
      foreach(string key in words){
        string upperCaseKey = hft.StripPunctuationFromKey(key);
        word_count++;
        if(!keys.ContainsKey(upperCaseKey)){
          keys.Add(upperCaseKey, upperCaseKey);
          int keySum = hft.GetKeySum(upperCaseKey);
          int hashValue = (keySum + 1 + (((keySum >> 5) + 1) % (7993 - 1))) % 7993;
          
        
          Console.Write(upperCaseKey + " ");
          hash_values[hashValue]++;
          key_count++;
          
        }
      }
    }
    
    
   
    for(int i = 0; i<2477; i++){
      for(int j = 0; j<hash_values[i]; j++){
        Console.Write('*');
      }
      Console.WriteLine();
    }
    
    Console.WriteLine("Total words: {0}", word_count);
    Console.WriteLine("Total keys: {0}", key_count);
  }
}