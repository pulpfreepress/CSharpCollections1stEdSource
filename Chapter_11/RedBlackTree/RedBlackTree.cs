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
using System.Collections.Generic;
using System.Linq;

public class RedBlackTree<TKey, TValue> : IEnumerable where TKey : IComparable<TKey> {


  #region Constants
  private const int EQUALS = 0;
  private const int LESSTHAN = -1;
  private const int GREATERTHAN = 1;
  #endregion

  #region Fields
  private Node<TKey, TValue> _root;
  private int _count = 0;
  private int _left_rotates = 0;
  private int _right_rotates = 0;
  private TKey _first_inserted_key;
  private bool _debug = true;
  #endregion


  #region Constructors
  public RedBlackTree() : this(true) { }

  public RedBlackTree(bool debug) {
    _debug = debug;
  }
  #endregion


  #region Properties
  public KeyValuePair<TKey, TValue> Root {
    get { return _root.Payload; }
  }

  public int Count {
    get { return _count; }
  }
  #endregion


  #region Methods


  /*****************************************************************
   *   Insert Method
   * **************************************************************/
  public void Insert(TKey key, TValue value) {
    if ((key == null) || (value == null)) {
      throw new ArgumentException("Invalid Key and/or Value arguments!");
    }
    if (_root == null) {
      _root = new Node<TKey, TValue>(new KeyValuePair<TKey, TValue>(key, value));

      _count++;
      if (_debug) {
        Console.WriteLine("Inserted root node with values:" + _root.Payload.ToString());
      }
      _root.MakeBlack();
      _first_inserted_key = _root.Payload.Key;
      return;
    } else {
      Node<TKey, TValue> new_node = new Node<TKey, TValue>(new KeyValuePair<TKey, TValue>(key, value));

      bool inserted = false;
      int comparison_result = 0;
      Node<TKey, TValue> node = _root;
      while (!inserted) {
        comparison_result = new_node.Payload.Key.CompareTo(node.Payload.Key);
        switch (comparison_result) {
          case EQUALS: inserted = true; // ignore duplicate key values
            break;
          case LESSTHAN: if (node.Left == null) {
              node.Left = new_node;
              new_node.Parent = node;
              inserted = true;
              _count++;
              if (_debug) {
                Console.WriteLine("Inserted left: {0}", new_node.Payload.Key);
              }
              RBInsertFixUp(new_node);

            } else {
              node = node.Left;
            }
            break;
          case GREATERTHAN: if (node.Right == null) {
              node.Right = new_node;
              new_node.Parent = node;
              inserted = true;
              _count++;
              if (_debug) {
                Console.WriteLine("Inserted right: {0}", new_node.Payload.Key);
              }
              RBInsertFixUp(new_node);
            } else {
              node = node.Right;
            }
            break;
        }
      }
    }
  } // end Insert() method




  /***************************************************************
   *  RBInsertFixUp Method
   * ************************************************************/
  private void RBInsertFixUp(Node<TKey, TValue> node) {
    while ((node.Parent != null) && (node.Parent.IsRed)) {
      Node<TKey, TValue> y = null;
      if ((node.Parent.Parent != null) && (node.Parent == node.Parent.Parent.Left)) {  // Parent is a left child
        y = node.Parent.Parent.Right;

        if ((y != null) && (y.IsRed)) {   //case 1
          node.Parent.MakeBlack();        //case 1
          y.MakeBlack();                  //case 1
          node.Parent.Parent.MakeRed();   //case 1
          node = node.Parent.Parent;     

          if (node.IsRed) {
            continue;
          }

        } else if (node == node.Parent.Right) { //case 2
          node = node.Parent;                   //case 2
          RotateLeft(node);                     //case 2
        }

        /**************/
        if ((node.Parent != null)) {           //case 3
          node.Parent.MakeBlack();             //case 3
          if (node.Parent.Parent != null) {    //case 3
            node.Parent.Parent.MakeRed();      //case 3
            RotateRight(node.Parent.Parent);   //case 3
          }
        }
        /********************/

      } else {                               //Parent is a right child

        if (node.Parent.Parent != null) {
          y = node.Parent.Parent.Left;
        }

        if ((y != null) && (y.IsRed)) {       //case 1
          node.Parent.MakeBlack();            //case 1
          y.MakeBlack();                      //case 1
          node.Parent.Parent.MakeRed();       //case 1
          node = node.Parent.Parent;

          if (node.IsRed) {
            continue;
          }

        } else if (node == node.Parent.Left) {  //case 2
          node = node.Parent;                   //case 2
          RotateRight(node);                    //case 2
        }

        /********************/
        if ((node.Parent != null)) {            //case 3
          node.Parent.MakeBlack();              //case 3
          if (node.Parent.Parent != null) {     //case 3
            node.Parent.Parent.MakeRed();       //case 3
            RotateLeft(node.Parent.Parent);     //case 3
          }
        }
        /*********************/

      } // end if

      _root.MakeBlack();

    } // end while
  } // end RBInsertFixUp() method




