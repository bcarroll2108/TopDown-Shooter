using UnityEngine;
using System.Collections;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{

    public float startingHealth;
    public float currentHealth;
    //protected float health;
    protected bool dead;




    public event System.Action OnDeath;

    protected virtual void Start()
    {
        currentHealth = startingHealth;
        
    }




    public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        // Do some stuff here with hit var
        
        currentHealth = currentHealth - damage;
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        //currentHealth =- damage;
        Debug.Log("shot");

        if (currentHealth <= 0 && !dead)
        {

            Die();

        }
    }

    protected void Die()
    {
        dead = true;
        Debug.Log("He gone");
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.GetComponent<Canvas>().enabled = false;


    }

    public void TakeDamage(object damage)
    {

        throw new NotImplementedException();
    }
}