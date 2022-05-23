using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour {

    public NavMeshSurface2d[] surfaces;

    // Use this for initialization
    void Start () 
    {
        BuildNav();
        InvokeRepeating("BuildNav", 0f, 5.0f);
    }

    void BuildNav(){
        for (int i = 0; i < surfaces.Length; i++) 
            {
                surfaces[i].BuildNavMesh();    
            }  
    }

}