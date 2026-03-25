using UnityEngine;
using HenryLab;

/// <summary>
/// VRExplorer triggerable adapter for the AudienceController component.
/// When triggered, initiates the audience celebration sequence.
/// </summary>
[RequireComponent(typeof(AudienceController))]
public class AudienceControllerTriggerable : MonoBehaviour, ITriggerableEntity
{
    private const float DEFAULT_TRIGGERING_TIME = 1.0f;

    public string Name => Str.Triggerable;

    [SerializeField] private float triggeringTime = DEFAULT_TRIGGERING_TIME;

    private AudienceController _audienceController;

    public float TriggeringTime => triggeringTime;

    private void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
        _audienceController = GetComponent<AudienceController>();
    }

    /// <summary>
    /// Triggers the audience celebration.
    /// </summary>
    public void Triggerring()
    {
        if (_audienceController != null)
        {
            _audienceController.Celebrate();
            Debug.Log($"[AudienceControllerTriggerable] Triggerring: Celebration started on '{gameObject.name}'");
        }
    }

    /// <summary>
    /// Celebration trigger completed.
    /// </summary>
    public void Triggerred()
    {
        Debug.Log($"[AudienceControllerTriggerable] Triggerred: Celebration trigger completed on '{gameObject.name}'");
    }
}
