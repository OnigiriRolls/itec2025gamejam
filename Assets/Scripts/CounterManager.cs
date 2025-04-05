using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI scoresText;
    public GameObject panel;
    private float currentTime;
    private List<float> counters;

    void Awake()
    {
        counters = new List<float>();
    }

    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        counterText.text = $"Time: {currentTime:F2}s";
    }

    public void SaveTime() 
    { 
        var index = counters.Count;
        Debug.Log(index);
        counters.Add(currentTime);
        DisplayScores();
        panel.SetActive(true);
    }

    private void DisplayScores()
    {
        if (scoresText == null) return;

        string display = "";
        for (int i = 0; i < counters.Count; i++)
        {
            display += $"{i + 1}: {counters[i]:s}\n";
        }

        scoresText.text = display;
    }
}
