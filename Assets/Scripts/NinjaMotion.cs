using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NinjaMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject player;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
        agent.SetDestination(player.transform.position);//start AI path generation (A* algorithm)
                                                        //and start moving on the path
                                                        //draw path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }


        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    animator.SetInteger("state", 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetInteger("state", 1);
        //}
        //else if (Input.GetKeyDown(KeyCode.C))
        //{
        //    animator.SetInteger("state", 2);
        //}
        //else if (Input.GetKeyDown(KeyCode.V))
        //{
        //    animator.SetInteger("state", 3);
        //}
        //else if (Input.GetKeyDown(KeyCode.B))
        //{
        //    animator.SetInteger("state", 4);
        //}
    }
}
