using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "DataBindings/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField, DontCreateProperty]
    private BoolEventChannel boolEvent;

    [SerializeField, DontCreateProperty]
    private bool _status;

    [CreateProperty]
    public bool Status
    {
        get => _status;
        set => _status = value;
    }

    private void OnEnable()
    {
        if (boolEvent != null)
        {
            boolEvent.OnEventRaised += UpdateStatus;    
        }
    }
    private void OnDisable()
    {
        if (boolEvent != null)
        {
            boolEvent.OnEventRaised -= UpdateStatus;
        }
    }

    private void UpdateStatus(bool status)
    {
        Status = status;
    }
}