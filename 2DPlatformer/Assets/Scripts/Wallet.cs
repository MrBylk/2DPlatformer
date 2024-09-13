using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _moneyCount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.TryGetComponent(out Coin coin))
        {
            _moneyCount++;
            coin.Collect();
        }
    }
}