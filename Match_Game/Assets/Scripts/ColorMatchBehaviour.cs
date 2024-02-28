using UnityEngine;

public class ColorMatchBehaviour : MatchBehaviour
{
    public ColorIDDataList ColorIDDataListObj;

    private void Awake()
    {
        idObj = ColorIDDataListObj.currentColor;
    }

    public void ChangeColor(SpriteRenderer renderer)
    {
        var newColor = idObj as ColorID;
        renderer.color = newColor.value;
    }
}