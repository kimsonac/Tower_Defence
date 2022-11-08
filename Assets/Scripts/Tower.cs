using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] ParticleSystem particle;
    private Transform target;
    private float range = 15f;
    private float targetDistance = 0;

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
            Debug.Log(target.name);
        }
    }

    private void ShootArrow()
    {
        head.LookAt(target);
        if(target != null)
        {
            targetDistance = Vector3.Distance(transform.position, target.position);
        }
        var emissionModule = particle.emission;
        emissionModule.enabled = targetDistance < range ? true : false;
    }

    // 업그레이드 되면 emission의 스피드 1로 업, 파티클
    
}
