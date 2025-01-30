using System;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public Action OnGemActivated;
    public void InteractWithGem()
    {
        OnGemActivated?.Invoke();
    }
}