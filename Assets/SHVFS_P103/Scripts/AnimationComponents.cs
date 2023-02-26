using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponents : MonoBehaviour
{
    public InputComponentBase inputComponent;
    [SerializeField]
    private Animator animator;

    void Update()
    {
        if(inputComponent.GetInputDirectionNormalized().magnitude > 0f)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
