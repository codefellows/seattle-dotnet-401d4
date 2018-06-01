using FizzBuzz;
using System;
using Xunit;

namespace FizzBuzzTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnsFizzFor3()
        {
            Program.FizzBuzz(3);
            Assert.Equal("Fizz", "Fizz");
        }

        [Fact]
        public void ReturnsBuzzFor5()
        {
            Program.FizzBuzz(5);
            Assert.Equal("Buzz", "Buzz");
        }

        [Fact]
        public void ReturnsFizzBuzzFor15()
        {
            Program.FizzBuzz(15);
            Assert.Equal("FizzBuzz", "FizzBuzz");
        }

        [Fact]
        public void ReturnsInteger()
        {
            Program.FizzBuzz(11);
            Assert.Equal("11", "11");
        }
    }
}
