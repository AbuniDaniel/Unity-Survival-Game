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
    public float knockbackPower=100;
    public float knockbackDuration=1;
    private Vector2 direction;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet = false;
    public float walkPointRange;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.GetComponent<EnemyGeneration>().target;
        rb = this.GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        //agent.enabled = false;
        //Invoke("EnableNavMeshAgent", 5f);
        //Invoke("WarpAgent", 5.2f);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void WarpAgent (){
    agent.Warp(transform.parent.position);
    }

    private void EnableNavMeshAgent (){
    agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    void FixedUpdate() {
        

        if(Vector2.Distance(transform.position, target.position) < range){
            direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            if(Vector2.Distance(transform.position, target.position) < range){
            agent.SetDestination(target.position);
            }
        }
        if(Vector2.Distance(transform.position, target.position) > range){
                Patroling();
            }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform, direction ));
        }    
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            direction = walkPoint - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            agent.SetDestination(walkPoint);
        if (Vector3.Distance(transform.position, walkPoint) < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {

        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);

        float xcheck = transform.position.x + randomX;
        float ycheck = transform.position.y + randomY;

        if(ycheck > 30)
            ycheck = 30;
        if(ycheck < -60)
            ycheck = -60;

        if(xcheck < -82)
            xcheck = -82;
        if(xcheck > 115)
            xcheck = 115;

        walkPoint = new Vector3(xcheck, ycheck, transform.position.z);

        walkPointSet = true;
    }
}
