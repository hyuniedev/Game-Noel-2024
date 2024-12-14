using System;
using UnityEngine;

public class TrapAbstract : MonoBehaviour
{
    [SerializeField]
    private float speedTranslate = 10f;
    [SerializeField]
    private Transform targetPosition;
    private GameObject GO_Trap;
    private bool trapActive = false;

    private void Start()
    {
        GO_Trap = transform.Find("Trap").gameObject;
    }

    private void Update()
    {
        if (trapActive)
        {
            Translate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        trapActive = true;
    }

    private void Translate()
    {
        GO_Trap.transform.position = Vector2.MoveTowards(GO_Trap.transform.position,targetPosition.position,speedTranslate*Time.deltaTime);
    }
}