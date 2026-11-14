using UnityEngine;

public class CanonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // TODO: Improve collision detection from Enemy perspective.
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
