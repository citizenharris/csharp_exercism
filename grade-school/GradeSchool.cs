using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string, int> _roster = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        _roster.Add(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        var students = from student in _roster 
                    orderby student.Value, student.Key ascending
                    select student.Key;
        return students.ToArray();
    }

    public IEnumerable<string> Grade(int grade)
    {
        var students = from student in _roster
                   where student.Value == grade
                   orderby student.Key ascending
                   select student.Key;
        return students.ToArray();
    }
}