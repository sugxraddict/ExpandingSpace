using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour
{

    public GameObject player;
    //public Transform target;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame2
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;
        //transform.LookAt(target); (Zorgt ervoor dat de camera naar een target kijkt)
    }
}
