using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testcapsula : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    void FixedUpdate() {
        if(Vector2.Distance(transform.position, target.position) < range + 3){
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            if(Vector2.Distance(transform.position, target.position) < range){
            agent.SetDestination(target.position);
            }
        }
        
    }
}
