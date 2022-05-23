using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] objects;

    public Transform target;

    void Start(){
        int rand = Random.Range(0, objects.Length);
        var instant = Instantiate(objects[rand], transform.position, Quaternion.identity);
        instant.transform.parent = gameObject.transform;
    }

    public void SpawnNewObj(){
        StartCoroutine(SpawnAfterTime());
    }

    IEnumerator SpawnAfterTime(){
        yield return new WaitForSeconds(Random.Range(30, 60));
        int rand = Random.Range(0, objects.Length);
        var instant = Instantiate(objects[rand], transform.position, Quaternion.identity);
        instant.transform.parent = gameObject.transform;
    }
}
