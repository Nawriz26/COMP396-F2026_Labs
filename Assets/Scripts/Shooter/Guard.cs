using System;
using Unity.Behavior;
using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField] private AudioClip _dyingDuckSound;
    [SerializeField] private BehaviorGraph _graph;
    [SerializeField] private GameObjectEventChannel _goEventChannel;

    private void Awake()
    {
        _graph = GetComponent<BehaviorGraphAgent>().Graph;
        _goEventChannel.OnEventRaised += UpdateGraphReferences;
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(_dyingDuckSound, transform.position);
        _goEventChannel.OnEventRaised -= UpdateGraphReferences;
    }

    private void UpdateGraphReferences(GameObject goRef)
    {
        _graph.BlackboardReference.SetVariableValue("EnemyReference", goRef);
    }
}
