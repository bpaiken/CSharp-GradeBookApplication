using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            var rankedGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(rankedGrades[threshold - 1] < averageGrade)
                return 'A';
            else if (rankedGrades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if(rankedGrades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if(rankedGrades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F'; 
        }
    }
}
