using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour {
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject blowUp;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Shield shield;
    [SerializeField] float laserHitModifier = 100f;

    private AudioSource explosionAudio;
    public AudioClip explosionSound;

    public void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);

        if(shield == null)
        {
            return;
        }

        //Debug.Log("Taking Damage");
        shield.TakeDamage();
    }

    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
    }



    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            IveBeenHit(contact.point);
        }
    }



    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        IveBeenHit(hitPosition);

        if(rigidbody == null)
        {
            return;
        }

        Vector3 forceVector = hitSource.position - hitPosition;
        //Debug.Log(forceVector * laserHitModifier);
        rigidbody.AddForceAtPosition(forceVector.normalized * laserHitModifier, hitPosition, ForceMode.Impulse);
    }

    public void BlowUp()
    {
        EventManager.PlayerDeath();          //call the onPlayerDeath event

        //Summon particle effect
        GameObject temp = Instantiate(blowUp, transform.position, Quaternion.identity) as GameObject;

        //Delay destroy the particle effect
        Destroy(temp, 3f);

        //destroyself
        Destroy(gameObject);

        float vol = 1.0f;
        //explosionAudio.PlayOneShot(explosionSound, vol);
    }
}
