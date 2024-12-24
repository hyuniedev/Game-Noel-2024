using UnityEngine;

public class TriggerEnableRB : MonoBehaviour
{
    [SerializeField] private GameObject Trap;

    private void Start()
    {
        Trap.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Trap.GetComponent<Rigidbody2D>().gravityScale = 8.0f;
        }
    }
}
