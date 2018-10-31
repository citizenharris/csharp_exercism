using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;
    private List<string> _names = new List<string>();
    public Robot() => Reset();
    public string Name
    {
      get { return _name; }
    }

    public void Reset()
    {
        do
        {
            RoboName();
        } while (_names.IndexOf(_name) != -1);
        _names.Add(_name);
    }

    public void RoboName()
    {
        _name = string.Empty;
        var rand = new Random();
        for(int i = 0; i < 5; i++)
        {
            if(i< 2)
            {
                _name += (char)rand.Next('A', 'Z');
            }
            else
            {
                _name += (char)rand.Next('0', '9');
            }
        }
    }
}