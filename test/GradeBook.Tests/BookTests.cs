using System;
using Xunit; 

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            var book = new InMemoryBook("");
            book.AddGrade(23.2);
            book.AddGrade(25.2);
            book.AddGrade(27.2);
           
            var result = book.getStatistics();
           
            Assert.Equal('F',result.letter);
            Assert.Equal(27.2,result.high, 1);
            Assert.Equal(23.2,result.low, 1);
            Assert.Equal(25.2,result.average, 1);
        }
    }
}
