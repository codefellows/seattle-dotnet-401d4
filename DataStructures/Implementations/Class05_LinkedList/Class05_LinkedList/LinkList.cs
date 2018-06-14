using System;
using System.Collections.Generic;
using System.Text;

namespace Class05_LinkedList
{
	public class LinkList
	{
		/// <summary>
		/// Always points to the first node in a LL.
		/// </summary>
		public Node Head { get; set; }

		/// <summary>
		/// The node that is used to traverse through the LinkedList
		/// </summary>
		public Node Current { get; set; }

		/// <summary>
		/// Requiring at least one node to be present for a LL to be created
		/// </summary>
		/// <param name="node"></param>
		public LinkList(Node node)
		{
			Head = node;
			Current = node;
		}

		//Adding a Node O(1)

		public void Add(Node node)
		{
			Current = Head;
			node.Next = Head;
			Head = node;
			Current = Head;
		}

		// Print out Nodes O(n)

		public void Print()
		{
			Current = Head;

			while (Current.Next != null)
			{
				Console.Write($"{Current.Value} --> ");
				Current = Current.Next;
			}

			Console.Write($"{Current.Value} --> NULL");
		}


		public int CountNodes()
		{
			Current = Head;
			int counter = 0;

			while (Current.Next != null)
			{
				counter++;
				Console.Write($"{Current.Value} --> ");
				Current = Current.Next;
			}
			counter++;
			Console.Write($"{Current.Value} --> NULL");

			return counter;
		}

		/// <summary>
		/// Finds a node with a specified Value. 
		/// Big O of this is O(n)
		/// </summary>
		/// <param name="value">value to search</param>
		/// <returns>Node that contains the value</returns>
		public Node Find(int value)
		{
			Current = Head;

			while (Current.Next != null)
			{
				if (Current.Value == value)
				{
					return Current;
				}
				Current = Current.Next;
			}

			return Current.Value == value ? Current : null;
		}

		// Add Before O(n)

		public void AddBefore(Node newNode, Node existingNode)
		{
			//Reset our Current to the beginning of the Linked List
			Current = Head;
			if (Head.Value == existingNode.Value)
			{
				Add(newNode);
				return;
			}

			while (Current.Next != null)
			{

				if (Current.Next.Value == existingNode.Value)
				{
					newNode.Next = existingNode;
					Current.Next = newNode;
					return;
				}
				Current = Current.Next;
			}


		}

		// Add After O(n)

		public void AddLast(Node newNode)
		{
			Current = Head;
			while (Current.Next != null)
			{
				Current = Current.Next;
			}

			Current.Next = newNode;
		}

		// Add Last O(n)



	}
}
