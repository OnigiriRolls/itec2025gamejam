using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI scoresText;
    public GameObject panel;
    private float currentTime;
    private bool stop = false;

    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        if (!stop)
        {
            currentTime += Time.deltaTime;
            counterText.text = $"Time: {currentTime:F2}s";
        }
    }

    public void SetStop()
    {
        stop = true;
    }

    public void SaveTime() 
    { 
        PlayerScores.Instance.AddCounter(currentTime);
        DisplayScores();
        if(panel != null)
            panel.SetActive(true);
    }

    private void DisplayScores()
    {
        if (scoresText == null) return;
        scoresText.text = PlayerScores.Instance.GetScoreText();
    }
}
