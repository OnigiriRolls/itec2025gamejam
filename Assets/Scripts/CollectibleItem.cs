using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItem", menuName = "Collectibles/CollectibleItem")]
public class CollectibleItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject prefab;
    public GameObject projectilePrefab; 
    public float damage;
    public string description;
}
