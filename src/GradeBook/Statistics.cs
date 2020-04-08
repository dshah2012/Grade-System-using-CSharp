using System;

namespace GradeBook
{

    public class Statistics
    {

        public double average
        {
            get
            {
                return sum / count;
            }
        }
        public double high;
        public double low;
       
        public char letter
        {
            get
            {
                switch (average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                       
                    case var d when d >= 80.0:
                        return  'B';
                    
                    case var d when d >= 70.0:
                        return  'C';
                        
                    case var d when d >= 60.0:
                        return 'D';
                    
                    default:
                        return 'F';
                        
                }
            }


        }

        public double sum;

        public int count;

        public Statistics()
        {
            high = double.MinValue;
            low = double.MaxValue;
        }

        public void Add(double number)
        {
            sum += number;
            count += 1;
            high = Math.Max(number, high);
            low = Math.Min(number, low);
        }

    }

}