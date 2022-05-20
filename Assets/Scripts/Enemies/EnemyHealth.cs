using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth=40;
    public int currentHealth;
    public HealthBar healthBar;
    public UnityEvent OnHit, OnHeal, OnDead;
    public Rigidbody2D rb;
    public testcapsula test;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
         if (currentHealth <= 0)
        {
            OnDead?.Invoke();
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
