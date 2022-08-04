using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerkTileCanBeLearnd : PerkTileBase
{
    [SerializeField] protected bool canBeForgot;
    [SerializeField] protected bool canBeLearned;
    protected virtual bool CanBeForgot
    {
        get => false;
        set => canBeForgot = value;
    }
    [SerializeField] protected ButtonsController contexMenu;
    public abstract void Learn();
    public abstract void Forget();
    public abstract void Selected();
}
