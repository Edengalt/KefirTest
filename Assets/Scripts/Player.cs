using Unity.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IEarnable, ILearnable
{
    [SerializeField] private int amountOfPoints = 0;
    [SerializeField] private int amountOfSkills = 0;
    
    public void Earn()
    {
        amountOfPoints++;
    }

    public void UpdateSkills(bool learned, int cost)
    {
        amountOfSkills += learned ? 1 : -1;
        amountOfPoints += learned ? -cost : cost;
    }

    public int GetPointsAmount()
    {
        return amountOfPoints;
    }
    
    public int GetSkillsAmount()
    {
        return amountOfSkills;
    }
}
