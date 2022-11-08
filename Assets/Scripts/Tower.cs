using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform arrow;
    [SerializeField] ParticleSystem particle;
    private Transform target;
    private float range;

    private void Update()
    {
        FindTarget();
        ShootArrow();
    }

    private void FindTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closestTarget = null;

        float maxDistance = Mathf.Infinity;
        foreach(GameObject enemy in enemys)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
            target = closestTarget;
        }
    }

    private void ShootArrow()
    {
        arrow.LookAt(target);
        float targetDistance = Vector3.Distance(transform.position, target.position);
        var emissionModule = particle.emission;
        emissionModule.enabled = targetDistance < range ? true : false;
    }
}
