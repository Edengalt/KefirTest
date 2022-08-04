using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class PerkTileBase : MonoBehaviour
{
    [SerializeField] public bool Learned;
    public List<PerkTileBase> connectedTiles = new List<PerkTileBase>();
    public List<PerkTileBase> connectedTilesBack = new List<PerkTileBase>();
    public int cost;
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        connectedTiles = GetComponent<LineDrawer>().GetConnectedTiles();
        foreach (var forwardTile in connectedTiles)
        {
            forwardTile.SetBackConnection(this);
        }
    }
    public abstract bool IsPathToBaseExist(List<PerkTileBase> path);

    public virtual void SetPossibility(bool Raise, bool instaSet = false) { }
    public void SetBackConnection(PerkTileBase tile)
    {
        if (!connectedTilesBack.Contains(tile))
            connectedTilesBack.Add(tile);
        if(Learned)
            tile.SetPossibility(true);
    }

    protected void RecursiveForget(PerkTileBase tileBase)
    {
        SetPossibility(false,true);
        foreach (var forwardTile in tileBase.connectedTiles.Where(forwardTile => forwardTile.Learned))
        {
            forwardTile.RecursiveForget(forwardTile);
        }

        foreach (var backTile in tileBase.connectedTilesBack.Where(backTile => backTile.Learned))
        {
            backTile.RecursiveForget(backTile);
        }
    }

}
