using Fusion;

public class NetworkPlayer : NetworkBehaviour
{
    private const float MoveSpeed = 5f;
    private NetworkCharacterController _netCC;
    
    private void Awake()
    {
        _netCC = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork() 
    {
        if (GetInput(out NetworkInputData input))
        {
            input.Direction.Normalize();
            _netCC.Move(MoveSpeed * input.Direction * Runner.DeltaTime);
        }
    }
}