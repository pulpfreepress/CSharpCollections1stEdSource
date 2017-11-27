/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Node<TKey, TValue> where TKey : IComparable<TKey> {

  public KeyValuePair<TKey, TValue> Payload;
  public Node<TKey, TValue> Parent;
  public Node<TKey, TValue> Left;
  public Node<TKey, TValue> Right;

  private bool _color;
  private const bool RED = true;
  private const bool BLACK = false;


  public Node(KeyValuePair<TKey, TValue> payload) {
    Payload = payload;
    _color = RED;
  }

  public bool IsRed {
    get { return _color; }
  }

  public bool IsBlack {
    get { return !IsRed; }
  }

  public void MakeRed() {
    _color = RED;

  }

  public void MakeBlack() {
    _color = BLACK;

  }

  public string Color {
    get { return (_color == RED) ? "RED" : "BLACK"; }
    set {
      switch (value) {
        case "RED": _color = true;
          break;
        case "BLACK": _color = false;
          break;
      }
    }
  }
}