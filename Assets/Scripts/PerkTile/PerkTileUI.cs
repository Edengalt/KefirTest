using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkTileUI : MonoBehaviour
{
    [SerializeField] private Sprite[] learnedImg;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private Image img;

    public void Init(int _cost)
    {
        cost.text = _cost.ToString();
    }

    public void UpdImage(bool learned)
    {
        img.sprite = learnedImg[learned ? 0 : 1];
    }
}
