using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade cannot be negative number.");
        }
        if (minGrade < 0)
        {
            throw new ArgumentException("minGrade cannot be negative number.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Min grade is bigger than max grade.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("There aren't exist comments.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}