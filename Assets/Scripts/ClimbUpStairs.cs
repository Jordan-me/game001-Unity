using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbUpStairs : MonoBehaviour
{
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Animator animator = npc.GetComponent<Animator>();
        animator.SetInteger("state", 5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
