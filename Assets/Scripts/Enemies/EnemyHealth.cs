using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth=40;
    public int currentHealth;
    public HealthBar healthBar;
    public UnityEvent OnHit, OnHeal, OnDead;
    NavMeshAgent agent;
    

    //dissolve
    Material material;

    bool isDissolving = false;
    float fade = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        if (currentHealth <= 0)
		{
			isDissolving = true;
            agent.speed=0;
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
            ScoreManager.instance.AddPoints(10);
            Destroy(gameObject, 1f);
            transform.parent.gameObject.GetComponent<EnemyGeneration>().SpawnNewObj();
        }
        else
        {
            OnHit?.Invoke();
        }
        healthBar.SetHealth(currentHealth);
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pickaxe"){
            TakeDamage(1);
            rb.AddForce(transform.position * (-200));
        }
    }
    */
}
