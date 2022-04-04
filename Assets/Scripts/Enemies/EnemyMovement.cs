using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Rigidbody2D caracterRigidbody;
    public PlayerHealth caracter;
    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = -angle;
        direction.Normalize();
        movement = direction;
        
    }
    private void FixedUpdate() {

       if(Vector2.Distance(transform.position, player.position) < 4){
             moveCharacter(movement);
        }
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
}