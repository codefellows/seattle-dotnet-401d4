using System;
using Xunit;
using Class05_LinkedList;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddNode()
        {
			// Arrange
			LinkList ll = new LinkList(new Node(4));
			Node node = new Node(8);
	        Node node2 = new Node(15);

			//Act
	        ll.Add(node);
			ll.Add(node2);

			/*
			 15 <- 8 <- 4
			 */

	        //Assert

	        Assert.Equal(ll.Head.Value, node2.Value);

        }

		[Theory]
		[InlineData(8, 8)]
		[InlineData(23, 23)]
		public void CanFindNodeThatExists(int value, int expected)
	    {
		    //Arrange
			LinkList ll = new LinkList(new Node(4));
		    Node node = new Node(8);
		    Node node2 = new Node(15);
		    Node node3 = new Node(16);
		    Node node4 = new Node(23);

		    ll.Add(node);
		    ll.Add(node2);
		    ll.Add(node3);
		    ll.Add(node4);

			//Act

			Node found = ll.Find(value);

		    //Assert
		    Assert.Equal(expected, found.Value);

	    }


		[Theory]
		[InlineData(42)]
		[InlineData(100)]
		public void ReturnsNullForNodeThatDoesNotExist(int value)
		{
			//Arrange
			LinkList ll = new LinkList(new Node(4));
			Node node = new Node(8);
			Node node2 = new Node(15);
			Node node3 = new Node(16);
			Node node4 = new Node(23);

			//Act
			ll.Add(node);
			ll.Add(node2);
			ll.Add(node3);
			ll.Add(node4);

			Node found = ll.Find(value);

			//Assert
			Assert.Null(found);
		}
	}
}
