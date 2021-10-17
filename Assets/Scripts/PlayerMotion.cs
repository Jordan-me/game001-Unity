using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotion : MonoBehaviour
{
    private float speed = 8, angularSpeed = 50;
    private CharacterController controller;
    private float rotationAboutY = 0, rotationAboutX = 0;
    public GameObject camera; // publics must be initialized in Unity
    private AudioSource stepSound;
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rotationAboutY = transform.localEulerAngles.y;
        stepSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy = -1/*kind of a gravity*/, dz;

        // rotation about Y
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

        // rotation about X
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        camera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);

        // moving forward/backward/left/right
        dz = Input.GetAxis("Vertical"); // can be -1, 0 , 1
        dz *= speed * Time.deltaTime;

        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 motion = new Vector3(dx, dy, dz); // in Local coordinates
        motion = transform.TransformDirection(motion);// change to Global coordinates
        controller.Move(motion);//in Global coordinates

        //if there was A/W/S/D key pressed
        if(dz<-0.1 ||dz>0.1||dx<-0.1||dx>0.1)
        {
            if (!stepSound.isPlaying)
                stepSound.Play();
            //turn on npc
            NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
            agent.enabled = true;//start npx motion
            //and let npx walk
            Animator animator = npc.GetComponent<Animator>();
            animator.SetInteger("state", 1);

        }
        // simple motion
        //        transform.Translate(new Vector3(dx, dy, dz));
        // simple motion forward
        //      transform.Translate(new Vector3(0, 0, 0.1f));
        // simple motion to the left
        //      transform.Translate(new Vector3(-0.1f, 0, 0));
    }

}
