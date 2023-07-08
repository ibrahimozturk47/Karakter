using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour
{

    float ýnputX;
    float inputY;
    public Transform model;
    Animator anim;
    Vector3 stickDirection;
    Camera maincam;
    public float damp;
    [Range(1f, 20f)]
    public float rotationSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       ýnputX = Input.GetAxis( "Horizontal" );
       inputY = Input.GetAxis("Vertical");

        stickDirection = new Vector3(ýnputX, 0, inputY);

       ýnputMove();
       ýnputRotation();
    }
    void ýnputMove()
    {
        anim.SetFloat("speed",Vector3.ClampMagnitude(stickDirection,1).magnitude,damp,Time.deltaTime*10);
    }

   void ýnputRotation()
    {
        Vector3 rotOfset=maincam.transform.TransformDirection(stickDirection);
        rotOfset.y=0;
        model.forward=Vector3.Slerp(model.forward,rotOfset,Time.deltaTime*rotationSpeed);
    }
}
