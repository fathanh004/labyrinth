using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] CoinData coinData;
    [SerializeField] BaseAnimation baseAnimation;

    public int Value { get => coinData.value; }

    private void Start()
    {
        if (baseAnimation != null)
        {
            baseAnimation.Animate(visual);
        }
    }


}
