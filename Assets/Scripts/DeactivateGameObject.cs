using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public GameObject player;
    public GameObject introCamera;
    public GameObject counterManager;

    void Start()
    {
        if (PlayerScores.Instance.GetIntroShown())
        {
            gameObject.SetActive(false);
            player.SetActive(true);
            counterManager.SetActive(true);
            if (introCamera != null)
                introCamera.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        PlayerScores.Instance.SetIntroShown(true);
        player.SetActive(true);
        counterManager.SetActive(true);
    }
}
