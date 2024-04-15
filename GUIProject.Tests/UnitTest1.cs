using FluentAssertions;
using GUIProject.Model;
using Xunit;

namespace GUIProject.Tests
{
    public class StudentTests
    {
        [Fact]
        public void CalculateGPAShouldReturnCorrectValue()
        {
            
            var student = new Student
            {
                Subject_1 = 80,
                Subject_2 = 60,
                Subject_3 = 50
            };

            
            var gpa = student.CalculateGPA();

           
            gpa.Should().Be(3.33);
        }

        [Fact]
        public void CalculateGPAShouldReturnValue()
        {
           
            var student = new Student
            {
                Subject_1 = 80,
                Subject_2 = 20,
                Subject_3 = 50
            };

            
            var gpa = student.CalculateGPA();

            
            gpa.Should().Be(2.33);
        }

        [Fact]
        public void CalculateGPAWithZeroCreditsShouldReturnZero()
        {
            
            var student = new Student
            {
                Subject_1 = 80,
                Subject_2 = 60,
                Subject_3 = 50
            };
            student.Subject_1 = 0;
            student.Subject_2 = 0;
            student.Subject_3 = 0;

            
            var gpa = student.CalculateGPA();

            
            gpa.Should().Be(0.0);
        }

        [Fact]
        public void CalculateGPAWithZeroPointsShouldReturnZero()
        {
            
            var student = new Student();

            
            var gpa = student.CalculateGPA();

            
            gpa.Should().Be(0.0);
        }
        
    }
}
