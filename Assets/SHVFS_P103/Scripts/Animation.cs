using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private PlayerInputComponent playerInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInputComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Vector2.SqrMagnitude(playerInput.GetInputDirection());
        if (playerSpeed > 0.01f)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
