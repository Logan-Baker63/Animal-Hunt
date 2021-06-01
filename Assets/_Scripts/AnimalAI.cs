using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AnimalAI : MonoBehaviour
{

    NavMeshAgent agent;

    Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    DieWhenShot DieWhenShot;

    //variables for when the player isn't in range of the animal
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;

    private void Awake() //sets variables
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        DieWhenShot = GetComponent<DieWhenShot>();
    }

    private void Undisturbed() //animal AI set to walk to random points
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //check if animal reaches walkpoint
            if (distanceToWalkPoint.magnitude < 1f)
            {

                walkPointSet = false;

            }
        }


        //StartCoroutine(rabbitRest(3));
    }

    /*IEnumerator rabbitRest(float time)
    {
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //check if animal reaches walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

        yield return new WaitForSeconds(0.5f);

    }*/

    private void SearchWalkPoint() //finds random poinnt on nav mesh within range
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Flee() //animal runs from player when in range for 3 seconds
    {
        StartCoroutine(FleeForSeconds(3));
    }

    IEnumerator FleeForSeconds(float fleeTime)
    {
        while (fleeTime > 0f)
        {
            if (DieWhenShot.isDead == false)
            {
                fleeTime -= Time.deltaTime;

                agent.SetDestination((player.position - transform.position) * -2);
            }
                
            

            yield return new WaitForSeconds(0.5f);

            fleeTime -= 1f;

        }


    }

    private void OnDrawGizmosSelected() //makes animal sight range and walk range etc visible
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange); //player detection range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(walkPoint, 2f); //target destination using walk point
    }

    // Update is called once per frame
    void Update()
    {

        //check if the player is within the sight range of the animal
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            Flee();
        }
        else
        {
            Undisturbed();
        }

    }
}
