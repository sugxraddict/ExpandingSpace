using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.2f;
    [SerializeField] float rotationOffset = 100f;


    public static float desctructionDelay = 1.0f;

    Transform myTransform;
    Vector3 randomRotation;

    void Awake()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        myTransform.localScale = scale;

        //random rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }
	
	// Update is called once per frame
	void Update ()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime);
	}


    public void SelfDestruct()
    {
        float timer = Random.Range(0, desctructionDelay);

        Invoke("GoBoom", timer);
    }


    public void GoBoom()
    {
        GetComponent<Explosion>().BlowUp();
    }
}
