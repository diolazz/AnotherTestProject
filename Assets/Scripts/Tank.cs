using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankType
{
    Starter, Sniper
}

public abstract class Tank: MonoBehaviour, IDamageable//, IUpgradable
{
    public int startHealth;

    protected int currentHealth;
    protected bool isDead;

    protected Tank upgradeTank;

    public event Action OnDeath;

    protected virtual void Start()
    {
        currentHealth = startHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

   // public abstract void Upgrade();

    public void Die()
    {
        isDead = true;

        if(OnDeath != null)
        {
            OnDeath();
        }

        Destroy(gameObject);
    }
}

