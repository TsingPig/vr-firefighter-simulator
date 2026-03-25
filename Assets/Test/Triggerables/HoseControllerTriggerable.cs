using UnityEngine;
using HenryLab;

/// <summary>
/// VRExplorer triggerable adapter for the HoseController component.
/// When triggered, simulates toggling the hose on and off.
/// </summary>
[RequireComponent(typeof(HoseController))]
public class HoseControllerTriggerable : MonoBehaviour, ITriggerableEntity
{
    private const float DEFAULT_TRIGGERING_TIME = 2.0f;

    public string Name => Str.Triggerable;

    [SerializeField] private float triggeringTime = DEFAULT_TRIGGERING_TIME;

    private HoseController _hoseController;
    private ParticleSystem _hoseWaterPs;

    public float TriggeringTime => triggeringTime;

    private void Awake()
    {
        EntityManager.Instance.RegisterEntity(this);
        _hoseController = GetComponent<HoseController>();
        _hoseWaterPs = _hoseController.hoseWaterPs;
    }

    /// <summary>
    /// Simulates turning on the hose.
    /// </summary>
    public void Triggerring()
    {
        if (_hoseWaterPs != null)
        {
            _hoseWaterPs.Play();
            Debug.Log($"[HoseControllerTriggerable] Triggerring: Hose turned on '{gameObject.name}'");
        }

        if (_hoseController.hoseHandle != null)
        {
            _hoseController.hoseHandle.ActivateHandleMovement(true);
        }
    }

    /// <summary>
    /// Simulates turning off the hose.
    /// </summary>
    public void Triggerred()
    {
        if (_hoseWaterPs != null)
        {
            _hoseWaterPs.Stop();
            Debug.Log($"[HoseControllerTriggerable] Triggerred: Hose turned off '{gameObject.name}'");
        }

        if (_hoseController.hoseHandle != null)
        {
            _hoseController.hoseHandle.ActivateHandleMovement(false);
        }
    }
}
