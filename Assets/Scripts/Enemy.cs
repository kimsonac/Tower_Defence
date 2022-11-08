using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform[] destinations;
    private NavMeshAgent agent;
    private Vector3 next;
    private int index;
    private int health;

    private void OnEnable()
    {
        health = 5;
        agent = GetComponent<NavMeshAgent>();
        transform.position = startPosition.position;
    }

    private void Start()
    {
        StartCoroutine(_MoveToDestination());
    }

    private IEnumerator _MoveToDestination()
    {
        while(index < destinations.Length)
        {
            yield return null;
            next = new Vector3(destinations[index].position.x, 0, destinations[index].position.z);
            agent.SetDestination(destinations[index].position);

            if(Vector3.Distance(transform.position, destinations[index].position) <= 0.1f)
            {
                index++;
            }
        }

        gameObject.SetActive(false);
        GameManager.gameManager.GoldDeduction(5);
    }

    private void OnParticleCollision(GameObject other)
    {
        health -= 1;

        if(health <= 0)
        {
            gameObject.SetActive(false);
            GameManager.gameManager.GoldCollect(10);
        }

        
    }
}
