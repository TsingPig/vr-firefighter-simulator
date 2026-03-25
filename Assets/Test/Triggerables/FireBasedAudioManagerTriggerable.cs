using UnityEngine;
using HenryLab;

/// <summary>
/// VRExplorer triggerable adapter for the FireBasedAudioManager component.
/// When triggered, simulates a fire count change notification.
/// </summary>
[RequireComponent(typeof(FireBasedAudioManager))]
public class FireBasedAudioManagerTriggerable : MonoBehaviour, ITriggerableEntity
{
    private const float DEFAULT_TRIGGERING_TIME = 0.5f;
    private const int SIMULATED_HIGH_FIRE_COUNT = 15;
    private const int SIMULATED_LOW_FIRE_COUNT = 0;

    public string Name => Str.Triggerable;

    [SerializeField] private float triggeringTime = DEFAULT_TRIGGERING_TIME;

    /// <summary>
    /// The simulated fire count to send when triggering.
    /// </summary>
    [SerializeField] private int simulatedFireCount = SIMULATED_HIGH_FIRE_COUNT;

    private FireBasedAudioManager _audioManager;

    public float TriggeringTime => triggeringTime;

    private void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
        _audioManager = GetComponent<FireBasedAudioManager>();
    }

    /// <summary>
    /// Simulates fire count above the audio manager's threshold.
    /// </summary>
    public void Triggerring()
    {
        if (_audioManager != null)
        {
            _audioManager.NotifyFireChange(simulatedFireCount);
            Debug.Log($"[FireBasedAudioManagerTriggerable] Triggerring: Notified fire count={simulatedFireCount} on '{gameObject.name}'");
        }
    }

    /// <summary>
    /// Simulates fire count below the audio manager's threshold.
    /// </summary>
    public void Triggerred()
    {
        if (_audioManager != null)
        {
            _audioManager.NotifyFireChange(SIMULATED_LOW_FIRE_COUNT);
            Debug.Log($"[FireBasedAudioManagerTriggerable] Triggerred: Notified fire count={SIMULATED_LOW_FIRE_COUNT} on '{gameObject.name}'");
        }
    }
}
