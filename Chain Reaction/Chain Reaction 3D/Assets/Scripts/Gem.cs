using System;
using UnityEngine;
public class Gem : MonoBehaviour
{
    public Door door;
    public Action OnGemActivated;
    public void InteractWithGem()
    {
        OnGemActivated?.Invoke();
    }

    public void OpenDoor()
    {
        Destroy(door.gameObject);
    }
}