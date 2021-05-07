using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    private const float minForce = 10f;
    private const float maxForce = 15f;
    private const float minTorque = -10f;
    private const float maxTorque = 10f;
    private const float minPos = -4f;
    private const float maxPos = 4f;
    private const float ySpawnPos = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        RandomForce();
        RandomTorque();
        RandomSpawnPos(); 
        
    }

    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce), 
            ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque), 
            Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), 
            ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minPos, maxPos), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
