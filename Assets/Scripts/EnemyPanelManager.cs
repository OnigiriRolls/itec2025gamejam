using TMPro;
using UnityEngine;

public class EnemyPanelManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void StartEnemyIntro(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
