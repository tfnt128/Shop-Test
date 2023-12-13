using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public UnityEvent<string> OnInteract;

    public  void Interact()
    {
        OnInteract?.Invoke(GetText());

    }

    protected string GetText()
    {
        return "";
    }


}
