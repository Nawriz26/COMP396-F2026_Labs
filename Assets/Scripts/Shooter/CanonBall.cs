using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] private GameObjectEventChannel _goEvent;

    private void OnCollisionEnter(Collision other)
    {
        // TODO: Improve collision detection from Enemy perspective.
        if (other.gameObject.CompareTag("Enemy"))
        {
            _goEvent.RaiseEvent(other.gameObject, GameObjectEventType.SpawnParticle);
            _goEvent.RaiseEvent(other.gameObject, GameObjectEventType.Death);
            Destroy(other.gameObject);
        }
    }
}
