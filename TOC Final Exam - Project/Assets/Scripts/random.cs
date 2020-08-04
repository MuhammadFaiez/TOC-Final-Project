using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject collecttible;

    Vector3 position;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

        int spawned = 0;
        while (spawned < 9)
        {

            position = new Vector3(Random.Range(-20, 24f), 0.5f, Random.Range(9, 30));
            Instantiate(collecttible, position, Quaternion.identity);
            spawned++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
