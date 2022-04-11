using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            playerAnimation.SetBool("IsClimbing",true);
        }
        else
        {
            playerAnimation.SetBool("IsClimbing",false);
            transform.rotation =  Quaternion.Euler(0,-90,0);
        }
    }
}
