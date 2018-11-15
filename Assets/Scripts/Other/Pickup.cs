using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider))]
public class Pickup : MonoBehaviour
{
    static int points = 100;

    [SerializeField] float rotationOffset = 100f;

    bool gotHit = false;
    Transform myTransform;
    Vector3 randomRotation;
    //rotate the pickup



    void Awake()
    {
        myTransform = transform;
    }



    void Start()
    {
        //random rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    void Update()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime);
    }
    

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("Player"))
        {
            if(!gotHit)
            {
                PickupHit();
            }
        }
    }



    public void PickupHit()
    {
        if (!gotHit)
        {
            gotHit = true;

            //Debug.Log("Player hit us!");

            EventManager.ScorePoints(points);
            EventManager.ReSpawnPickup();
            Destroy(gameObject);
        }
    }
}
