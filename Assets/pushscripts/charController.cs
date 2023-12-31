using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] public AudioClip walkClip;
    public GameObject cek;
    Animator animator;
    public Transform Cam;
    public Rigidbody rb;
    public float speed=2;
    Vector3 move= Vector3.zero;
    float x, z;
    public float jumpSpeed;
    bool walk=false;
    bool push=false;
    bool pull = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.angularVelocity=Vector3.zero;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Cam.transform.rotation, 0.1f);
        }

        move = new Vector3(x, 0, z) * Time.deltaTime * speed;
        rb.MovePosition(transform.position + transform.TransformDirection(move));


        if (Input.GetKey(KeyCode.LeftShift))
        {
            walk = true;
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (walk)
            {
                
                animator.SetInteger("anim", 5);
                speed = 12;
                walk = false;
            }
            else
            {
                speed = 7;
                animator.SetInteger("anim", 1);
                
            }
            audioSource.Play();
           
            
        }
        

        else if (Input.GetKey(KeyCode.A))
        {
            speed = 5;
            animator.SetInteger("anim", 2);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("anim", 3);
            speed = 5;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Q) == true && pull == true)
            {
                speed = 0.5f;
            }
            else
            {
                speed = 6;
                
            }
            
            animator.SetInteger("anim", 4);
        }

        else if (Input.GetKey(KeyCode.Q) && pull == true)
        {
         
            animator.SetBool("pull", true);
            speed = 0.1f;
            cek.GetComponent<cube>().mass = 50;
        }
        else if (Input.GetKey(KeyCode.R) && push == true)
        {
            animator.SetBool("push", true);
            speed = 0.1f;
            cek.GetComponent<cube>().mass = 50;
        }
        else
        {
          
          animator.SetInteger("anim", 0);
          animator.SetBool("pull", false);
          animator.SetBool("push", false);
          cek.GetComponent<cube>().mass = 500;
        }
        
        
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.velocity=Vector3.up*Time.deltaTime*jumpSpeed;
            animator.SetBool("jump", true);
            animator.SetBool("walkjump", true);
         
        }
        else
        {
            animator.SetBool("jump", false);
            animator.SetBool("walkjump", false);
            
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            push = true;
            pull = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            push = false;
            pull = false;
        }
        
    }
}
