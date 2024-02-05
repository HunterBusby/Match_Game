using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI Label;
    public UnityEvent startEvent;

    private void Start()
    {
        Label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatData obj)
    {
        Label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        Label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}
