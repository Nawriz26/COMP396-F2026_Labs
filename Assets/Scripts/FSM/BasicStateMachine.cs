using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum BasicStates
{
    Patrolling, Harvesting, Resting 
}

[RequireComponent(typeof(MeshRenderer))]
public class BasicStateMachine : MonoBehaviour
{
    [SerializeField] private BasicStates currentState;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        currentState = BasicStates.Resting;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeState(BasicStates newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
    }

    private void Update()
    {
        switch (currentState)
        {
            case BasicStates.Patrolling:
                meshRenderer.material.color = Color.yellow;
                // Implement patrolling behavior here
                break;
            case BasicStates.Harvesting:
                meshRenderer.material.color = Color.green;
                // Implement harvesting behavior here
                break;
            case BasicStates.Resting:
                meshRenderer.material.color = Color.cyan;
                // Implement resting behavior here
                break;
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            ChangeState(BasicStates.Patrolling);
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            ChangeState(BasicStates.Harvesting);
        }
        else if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ChangeState(BasicStates.Resting);
        }
    }


}
