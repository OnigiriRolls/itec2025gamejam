using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float timeDamage = 0.1f;
    public Slider healthSlider;
    public CounterManager counterManager;

    void Start()
    {
        health = 100;
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
            healthSlider.value -= damage;
        }
        else 
        {
            counterManager.SaveTime();
            Debug.Log("game over");
        }
    }
}
