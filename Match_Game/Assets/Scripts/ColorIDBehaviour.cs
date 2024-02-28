using UnityEngine;

public class ColorIDBehaviour : IDContainerBehaviour
{
    public ColorIDDataList ColorIDDataListObj;

    private void Awake()
    {
        idObj = ColorIDDataListObj.currentColor;
    }
}