  /***************************************************************
   * RotateLeft Method
   * ************************************************************/
  private void RotateLeft(Node<TKey, TValue> x) {
    if (x.Right != null) {
      if (_debug) {
        Console.WriteLine("*******************************************************");
        Console.WriteLine("Left Rotate tree  with node x = {0}", x.Payload.Key);
        Console.WriteLine("Node color: {0} Node's parent color: {1}", x.Color,
                         (x.Parent != null) ? x.Parent.Color.ToString() : "x.Parent is null");
        Console.WriteLine("*******************************************************");
      }

      Node<TKey, TValue> y = x.Right;
      if (y != null) {
        x.Right = y.Left;
        if (y.Left != null) {
          y.Left.Parent = x;
        }
        y.Parent = x.Parent;
        if (x.Parent == null) {
          _root = y;
        } else if (x == x.Parent.Left) {
          x.Parent.Left = y;
        } else {
          x.Parent.Right = y;
        }

        y.Left = x;
        x.Parent = y;
      }

      _left_rotates++;
      if (_debug) {
        Console.WriteLine("*******************************************************");
        Console.WriteLine("After left rotate node x = {0}", x.Payload.Key);
        Console.WriteLine("Node x parent = {0}",
                         (x.Parent != null) ? x.Parent.Payload.Key.ToString() : "x parent is null");
        Console.WriteLine("Node color: {0} Node's parent color: {1}", x.Color,
                         (x.Parent != null) ? x.Parent.Color.ToString() : "x.Parent is null");
        Console.WriteLine("Left Rotates: {0}", _left_rotates);
        Console.WriteLine("*******************************************************");
      }
    }
  } // end RotateLeft() method



  /***************************************************************
   *  RotateRight Method
   * ************************************************************/
  private void RotateRight(Node<TKey, TValue> x) {
    if (x.Left != null) {
      if (_debug) {
        Console.WriteLine("*******************************************************");
        Console.WriteLine("Right Rotate tree  with node x = {0}", x.Payload.Key);
        Console.WriteLine("Node color: {0} Node's parent color: {1}", x.Color,
                         (x.Parent != null) ? x.Parent.Color.ToString() : "X.Parent == null");
        Console.WriteLine("*******************************************************");
      }

      Node<TKey, TValue> y = x.Left;
      if (y == null) {
        x.Left = null;
      } else {
        x.Left = y.Right;
        if (y.Right != null) {
          y.Right.Parent = x;
        }
        y.Parent = x.Parent;
        if (y.Parent == null) {
          _root = y;
        } else if (x == y.Parent.Left) {
          y.Parent.Left = y;
        } else {
          y.Parent.Right = y;
        }
        y.Right = x;
        x.Parent = y;
      }

      _right_rotates++;
      if (_debug) {
        Console.WriteLine("*******************************************************");
        Console.WriteLine("After right rotate node x = {0}", x.Payload.Key);
        Console.WriteLine("Node x parent = {0}",
                         (x.Parent != null) ? x.Parent.Payload.Key.ToString() : "x parent is null");
        Console.WriteLine("Node color: {0} Node's parent color: {1}", x.Color,
                         (x.Parent != null) ? x.Parent.Color.ToString() : "X.Parent == null");
        Console.WriteLine("Root = {0}", _root.Payload.Key);
        Console.WriteLine("Right Rotates: {0}", _right_rotates);
        Console.WriteLine("*******************************************************");
      }

    }
  } // end RotateRight() method


  /***************************************************************
   *  Search Method
   * ************************************************************/
  public Node<TKey, TValue> Search(TKey key) {
    int compare_result = 0;
    bool key_found = false;
    Node<TKey, TValue> node = _root;

    while (!key_found) {
      compare_result = key.CompareTo(node.Payload.Key);
      switch (compare_result) {
        case EQUALS: key_found = true;
          break;
        case LESSTHAN: if (node.Left == null) {
            return null;
          }
          node = node.Left;
          break;
        case GREATERTHAN: if (node.Right == null) {
            return null;
          }
          node = node.Right;
          break;

      }
    }

    return node;
  }


  /***************************************************************
   *  Delete Method
   * ************************************************************/
  public void Delete(Node<TKey, TValue> z) {
    if (z == null) return;
    Node<TKey, TValue> y = null;
    if ((z.Left == null) || (z.Right == null)) {
      y = z;
    } else {
      y = TreeSuccessor(z);
    }

    Node<TKey, TValue> x = null;

    if (y.Left != null) {
      x = y.Left;
    } else {
      x = y.Right;
    }
    if (x != null) {
      x.Parent = y.Parent;
    }

    if (y.Parent == null) {
      _root = x;
    } else if (y == y.Parent.Left) {
      y.Parent.Left = x;
    } else {
      y.Parent.Right = x;
    }

    if (y != z) {
      z.Payload = y.Payload;
    }

    if (y.IsBlack) {
      RBDeleteFixUp(x);
    }
    _count--;
  }



