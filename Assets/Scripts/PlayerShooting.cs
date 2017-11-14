using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int damagePerShot;
    public float timeBetweenShot;
    public bool isSpreadOfBullets = false;

    public Animator anim;
    
    public int minSpread = -15;
    public int maxSpread = 15;

    private int currentAngle;

    private float nextShotTime;

    void Start()
    {
        currentAngle = minSpread;
        PoolManager.Instance.CreatePool(bulletPrefab, 20);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            //Instantiate(bulletPrefab, spawnPoint.position, GetAngle());
            //Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            PoolManager.Instance.ReuseObject(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            anim.SetTrigger("Shot");
            nextShotTime = Time.time + timeBetweenShot;
        }
    }

    private Quaternion GetAngle()
    {
        if (!isSpreadOfBullets)
        {
            return spawnPoint.rotation;
        }
        
        Quaternion angle = Quaternion.Euler(0f, 0f, currentAngle);

        currentAngle++;
        if (currentAngle == maxSpread + 1)
        {
            currentAngle = minSpread;
        }

        return angle;
    }
}
