using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = .5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;
    
    private float vol = 1.0f;
    public AudioClip soundShoot;
    private AudioSource shootSound;
    LineRenderer line;
    Light laserLight;
    bool canFire;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }

    void Start()
    {
        line.enabled = false;
        laserLight.enabled = false;
        canFire = true;
        shootSound = GetComponent<AudioSource>();
    }



    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            float vol = 1.0f;
            ShootSound.PlayOneShot(soundShoot, vol);
        }*/
        //Debug.DrawRay(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * maxDistance, Color.yellow);
    }

    Vector3 CastRay()
    {
        RaycastHit hit;
        

        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            SpawnExplosion(hit.point, hit.transform);

            if (hit.transform.CompareTag("Enemy"))
            {
                //ZORG DAT ENEMY DOOD KAN!
            }

            return hit.point;
        }

        return transform.position + (transform.forward * maxDistance);
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosion temp = target.GetComponent<Explosion>();
        if (temp != null)
        {
            temp.AddForce(hitPosition, transform);
        }
    }

    public void FireLaser()
    {
        Vector3 pos = CastRay();
        FireLaser(pos);

        // FireLaser(CastRay());
    }

    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if (canFire)
        {
            if(target != null)
            {
                SpawnExplosion(targetPosition, target);
            }

            line.SetPosition(0, transform.position);
            line.SetPosition(1, targetPosition);
            line.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);
            shootSound.PlayOneShot(soundShoot, vol);
        }
    }

    void TurnOffLaser()
    {
        line.enabled = false;
        laserLight.enabled = false;
    }

    public float Distance
    {
        get
        {
            return maxDistance;
        }

    }

    public void CanFire()
    {
        canFire = true;
    }
}
