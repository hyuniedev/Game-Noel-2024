using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(float VectorX, float VectorY, bool IsGround)
    {
        animator.SetFloat("VectorX", VectorX);
        animator.SetFloat("VectorY", VectorY);
        animator.SetBool("IsGround", IsGround);
    }
}