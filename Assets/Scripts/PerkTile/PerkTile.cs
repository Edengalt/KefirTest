using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
    
public class PerkTile : PerkTileCanBeLearnd,IDeselectHandler
{
    private LearningLogic lLogicl;
    private PerkTileUI tileUI;
    protected override bool CanBeForgot
    {
        get => (CheckForwardForPath() && CheckBackForPath());
        set => base.CanBeForgot = value;
    }
    
    private void Start()
    {
        tileUI = GetComponent<PerkTileUI>();
        tileUI.Init(cost);
        lLogicl = LearningLogic.GetInstace();
    }

    #region Path
    public bool CheckBackForPath()
    {
        foreach (var backTile in connectedTilesBack.Where(forwardTile => forwardTile.Learned))
        {
            List<PerkTileBase> path = new List<PerkTileBase> {this};
            if (!backTile.IsPathToBaseExist(path)) return false;
        }
        return true;
    }
    public bool CheckForwardForPath()
    {
        bool allNotLearned = true;
        foreach (var forwardTile in connectedTiles.Where(forwardTile => forwardTile.Learned))
        {
            allNotLearned = false;
            List<PerkTileBase> path = new List<PerkTileBase> {this};
            if (forwardTile.IsPathToBaseExist(path)) return true;
        }
        return allNotLearned;
    }

    public override bool IsPathToBaseExist(List<PerkTileBase> path)
    {
        if (!Learned) return false;
        foreach (var backTile in connectedTilesBack.Where(backTile => !path.Contains(backTile)))
        {
            path.Add(backTile);
            if (backTile.IsPathToBaseExist(path))
                return true;
        }
        foreach (var forwardTile in connectedTiles.Where(forwardTile => !path.Contains(forwardTile)))
        {
            path.Add(forwardTile);
            if (forwardTile.IsPathToBaseExist(path)) return true;
        }

        return false;
    }

    #endregion
    
    #region Selection

    public override void Selected() 
        => contexMenu.Init((canBeLearned && lLogicl.IsPointsEnough(cost)), (Learned && CanBeForgot)); 
    
    public void OnDeselect(BaseEventData eventData) =>  contexMenu.Disable();

    #endregion

    public override void SetPossibility(bool Raise, bool instaSet = false)
    {
        if (instaSet)
        {
            Forget();
            canBeLearned = false;
            return;
        }
        if (Raise)
        {
            if(!Learned)
                canBeLearned = true;
        }
        else
        {
            if(!CheckForwardForPath()) canBeLearned = false;
        }
    }

    public override void Learn()
    {
        if (!canBeLearned)return;
        
        Learned = true;
        canBeLearned = false;
        
        foreach (var tile in connectedTiles)
            tile.SetPossibility(true);
        
        foreach (var tile in connectedTilesBack)
            tile.SetPossibility(true);
        
        tileUI.UpdImage(true);
        contexMenu.Disable(true);
        lLogicl.SkillLearned(cost);
    }
    
    public override void Forget()
    {
        if(!Learned) return;
        tileUI.UpdImage(false);
        Learned = false;
        if (CheckBackForPath())
            canBeLearned = true;
        lLogicl.SkillForgot(cost); 
        
        foreach (var tile in connectedTiles)
            tile.SetPossibility(false);
        
        contexMenu.Disable(true);
    }
}
