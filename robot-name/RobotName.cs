using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;
    private List<string> _names = new List<string>();
    public Robot() => Reset();
    public string Name
    {
      get => _name;
    }

    public void Reset()
    {
        do { RoboName(); } 
        while (_names.IndexOf(_name) != -1);
        _names.Add(_name);
    }

    public void RoboName()
    {
        _name = string.Empty;
        var rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            _name += i < 2
                ? (char)rand.Next('A', 'Z')
                : (char)rand.Next('0', '9');
        }
    }
}