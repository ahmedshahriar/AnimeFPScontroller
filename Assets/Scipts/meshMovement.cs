using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshMovement : MonoBehaviour
{
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isFiring",true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isFiring", false);
        }

        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        if (translation == 0)
        {
            anim.SetBool("isRunning", false);
        }

    }
}
