using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetMoveAnimation()
    {
        animator.SetBool("isMoving", true);
    }

    public void SetIdleAnimation()
    {
        animator.SetBool("isMoving", false);
    }
}
