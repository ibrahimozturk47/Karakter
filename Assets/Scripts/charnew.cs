using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charnew : MonoBehaviour
{
    public float speed=10;
    Animator animator;
    public Transform Cam;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float xhorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");

        if(xhorizontal!=0 || zVertical != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Cam.transform.rotation, 0.1f);
        }

        if (Input.GetKey(KeyCode.W))
            {
                Vector3 moveDir = new Vector3(0, 0, zVertical);
                transform.position +=moveDir* speed*Time.deltaTime;
                animator.SetInteger("hareket", 1);
                moveDir=transform.TransformDirection(moveDir);
            }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDir = new Vector3(0, 0,zVertical);
            transform.position += moveDir * speed * Time.deltaTime;
            animator.SetInteger("hareket", 2);
            moveDir = transform.TransformDirection(moveDir);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveDir = new Vector3(xhorizontal, 0, 0);
            transform.position += moveDir * speed * Time.deltaTime;
            animator.SetInteger("hareket", 3);
            moveDir = transform.TransformDirection(moveDir);
        }
        else
        {
                Vector3 moveDir=new Vector3(0, 0, 0);
                animator.SetInteger("hareket", 0);
        }
           
      
    }


}
