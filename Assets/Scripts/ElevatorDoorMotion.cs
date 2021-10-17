using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorDoorMotion : MonoBehaviour
{
    public Animator animator;
    public Text toDo;
    public GameObject camera;
    public GameObject seeThroughCrosshair;
    public GameObject touchCrosshair;
    private bool isOpen = false, isFocusOn = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //check what object is our focus
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.gameObject != null && hit.distance < 5)
            {
                //check focus camera on THIS
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    //change crossHair and allow action on door
                    if (!isFocusOn)
                    {
                        seeThroughCrosshair.SetActive(false);
                        touchCrosshair.SetActive(true);
                        isFocusOn = true;
                    }
                    //show the right inscription
                    toDo.gameObject.SetActive(true);
                    if (isOpen)
                    {
                        toDo.text = "Press E to close";
                    }
                    else
                    {
                        toDo.text = "Press E to open";

                    }
                    


                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        animator.SetBool("isOpenning", !isOpen);
                        isOpen = !isOpen;
                    }
                }
                else //we look about different object
                {
                    if (isFocusOn)
                    {
                        isFocusOn = false;
                        seeThroughCrosshair.SetActive(true);
                        touchCrosshair.SetActive(false);
                        toDo.gameObject.SetActive(false);
                    }
                }

            }
        }



    }
}
