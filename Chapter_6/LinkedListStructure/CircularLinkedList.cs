/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class CircularLinkedList<T> {
    // private fields
    private Node<T> _head = null;
    private Node<T> _tail = null;
    private int _count = 0;

    // constructor
    public CircularLinkedList() {}

    // read-only  properties
    public int Count {
        get { return _count; }
    }

    public Node<T> First {
        get { return _head; }
    }

    public Node<T> Last {
        get { return _tail; }
    }

    // methods
    public Node<T> AddFirst(T value) {
        if (value == null) throw new ArgumentNullException();
        Node<T> node = new Node<T>();
        node.Value = value;
        if (_head == null) {
            // list is empty
            _head = node;
            _tail = node;
            node.Previous = _tail;
            node.Next = _head;
            _count++;
        } else {
            _head.Previous = node;
            node.Next = _head;
            node.Previous = _tail;
            _tail.Next = node;
            _head = node;
            _count++;
        }
        return node;
    }

    public Node<T> AddLast(T value) {
        if (value == null) throw new ArgumentNullException();
        if (_tail == null) {
            // list is empty
            return this.AddFirst(value);
        }
        Node<T> node = new Node<T>();
        node.Value = value;
        node.Next = _tail.Next;
        node.Previous = _tail;
        _tail.Next = node;
        _tail = node;
        _count++;
        return node;
    }

    public Node<T> AddBefore(Node<T> node, T value) {
        if ((value == null) || (node == null)) throw new ArgumentNullException();
        if (node == _head) {
            return this.AddFirst(value);
        }

        Node<T> new_node = new Node<T>();
        new_node.Value = value;
        new_node.Previous = node.Previous;
        node.Previous = new_node;
        new_node.Next = node;
        new_node.Previous.Next = new_node;
        _count++;
        return new_node;
    }

    public Node<T> AddAfter(Node<T> node, T value) {
        if ((value == null) || (node == null)) throw new ArgumentNullException();
        if (node == _tail) {
            return this.AddLast(value);
        }

        Node<T> new_node = new Node<T>();
        new_node.Value = value;
        new_node.Previous = node;
        new_node.Next = node.Next;
        node.Next.Previous = new_node;
        node.Next = new_node;
        _count++;
        return new_node;
    }

    public void Remove(Node<T> node) {
        if (node == null) throw new ArgumentNullException();
		if(this.Find(node)){
			node.Next.Previous = node.Previous;
			node.Previous.Next = node.Next;
			if (node == _head) {
				_head = node.Next;
			}
			if (node == _tail) {
				_tail = node.Previous;
			}
			node.Next = null;
			node.Previous = null;
			_count--;
			if(_count == 0){
			  _head = null;
			  _tail = null;
			}
		} else {  // throw an exception because the node does not belong to this list anymore...
		   throw new InvalidOperationException("Node does not belong to this linked list!");
		}
    }

    public Node<T> Find(T value) {
        if (value == null) throw new ArgumentNullException();
        Node<T> current_node = _head;
        for (int i = 0; i < _count; i++) {
            if (current_node.Value.Equals(value)) {
                return current_node;
            } else {
                current_node = current_node.Next;
            }
        }
        return null; // return null if value not found in list
    }

	private bool Find(Node<T> node){
	   if(node == null) throw new ArgumentNullException();
	   if(_count == 0) return false;
	   if(_head == node) return true;
	   Node<T> temp_node = _head;
	   for(int i = 0; i < _count; i++){
	     if(temp_node.Next == node) return true;
		 temp_node = temp_node.Next;
	   }
	   return false;
	}
    
} // end CircularLinkedList<T> class definition