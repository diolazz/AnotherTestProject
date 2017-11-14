using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PolygonType
{
    Square,
    Triangle,
    Pentagon
}

public class Polygon : PoolObject, IDamageable
{
    public PolygonType type;
    public float health;
    public int scorePoints;

    public Canvas healthCanvas;
    public Image healthBar;

    private float currentHealth;
 
    void Start()
    {
        currentHealth = health;
        healthCanvas.enabled = false;
    }

    public override void OnObjectReuse()
    {
        currentHealth = health;
        healthBar.fillAmount = 1;
        healthCanvas.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthCanvas.enabled = true;
        healthBar.fillAmount = currentHealth/health;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ExperienceManager.Instance.AddExp(scorePoints);
        ScoreManager.Instance.AddScore(scorePoints);
        SpawnManager.Instance.SpawnPolygon(type);
        Destroy();
    }
}


