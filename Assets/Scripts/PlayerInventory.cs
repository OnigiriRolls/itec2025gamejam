using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public CollectibleItem collectedItem;
    public Image itemImage;
    public Transform shootPoint;
    public Camera mainCamera;

    public void Collect(CollectibleItem item)
    {
        collectedItem = item;
        if (item.icon != null)
            itemImage.sprite = item.icon;
        Debug.Log("Collected: " + item.itemName);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && collectedItem != null)
        {
            Debug.Log("mouse");
            UseItem();
        }
    }

    public void UseItem()
    {
        Debug.Log("use item");
        if (collectedItem != null)
        {
            Debug.Log("if 1");
            if (collectedItem.projectilePrefab != null)
            {
                Debug.Log("if 2");
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log("if 3");
                    Vector3 direction = (hit.point - shootPoint.position).normalized;

                    var proj = Instantiate(collectedItem.projectilePrefab, shootPoint.position, Quaternion.LookRotation(direction));
                    proj.GetComponent<Projectile>()?.Initialize(collectedItem.damage);
                }
            }
        }
    }
}
