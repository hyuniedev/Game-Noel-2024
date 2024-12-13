using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(float VectorX, float VectorY, bool IsGround, bool IsDead)
    {
        animator.SetFloat("VectorX", VectorX);
        animator.SetFloat("VectorY", VectorY);
        animator.SetBool("IsGround", IsGround);
        if (IsDead)
        {
            animator.Play("die");
            Invoke("StopScreen",0.8f);
        }
    }

    private void StopScreen()
    {
        Time.timeScale = 0;
    }
}