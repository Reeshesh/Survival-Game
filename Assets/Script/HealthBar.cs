using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Text healthCounter;

    public GameObject playerState;

    private float currentHealth, maxHealth;


    // Start is called before the first frame update
    void Awake()
    {

        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHealth + "/" + maxHealth;


         if (currentHealth <= 0)
        {
            // Call a game over function or end the game here
            GameOver();
        }
    }

    private void GameOver()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("ExitGame");
    }
}
