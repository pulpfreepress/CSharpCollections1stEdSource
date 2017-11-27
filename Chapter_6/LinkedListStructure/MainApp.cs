/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
  private static CircularLinkedList<int> list = new CircularLinkedList<int>();
  private static Node<int> current_node;
  
  // utility method
    private static void PrintListValues(){
      current_node = list.First;
      for(int i = 0; i < list.Count; i++){
        Console.Write(current_node.Value + " ");
        current_node = current_node.Next;
      }
      Console.WriteLine();
    }
  
  public static void Main(){
    
    // Test AddFirst() method
    MainApp.list.AddFirst(3);
    MainApp.list.AddFirst(2);
    MainApp.list.AddFirst(1);
    MainApp.PrintListValues();
    
    // Test Remove() method
    MainApp.list.Remove(current_node.Previous);
    MainApp.PrintListValues();
    
    // Test AddBefore() method
    MainApp.list.AddBefore(current_node.Previous, 4);
    MainApp.PrintListValues();
    
    // Test AddAfter() method
    MainApp.list.AddAfter(MainApp.list.Find(4), 5);
    MainApp.PrintListValues();
    
    // Remove last element
    MainApp.list.Remove(MainApp.list.Last);
    MainApp.PrintListValues();
    
    // Remove first element
    MainApp.list.Remove(MainApp.list.First);
    MainApp.PrintListValues();
    
    // Test AddLast() method
    MainApp.list.AddLast(6);
    MainApp.PrintListValues();
    Console.WriteLine("List has " + MainApp.list.Count + " items");
    
    // Test AddAfter() method again
    MainApp.list.AddAfter(MainApp.list.Find(6), 7);
    MainApp.PrintListValues();
    
    // Test AddBefore method again
    MainApp.list.AddBefore(MainApp.list.Find(4), 3);
    MainApp.PrintListValues();
    
    // Let's step forward through the list
    Console.Write("First element = " + MainApp.list.First.Value + " ");
    Console.Write("Second element = " + MainApp.list.First.Next.Value + " ");
    Console.Write("Third element = " + MainApp.list.First.Next.Next.Value + " ");
    Console.Write("Forth element = " + MainApp.list.First.Next.Next.Next.Value + " ");
    Console.Write("Fifth element = " + MainApp.list.First.Next.Next.Next.Next.Value + " ");
    Console.Write("Next element = " + MainApp.list.First.Next.Next.Next.Next.Next.Value + " ");
    Console.WriteLine();
    
    // Now backwards
    Console.Write("Last element = " + MainApp.list.Last.Value + " ");
    Console.Write("Next element = " + MainApp.list.Last.Previous.Value + " ");
    Console.Write("Next element = " + MainApp.list.Last.Previous.Previous.Value + " ");
    Console.Write("Next element = " + MainApp.list.Last.Previous.Previous.Previous.Value + " ");
    Console.Write("Next element = " + MainApp.list.Last.Previous.Previous.Previous.Previous.Value + " ");
	
	Console.WriteLine("\n----------------------------------------------");
	Console.WriteLine("Number of elements in the list: " + MainApp.list.Count);
	while(MainApp.list.Count > 0){
	   MainApp.list.Remove(MainApp.list.Last);
	}
	Console.WriteLine("Number of elements in the list: " + MainApp.list.Count);
  }
}