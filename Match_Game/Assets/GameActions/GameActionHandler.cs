using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;

    public void Start()
    {
        gameActionObj.raise += Raise;
    }

    private void Raise(object arg0)
    {
        onRaiseEvent.Invoke();
    }
}
