using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth=20;
    public int currentHealth;
    public HealthBar healthBar;
    public UnityEvent onDead;

    void Start()
    {
        Time.timeScale=1;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(Healing());
        
    }
    void Update()
    {

        if( Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        if( currentHealth <= 0)
        {

            onDead?.Invoke();
            Time.timeScale=0;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            TakeDamage(1);
        
        }
    }

    IEnumerator Healing(){
         while (true){ 
     if (currentHealth < maxHealth){ 
       currentHealth += 1;
       healthBar.SetHealth(currentHealth);
       yield return new WaitForSeconds(5);
     } else {
       yield return null;
     }
   }
     }


}
