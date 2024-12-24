using System;
using UnityEngine;

public class TelePoint : MonoBehaviour
{
    [SerializeField] private Transform pointTele;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            other.transform.position = pointTele.position;
        }
    }
}
