using UnityEngine;
using HenryLab;

/// <summary>
/// VRExplorer triggerable adapter for the Fire component.
/// When triggered, simulates a water hit to extinguish the fire.
/// </summary>
[RequireComponent(typeof(Fire))]
public class FireTriggerable : MonoBehaviour, ITriggerableEntity
{
    private const float DEFAULT_TRIGGERING_TIME = 1.0f;

    public string Name => Str.Triggerable;

    [SerializeField] private float triggeringTime = DEFAULT_TRIGGERING_TIME;

    private Fire _fire;

    public float TriggeringTime => triggeringTime;

    private void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
        _fire = GetComponent<Fire>();
    }

    /// <summary>
    /// Simulates the start of a water hit on the fire.
    /// </summary>
    public void Triggerring()
    {
        if (_fire != null && _fire.isOn)
        {
            _fire.WaterHit(Vector3.up);
            Debug.Log($"[FireTriggerable] Triggerring: Water hit on fire '{gameObject.name}'");
        }
    }

    /// <summary>
    /// Simulates the end of the water hit interaction.
    /// </summary>
    public void Triggerred()
    {
        if (_fire != null)
        {
            Debug.Log($"[FireTriggerable] Triggerred: Water hit ended on fire '{gameObject.name}', isOn={_fire.isOn}");
        }
    }
}
