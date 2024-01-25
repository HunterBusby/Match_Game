using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLabelBehaviour : MonoBehaviour
{
    public Text Label;
    public FloatData dataObj;

    private void Start()
    {
        Label = GetComponent<Text>();
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        Label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
