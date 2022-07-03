using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{   
    [SerializeField] Transform dynamicTower;
    Transform target;
    float maxRange = 22;
    [SerializeField] ParticleSystem arrow;

    void Update()
    {
        ClosestTarget();
        AIMtoEnemy();
    }

    void ClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float maxDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach(Enemy enemy in enemies)
        {
           float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);   

           if(targetDistance < maxDistance)
           {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
           }  
        }
        target = closestTarget;
    }

    void AIMtoEnemy()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if(targetDistance < maxRange)
        {
        dynamicTower.LookAt(target);
        Shoot (true);
        }

        else
        Shoot (false);

    }

    void Shoot (bool TF)
    {
        var emissionModule = arrow.emission;

        emissionModule.enabled = TF;
    }
}
