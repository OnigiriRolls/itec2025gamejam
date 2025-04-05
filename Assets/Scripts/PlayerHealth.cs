using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float timeDamage = 0.1f;
    public CounterManager counterManager;
    public Slider healthSlider;
    private bool gameOver = false;

    void Start()
    {
        Debug.Log("start");
        Debug.Log(health);
        Debug.Log(healthSlider.value);
        health = 100;
        healthSlider.value = health;
        gameOver = false;
    }

    void Update()
    {
        LoseLife(timeDamage);
    }

    public void LoseLife(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
            Debug.Log("Scade" + health);
            healthSlider.value = health;
        }
        else if(!gameOver)
        {
            Debug.Log("save time + " + health);
            if(counterManager != null)
                counterManager.SaveTime();
            gameOver = true;
        }
    }
}
