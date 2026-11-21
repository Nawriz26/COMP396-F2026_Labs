using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyDetected")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyDetected", message: "[Agent] has spotted [Enemy]", category: "Events", id: "77890ff079090560aeaf1437c4ecced0")]
public sealed partial class EnemyDetected : EventChannel<GameObject, GameObject> { }

