using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Player player;

    private EarnLogic earnLogic;
    private LearningLogic learnLogic;
    private void Start()
    {
        earnLogic = GetComponent<EarnLogic>();
        earnLogic.Init(player);
        learnLogic = GetComponent<LearningLogic>();
        learnLogic.Init(player, player.GetPointsAmount());
    }
}
