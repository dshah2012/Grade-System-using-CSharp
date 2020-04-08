using System;
using Xunit; 

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPoint(){
            WriteLogDelegate log = returnMessage;
            log += returnMessage;
            log += IncrementCount;
            var result = log("Hello!");
            Assert.Equal(3, count);
        }
        
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }


        string returnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x){
            x = 42;
        }

        private int GetInt(){
            return 10;
        }  

        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name){
            book = new InMemoryBook(name);   
        }


        [Fact]
        public void CSharpPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name){
            book = new InMemoryBook(name);   
        }

        [Fact]
        public void canSetNameForReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(InMemoryBook book, string name){
            book.Name = name;
        }

        [Fact]
        public void stringsBehaveLikeValue(){
            string name = "Darshan";
            var upper = MakeUpperCase(name);
            Assert.Equal("DARSHAN", upper);
            Assert.Equal("Darshan", name);
        }

        private string MakeUpperCase(string parameter){
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookNewObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);
        }


         [Fact]
        public void TwoObjectSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(String name)
        {
            return new InMemoryBook(name);
        }
    }
}
