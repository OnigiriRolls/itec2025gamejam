using UnityEngine;

public class FriendController : MonoBehaviour
{
    public float healthGiven;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().GiveLife(healthGiven);
        }
    }
}
