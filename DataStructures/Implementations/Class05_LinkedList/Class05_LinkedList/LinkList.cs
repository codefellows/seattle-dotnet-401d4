using System;
using System.Collections.Generic;
using System.Text;

namespace Class05_LinkedList
{
	class LinkList
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

		/// <summary>
		/// Finds a node with a specified Value. 
		/// Big O of this is O(n)
		/// </summary>
		/// <param name="value">value to search</param>
		/// <returns>Node that contains the value</returns>
		public Node Find(int value)
		{
			// Always reset the Current runner to Head. 
			Current = Head;

			while (Current.Next != null)
			{
				if (Current.Value == value)
				{
					return Current;
				}

				//Move the Current runner to the next node in the list.
				Current = Current.Next;

			}

			return Current.Value == value ? Current : null;
		}

		// Add Before O(n)

		// Add After O(n)

		// Add Last O(n)



	}
}
