using UnityEngine;
using TMPro;
using Unity.Cinemachine;

public class MainGameController : MonoBehaviour
{
    [SerializeField] private GameObjectEventChannel _goEvent;
    [SerializeField] private BoolEventChannel _boolEvent;
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private TMP_Text _uiText;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _playerFollowCam;
    [SerializeField] private GameObject _mainCam;

    [SerializeField] private AudioClip _dyingAudioClip;

    private float timer = 0f;
    private bool _chasePlayer = false;

    private void OnEnable()
    {
        GameObject playerBody =  Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        GameObject playerFollowCam =  Instantiate(_playerFollowCam, Vector3.zero, Quaternion.identity);
        playerFollowCam.GetComponent<CinemachineCamera>().Target = new CameraTarget
        {
            TrackingTarget = playerBody.transform.GetChild(0).transform
        };
        Instantiate(_mainCam, Vector3.zero, Quaternion.identity);
        _goEvent?.RaiseEvent(playerBody);
        _goEvent.OnEventTypeRaised += DebugEventLog;
    }
    private void OnDisable()
    {
        _goEvent.OnEventTypeRaised -= DebugEventLog;
    }

    private void DebugEventLog(GameObject go, GameObjectEventType eventType)
    {
        switch (eventType)
        {
            case GameObjectEventType.Death:
                AudioSource.PlayClipAtPoint(_dyingAudioClip, go.transform.position);
                break;
            case GameObjectEventType.SpawnParticle:
                Debug.Log($"[GameObjectEventType] - {go.name} at {go.transform.position} on a event of {eventType}");
                break;
            case GameObjectEventType.None:
            default:
                break;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 15f)
        {
            _chasePlayer = !_chasePlayer;
            _boolEvent.RaiseEvent(_chasePlayer);
            UpdateUiText(_chasePlayer);
            timer = 0f;
        }
    }

    private void UpdateUiText(bool status)
    {
        _uiText.text = _playerData.Status.ToString();
    }
}
