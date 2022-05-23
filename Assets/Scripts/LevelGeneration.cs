using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;

    void Start(){
        int rand = Random.Range(0, objects.Length);
        var instant = Instantiate(objects[rand], transform.position, Quaternion.identity);
        instant.transform.parent = gameObject.transform;
    }

    public void SpawnNewObj(){
        StartCoroutine(SpawnAfterTime());
    }

    IEnumerator SpawnAfterTime(){
        yield return new WaitForSeconds(Random.Range(5, 7));
        int rand = Random.Range(0, objects.Length);
        var instant = Instantiate(objects[rand], transform.position, Quaternion.identity);
        instant.transform.parent = gameObject.transform;
    }
}
