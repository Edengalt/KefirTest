using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    
    #region Singleton

    private static PlayerStatsUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static PlayerStatsUI GetInstace()
    {
        return Instance;
    }

    #endregion
    
    [SerializeField] private TextMeshProUGUI pointsUI;
    [SerializeField] private TextMeshProUGUI skillsUI;
    
    private int points = 0;
    private int skills = 0;

    public void UpdSkills(bool raise)
    {
        skills += raise ? 1 : -1;
        skillsUI.text = skills.ToString();
    }

    public void UpdPoints(bool raise)
    {
        points += raise ? 1 : -1;
        pointsUI.text = points.ToString();
    }
    
    public void UpdPoints(int newPoints)
    {
        points = newPoints;
        pointsUI.text = points.ToString();
    }
}
