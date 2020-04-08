using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics getStatistics();
        string Name{ get; }
        event GradeAddedDelegate gradeAdded;
    }

    public class NamedObject{
        
        public NamedObject(string name){
            Name = name;
        }

        public string Name{
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name): base(name)
        {

        }

        public abstract event GradeAddedDelegate gradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics getStatistics();
        
    }


    public class InMemoryBook : Book
    {

        List<double> grades;

        const string category="Simple";
        

        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
            
        }

        public override void AddGrade(double grade){

            if(grade <= 100  && grade>0){
                grades.Add(grade);
                if(gradeAdded !=null)
                {
                    gradeAdded(this, new EventArgs());
                }
            }else{
                throw new ArgumentException($"Invalid {nameof(grade)}"); 
            }
        }

        public override event GradeAddedDelegate gradeAdded;

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A': 
                    AddGrade(90);
                    break;
                
                case 'B':
                    AddGrade(80);
                    break;

                default:
                    AddGrade(0);
                    break;
            }

        }


        public override Statistics getStatistics()
        {
            var result = new Statistics();
            
            foreach(var grade in grades){
                result.Add(grade);
            }
           
            return result;
        }
        
    }
}