using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorOpenSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorOpenSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpening", true);
        doorOpenSound.PlayDelayed(0.5f);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
        doorOpenSound.PlayDelayed(0.8f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
