using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (PlayerScores.Instance.GetIntroShown())
        {
            gameObject.SetActive(false);
            player.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerScores.Instance.SetIntroShown(true);
        player.SetActive(true);
    }
}
