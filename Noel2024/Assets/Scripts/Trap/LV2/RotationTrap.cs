using System;
using UnityEngine;

public class RotationTrap : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(0,0,35);
        }
    }
}
