using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private string _diagram;
    private string _studentOrder = "ABCDEFGHIJKL";
    public KindergartenGarden(string diagram) => _diagram = diagram;

    public IEnumerable<Plant> Plants(string student)
    {
        var position = _studentOrder.IndexOf(student[0]) * 2;
        
        string[] output = _diagram.Split("\n");
        output[0] = output[0].Substring(position, 2); 
        output[1] = output[1].Substring(position, 2); 
        
        Plant[] plants = new Plant[4];
        var index = 0;
        foreach (var line in output)
        {
            foreach (var plant in line)
            {
                plants[index] = GetPlant(plant);
                index++;
            }
        }
        return plants;
    }

    public Plant GetPlant(char plant)
    {
        switch (plant)
        {
            case 'C':
                return Plant.Clover;
            case 'G':
                return Plant.Grass;
            case 'R':
                return Plant.Radishes;
            case 'V':
                return Plant.Violets;
            default:
                throw new ArgumentException("Unknown plant");
        }
    }
}