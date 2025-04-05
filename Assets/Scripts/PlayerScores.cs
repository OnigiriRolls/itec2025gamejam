using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    public static PlayerScores Instance;
    private List<float> counters = new();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCounter(float counter)
    {
        counters.Add(counter);
    }

    public string GetScoreText()
    {
        string display = "";
        for (int i = 0; i < counters.Count; i++)
        {
            display += $"Score {i + 1}: {counters[i].ToString("F2", CultureInfo.InvariantCulture)}\n";
        }

        return display;
    }
}