  /***************************************************************
   *  RBDeleteFixup
   * ************************************************************/
  private void RBDeleteFixUp(Node<TKey, TValue> x) {
    while ((x != null) && (x != _root) && (x.IsBlack)) {
      if (x == x.Parent.Left) {
        Node<TKey, TValue> w = x.Parent.Right;
        if ((w != null) && w.IsRed) {
          w.MakeBlack();
          x.Parent.MakeRed();
          RotateLeft(x.Parent);
          w = x.Parent.Right;
        }

        if ((w != null) && ((w.Left == null) || w.Left.IsBlack)
                        && ((w.Right == null) || w.Right.IsBlack)) {
          w.MakeRed();
          x = x.Parent;
          continue;

        } else if ((w != null) && w.Right.IsBlack) {
          w.Left.MakeBlack();
          w.MakeRed();
          RotateRight(w);
          w = x.Parent.Right;
        }

        /************************/
        if (w != null) {
          w.Color = x.Parent.Color;
          x.Parent.MakeBlack();
          w.Right.MakeBlack();

        }
        RotateLeft(x.Parent);
        x = _root;
        /***********************/

      } else {

        Node<TKey, TValue> w = x.Parent.Left;
        if ((w != null) && w.IsRed) {
          w.MakeBlack();
          x.Parent.MakeRed();
          RotateRight(x.Parent);
          w = x.Parent.Left;
        }

        if ((w != null) && ((w.Left == null) || w.Left.IsBlack)
                        && ((w.Right == null) || w.Right.IsBlack)) {
          w.MakeRed();
          x = x.Parent;
          continue;

        } else if ((w != null) && w.Left.IsBlack) {
          w.Right.MakeBlack();
          w.MakeRed();
          RotateLeft(w);
          w = x.Parent.Left;
        }

        /************************/
        if (w != null) {
          w.Color = x.Parent.Color;
          x.Parent.MakeBlack();
          w.Right.MakeBlack();

        }
        RotateRight(x.Parent);
        x = _root;
        /***********************/
      }

      x.MakeBlack();
      _root.MakeBlack();
    } // end while

  } // end RBDeleteFixUp



  /***************************************************************
   * TreeSuccessor Method
   * ************************************************************/
  private Node<TKey, TValue> TreeSuccessor(Node<TKey, TValue> node) {
    if (node.Right != null) {
      return TreeMinimum(node.Right);
    }
    Node<TKey, TValue> y = node.Parent;
    while ((y != null) && (node == y.Right)) {
      node = y;
      y = y.Parent;
    }
    return y;
  }


  /***************************************************************
   * TreeMinimum Method
   * ************************************************************/
  private Node<TKey, TValue> TreeMinimum(Node<TKey, TValue> node) {
    while (node.Left != null) {
      node = node.Left;
    }
    return node;
  }


  /***************************************************************
   *  TreeMaximum Method -- Not used in this program
   * ************************************************************/
  private Node<TKey, TValue> TreeMaximum(Node<TKey, TValue> node) {
    while (node.Right != null) {
      node = node.Right;
    }
    return node;
  }


  /***************************************************************
   *  GetEnumerator Method
   * ************************************************************/
  public IEnumerator GetEnumerator() {
    return this.ToArray().GetEnumerator();
  }


  /***************************************************************
   *  ToArray Method
   * ************************************************************/
  public KeyValuePair<TKey, TValue>[] ToArray() {
    KeyValuePair<TKey, TValue>[] _items = new KeyValuePair<TKey, TValue>[_count];
    int index = 0;
    this.WalkTree(_root, _items, ref index);
    return _items;

  }


  /***************************************************************
   *  WalkTree Method
   * ************************************************************/
  private void WalkTree(Node<TKey, TValue> node, KeyValuePair<TKey, TValue>[] items, ref int index) {
    if (node != null) {
      WalkTree(node.Left, items, ref index);
      items[index++] = node.Payload;
      if (_debug) {
        if (node == _root) {
          Console.WriteLine("**********ROOT NODE: {0}:{1}**********",
                            node.Payload.Value, node.Color);
        } else {
          Console.WriteLine("Walking Tree - Node visited: {0} Color: {1}",
                            node.Payload.Value, node.Color);
        }
      }
      WalkTree(node.Right, items, ref index);
    }
  }


  /***************************************************************
   * PrintTreeToConsole Method
   * ************************************************************/
  public void PrintTreeToConsole() {
    foreach (KeyValuePair<TKey, TValue> item in this) {
      if (item.Key.CompareTo(_root.Payload.Key) == 0) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(item.Key + " ");
        Console.ForegroundColor = ConsoleColor.White;
      } else {
        Console.Write(item.Key + " ");
      }
    }
    Console.WriteLine();
  }


  /***************************************************************
   *  PrintTreeStats Method
   * ************************************************************/
  public void PrintTreeStats() {
    Console.WriteLine("------------ Tree Stats --------------------");
    Console.WriteLine("First inserted key: {0}", _first_inserted_key);
    Console.WriteLine("Count: {0}", _count);
    Console.WriteLine("Left Rotates: {0}", _left_rotates);
    Console.WriteLine("Right Rotates: {0}", _right_rotates);
    Console.WriteLine("--------------------------------------------");
  }

  #endregion

} // end RedBlackTree class
