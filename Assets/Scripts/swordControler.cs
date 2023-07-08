using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class swordControler : MonoBehaviour
{
    public GameObject handSword;
    public GameObject backSword;
    public bool swordActive=false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("2"))
        {
           equip();
           animator.SetBool("sword", true);
        }
        if (Input.GetKey("1"))
        {
            animator.SetBool("sword", false);
            unequip();
           
        }

    }

    void equip()
    {
        handSword.SetActive(true);
        backSword.SetActive(false);
    }
    void unequip()
    {
        backSword.SetActive(true);
        handSword.SetActive(false);
    }
}
