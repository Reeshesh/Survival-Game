using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public static PlayerState Instance {get; set;}

    public float currentHealth;
    public float maxHealth;

    public float currentCalories;
    public float maxCalories;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    public float currentHydrationPercent;
    public float maxHydrationPercent;

    private void Awake(){
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;
        currentHydrationPercent = maxHydrationPercent;

        StartCoroutine(decreasedHydration());

    }

    IEnumerator decreasedHydration()
    {
        while(true)
        {
            currentHydrationPercent -= 2;
            yield return new WaitForSeconds(10);
        }


    }

    // Update is called once per frame
    void Update()
    {

        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if(distanceTravelled >= 50)
        {
            distanceTravelled = 0;
            currentCalories -= 20;
        }


        if(Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth -= 10;
        }
    }


    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void setCalories(float newCalories)
    {
        currentCalories = newCalories;   
    }

    public void setHydration(float newHydration)
    {
        currentHydrationPercent = newHydration;   
    }
}