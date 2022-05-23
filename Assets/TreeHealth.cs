using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TreeHealth : MonoBehaviour
{

    public int maxHealth=40;
    public int currentHealth;
    public HealthBar healthBar;
    public UnityEvent OnHit, OnHeal, OnDead;
    public Rigidbody2D rb;

    Material material;

    bool isDissolving = false;
    float fade = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        if (currentHealth <= 0)
		{
			isDissolving = true;
		}

		if (isDissolving)
		{
			fade -= Time.deltaTime;

			if (fade <= 0f)
			{
				fade = 0f;
				isDissolving = false;
			}

			// Set the property
			material.SetFloat("_Fade", fade);
		}
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            ScoreManager.instance.AddPoints(3);
            Destroy(gameObject, 1f);
            transform.parent.gameObject.GetComponent<LevelGeneration>().SpawnNewObj();
        }
        else
        {
            OnHit?.Invoke();
        }
        healthBar.SetHealth(currentHealth);
    }
}
