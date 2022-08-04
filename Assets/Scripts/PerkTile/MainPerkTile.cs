using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPerkTile : PerkTileBase
{
    private void Start()
    {
        foreach (var tile in connectedTiles)
            tile.SetPossibility(true);
    }

    public override bool IsPathToBaseExist(List<PerkTileBase> path)
    {
        return true;
    }

    public void ForgetAll()
    {
        RecursiveForget(this);
        Init();
        foreach (var tile in connectedTiles)
            tile.SetPossibility(true);
        foreach (var tile in connectedTilesBack)
            tile.SetPossibility(true);
    }
}
