using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningLogic : MonoBehaviour
{
    #region Singleton

    private static LearningLogic Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static LearningLogic GetInstace()
    {
        return Instance;
    }

    #endregion

    private PlayerStatsUI statsUI;
    private int amountOfPoints = 0;
    private ILearnable learningTarget;

    public bool IsPointsEnough(int cost)
    {
        return amountOfPoints >= cost;
    }
    

    public void Init(ILearnable _learningTarget, int _amountOfPoints)
    {
        learningTarget = _learningTarget;
        statsUI = PlayerStatsUI.GetInstace();
        amountOfPoints = _amountOfPoints;
    }

    public void PointEarned()
    {
        amountOfPoints++;
        statsUI.UpdPoints(true);
    }
    
    public void SkillLearned(int cost)
    {
        amountOfPoints -= cost;
        learningTarget.UpdateSkills(true, cost);
        statsUI.UpdSkills(true);
        statsUI.UpdPoints(amountOfPoints);
    }
    
    public void SkillForgot(int cost)
    {
        amountOfPoints += cost;
        learningTarget.UpdateSkills(false, cost);
        statsUI.UpdSkills(false);
        statsUI.UpdPoints(amountOfPoints);
    }
}
