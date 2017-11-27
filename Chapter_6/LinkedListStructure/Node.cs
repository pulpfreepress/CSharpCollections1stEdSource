/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

public class Node<T> {
  private Node<T> _previous;
  private Node<T> _next;
  private T _value;
  
  public Node<T> Previous {
    get { return _previous; }
    set { _previous = value; }
  }
  
  public Node<T> Next {
    get { return _next; }
    set { _next = value; }
  }
  
  public T Value {
    get { return _value; }
    set { _value = value; }
  }
}