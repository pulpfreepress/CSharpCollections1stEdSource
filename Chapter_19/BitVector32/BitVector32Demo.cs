/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Specialized;

public class BitVector32Demo {
  public static void Main(){
    // Store and access individual bit values using masks
    BitVector32 bv1 = new BitVector32(0);
	Console.WriteLine("bv1 intial value: \t" + (Convert.ToString(bv1.Data, 2)).PadLeft(32, '0'));
	
	int bit1 = BitVector32.CreateMask();
	int bit2 = BitVector32.CreateMask(bit1);
	int bit3 = BitVector32.CreateMask(bit2);
	
	bv1[bit1] = true;
	bv1[bit3] = true;
	
	Console.WriteLine("bv1 b1 and b3 true: \t" + (Convert.ToString(bv1.Data, 2)).PadLeft(32, '0'));
	Console.WriteLine("------------------------------------------------------");
	
	// Store and access larger values using sections
	
	BitVector32 bv2 = new BitVector32(0);
	Console.WriteLine("bv2 intial value: \t" + (Convert.ToString(bv2.Data, 2)).PadLeft(32, '0'));
	
	BitVector32.Section s1 = BitVector32.CreateSection(8); // uses first 4 bits
	BitVector32.Section s2 = BitVector32.CreateSection(4, s1); // uses next 3 bits following s1
	
	bv2[s1] = 6;
	bv2[s2] = 4;
	
	Console.WriteLine("bv2 s1 and s2: \t\t" + (Convert.ToString(bv2.Data, 2)).PadLeft(32, '0'));
  }
}