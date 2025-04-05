using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
    public CollectibleItem item;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.Collect(item);
                Destroy(gameObject);
            }
        }
    }
}
