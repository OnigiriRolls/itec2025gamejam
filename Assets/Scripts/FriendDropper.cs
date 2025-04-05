using System.Collections.Generic;
using UnityEngine;

public class FriendDropper : MonoBehaviour
{
    public List<CollectibleItem> possibleDrops;
    public Transform dropPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DropRandomCollectible();
        }
    }

    public void DropRandomCollectible()
    {
        if (possibleDrops.Count == 0) return;

        int index = Random.Range(0, possibleDrops.Count);
        var item = possibleDrops[index];

        if (item.prefab != null)
        {
            Instantiate(item.prefab, dropPoint.position, Quaternion.identity);
        }
    }
}
