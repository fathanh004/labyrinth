using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PlayManager playManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            playManager.AddCoin(coin.Value);
            Destroy(other.gameObject);
        }
    }
}
