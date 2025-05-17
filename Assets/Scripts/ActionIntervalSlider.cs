using UnityEngine;
using UnityEngine.UI;

public class ActionIntervalSlider : MonoBehaviour
{
    [SerializeField]
    private OrangutanBehaviour orangutan;

    [SerializeField]
    private Slider slider;

    private void Awake()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    private void OnEnable()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(UpdateInterval);
            slider.value = orangutan != null ? orangutan.ActionInterval : 0f;
        }
    }

    private void OnDisable()
    {
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(UpdateInterval);
        }
    }

    private void UpdateInterval(float value)
    {
        if (orangutan != null)
        {
            orangutan.ActionInterval = value;
        }
    }
}
