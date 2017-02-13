using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer renderer;
    private Color storedColour;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        renderer = GetComponent<Renderer>();
        storedColour = renderer.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
        }
        if (flashCounter <= 0)
        {
            renderer.material.color = storedColour;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;
        renderer.material.SetColor("_Color", Color.white);
    }
}
