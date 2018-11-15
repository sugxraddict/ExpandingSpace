using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	[SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth = 5;
    [SerializeField] int PlusHealth = 3;
    [SerializeField] float regenerationRate = 0f;
    [SerializeField] int regenerateAmount = 0;
    

    void Start()
    {
        //curHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate()
    {
        /*//Debug.Log("Regeneration");
        if(curHealth < maxHealth)
        {
            curHealth += regenerateAmount;
        }*/
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        EventManager.TakeDamage(curHealth / (float)maxHealth);
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;

        if(curHealth < 0)
        {
            curHealth = 0;
        }

        EventManager.TakeDamage(curHealth/(float)maxHealth);

        if(curHealth < 1)
        {
            EventManager.PlayerDeath();
            GetComponent<Explosion>().BlowUp();

            //remove a life from the life counter
        }
        //Debug.Log("I died");
    }

    /*public void Heal(int heal = 1)
    {
        curHealth += heal;

        EventManager.TakeDamage(curHealth / (float)maxHealth);
    }*/

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("HealthPickup"))
        {
            if (curHealth < maxHealth)
            {
            curHealth += regenerateAmount;
            }

            Debug.Log("Heal");
        }
    }
}
