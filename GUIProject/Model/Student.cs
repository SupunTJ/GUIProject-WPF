using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUIProject.Model;


namespace GUIProject.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Subject_1 { get; set; }
        public double Subject_2 { get; set; }
        public double Subject_3 { get; set; }

        private double _GPA;
        public double GPA { get => CalculateGPA(); set => _GPA = 0.0; }

        public double CalculateGPA()
        {
            double totalPoints;
            double totalCredits;

            int CreditSub1 = 3;
            int CreditSub2 = 2;
            int CreditSub3 = 1;

            double Sub1_grade;
            double Sub2_grade;
            double Sub3_grade;

            double gpa; // making the logic of GPA calculation
            /////////////////////////////////////////////////
            if (Subject_1 > 75)
            {
                Sub1_grade = 4;
            }
            else if (Subject_1 > 65)
            {
                Sub1_grade = 3;
            }
            else if (Subject_1 > 45)
            {
                Sub1_grade = 2;
            }

            else
            {
                Sub1_grade = 0;
            }
            ////////////////////////////////////////////////////////////////////
            if (Subject_2 > 75)
            {
                Sub2_grade = 4;
            }
            else if (Subject_2 > 55)
            {
                Sub2_grade = 3;
            }
            else if (Subject_2 > 45)
            {
                Sub2_grade = 2;
            }
            else
            {
                Sub2_grade = 0;
            }
            /////////////////////////////////////////////////////////////////
            if (Subject_3 > 75)
            {
                Sub3_grade = 4;
            }
            else if (Subject_3 > 55)
            {
                Sub3_grade = 3;
            }
            else if (Subject_3 > 45)
            {
                Sub3_grade = 2;
            }
            else
            {
                Sub3_grade = 0;
            }

            totalPoints = Sub3_grade * CreditSub3 + Sub2_grade * CreditSub2 + Sub1_grade * CreditSub1;
            totalCredits = CreditSub1 + CreditSub2 + CreditSub3;

            if (totalCredits == 0 || totalPoints == 0)
            {
                gpa = 0;
            }
            else
            {
                gpa = totalPoints / totalCredits;
            }

            return Math.Round(gpa,4);
        }
    }
}
