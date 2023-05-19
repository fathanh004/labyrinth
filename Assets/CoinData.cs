using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin Data", menuName = "ScriptableObjects/Coin Data")]
public class CoinData : ScriptableObject
{
    public int value;
    public Material material;

}
