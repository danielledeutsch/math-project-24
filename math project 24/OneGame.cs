using System;

namespace YourNamespace
{
    public class OneGame
    {
        private int num1;
        private int num2;
        private string question;
        private int grade;

        public int Num1 { get { return num1; } }
        public int Num2 { get { return num2; } }
        public string Question { get { return question; } }
        public double CorrectAnswer { get { return CalculateAnswer(); } }

        public OneGame(int grade)
        {
            this.grade = grade;

            Random random = new Random();

            num1 = random.Next(1, 15);
            GetSecondNumber(random);
            GenerateQuestion();
        }

        public int GetGrade()
        {
            return grade;
        }

        private void GetSecondNumber(Random random)
        {
            // לוודא שבכל הכיתות חוץ מ-ד המספר השני קטן מהראשון כדי שלא יהיה מצב שהתשובה שלילית
            num2 = grade != 4 ? random.Next(1, num1) : random.Next(1, 15);
        }

        private void GenerateQuestion()
        {
            switch (grade)
            {
                case 1:
                    // כיתה א- חיבור
                    question = $"{num1} + {num2} = ";
                    break;
                case 2:
                    // כיתה ב- חיסור
                    question = $"{num1} - {num2} = ";
                    break;
                case 3:
                    // כיתה ג- כפל
                    question = $"{num1} x {num2} = ";
                    break;
                case 4:
                    // כיתה ד- חילוק
                    question = $"{num1 * num2} ÷ {num2} = ";
                    break;
                default:
                    throw new ArgumentException("Invalid grade parameter.");
            }
        }

        private double CalculateAnswer()
        {
            switch (grade)
            {
                case 1:
                    // כיתה א
                    return num1 + num2;
                case 2:
                    // כיתה ב
                    return num1 - num2;
                case 3:
                    // כיתה ג
                    return num1 * num2;
                case 4:
                    // כיתה ד
                    // לוודא שהמספר השני לא 0
                    if (num2 != 0)
                    {
                        // לוודא שהתשובה לא תהיה מספר עשרוני
                        return (double)num1 * num2 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return 0;
                    }
                default:
                    throw new ArgumentException("Invalid grade parameter.");
            }
        }
    }
}

