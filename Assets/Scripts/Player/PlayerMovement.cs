using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    Vector2 movement;
    Vector2 mousePos;

    // pentru attack
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public LayerMask whatIsNeutral;
    public float attakRange;
    public int damage;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Time.time >= nextAttackTime){
            if (Input.GetMouseButtonDown(0)){
                animator.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attakRange, whatIsEnemies);
                Collider2D[] neutralToDamage = Physics2D.OverlapCircleAll(attackPos.position, attakRange, whatIsNeutral);

                for (int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                }
               
                for (int i = 0; i < neutralToDamage.Length; i++){
                    neutralToDamage[i].GetComponent<TreeHealth>().TakeDamage(damage);
                }
                nextAttackTime = Time.time + 1f / attackRate;
        }
        }
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attakRange);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }
    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj, Vector3 direction)
    {
        float timer=0;
        while (knockbackDuration> timer)
        {
            Input.ResetInputAxes();
            timer += Time.fixedDeltaTime;
            rb.AddForce( direction.normalized * knockbackPower );
            yield return 0;
        }
        
    }

}
