using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    public GameObject camera;
    public GameObject target;
    public GameObject gunInHandop1;
    public GameObject gunInHandop2;
 
 
    public GameObject muzzleop1;
    public GameObject muzzleop2;

    public AudioSource shootingSound1;
    public AudioSource shootingSound2;

    private LineRenderer line;
    private NavMeshAgent agent;
    public GameObject ninja;
    private Animator animator;

    private int numHits;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        animator = ninja.GetComponent<Animator>();
        numHits = 0;
        agent = ninja.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            if(gunInHandop1.activeSelf||gunInHandop2.activeSelf)
            {
                RaycastHit hit;
                if(Physics.Raycast(camera.transform.position,camera.transform.forward,out hit))
                {
                    target.transform.position = hit.point;
                    target.SetActive(true);
                    //draw line
                    if (gunInHandop1.activeSelf)
                    {
                        shootingSound1.Play();
                    }
                    else if (gunInHandop2.activeSelf)
                    {
                        shootingSound2.Play();
                    }
                    StartCoroutine(ShowFlash());
                   
                    //check that the bullet hit the ninja
                    if (hit.transform.gameObject == ninja)
                    {
                        numHits++;
                        if(numHits <3)
                        {
                            //stop moving toward target
                            agent.enabled = false;
                            StartCoroutine(NinjaFallAndGettingUp());
                        }
                        else
                        {
                            animator.SetInteger("state", 4);//die
                            agent.enabled = false;
                        }
                       
                    }
                  


                }
            }
        }
 
        
     
    }
 
    IEnumerator NinjaFallAndGettingUp()
    {
        //chek what state was befor falling
        int st = animator.GetInteger("state");
        if (st == 1)
        {
            agent.enabled = false;
        }
        animator.SetInteger("state", 2);//fall back
        yield return new WaitForSeconds(3.0f);//delay
        animator.SetInteger("state", 3);//getting up
        yield return new WaitForSeconds(1.0f);//delay
        //renew motion
        if(st == 1)
        {

            agent.enabled = true;
        }
        animator.SetInteger("state", st);

    }
    IEnumerator ShowFlash()
    {
        //draw flash
        if (gunInHandop1.activeSelf)
        {
            line.SetPosition(0, muzzleop1.transform.position);
            line.SetPosition(1, target.transform.position);

        }
        if (gunInHandop2.activeSelf)
        {
            line.SetPosition(0, muzzleop2.transform.position);
            line.SetPosition(1, target.transform.position);
        }
        //all the lines befor next line run immedietly
        yield return new WaitForSeconds(0.1f);//delay
                                              //next lines will be executed after the delay
                                              //erase flash
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, this.transform.position);
        target.SetActive(false);
    }
}
