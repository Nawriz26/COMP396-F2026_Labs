using UnityEngine;

public enum GameObjectEventType
{
    Death, SpawnParticle, None
}

[CreateAssetMenu(fileName = "GameObjectChannel", menuName = "Events/GameObjectEvent")]
public class GameObjectEventChannel : GenericEventChannel<GameObject> { }