using UnityEngine;
using HenryLab;

/// <summary>
/// VRExplorer triggerable adapter for the PlaySound component.
/// When triggered, plays the configured audio clip.
/// </summary>
[RequireComponent(typeof(PlaySound))]
public class PlaySoundTriggerable : MonoBehaviour, ITriggerableEntity
{
    private const float DEFAULT_TRIGGERING_TIME = 0.5f;

    public string Name => Str.Triggerable;

    [SerializeField] private float triggeringTime = DEFAULT_TRIGGERING_TIME;

    private PlaySound _playSound;

    public float TriggeringTime => triggeringTime;

    private void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
        _playSound = GetComponent<PlaySound>();
    }

    /// <summary>
    /// Triggers the sound playback.
    /// </summary>
    public void Triggerring()
    {
        if (_playSound != null)
        {
            _playSound.canPlay = true;
            _playSound.PlaySoundShot();
            Debug.Log($"[PlaySoundTriggerable] Triggerring: Playing sound on '{gameObject.name}'");
        }
    }

    /// <summary>
    /// Sound trigger completed.
    /// </summary>
    public void Triggerred()
    {
        Debug.Log($"[PlaySoundTriggerable] Triggerred: Sound trigger completed on '{gameObject.name}'");
    }
}
