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
    private string[] diagram;
    public KindergartenGarden(string diagram) => this.diagram = diagram.Split("\n");

    public IEnumerable<Plant> Plants(string student)
    {
        var position = (student[0] - 'A') * 2;

        for (int i = 0; i < diagram.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                yield return GetPlant(diagram[i][position + j]);
            }
        }
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