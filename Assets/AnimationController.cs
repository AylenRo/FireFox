using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){
            animator.SetBool("EstaEnMovimiento", true);
        }
        else if(!Input.GetKey("w")){
            animator.SetBool("EstaEnMovimiento", false);
        }

        if(Input.GetKey("space")){
            animator.SetBool("EstaSaltando", true);
        }
        else if(!Input.GetKey("space")){
            animator.SetBool("EstaSaltando", false);
        }

    }
}
