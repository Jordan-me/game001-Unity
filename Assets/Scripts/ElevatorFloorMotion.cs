using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorFloorMotion : MonoBehaviour
{
    public Animator animator;
    public Text toDo;
    public GameObject camera;
    private bool isUp = false, isDown = false;
    private int maxFloor = 2, currFloor = 0;
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
                    toDo.gameObject.SetActive(true);
                    toDo.text =  "Press U or F to move";
                    
               
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        animator.SetBool("isUp", !isUp);
                        animator.SetBool("isDown", isDown);
                        isUp = !isUp;
                    
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        animator.SetBool("isUp", isUp);
                        animator.SetBool("isDown", !isDown);
                        isDown = !isDown;
                   
                    }
                }else
                {
                    toDo.gameObject.SetActive(false);
                }
            }
        }
    }
}
