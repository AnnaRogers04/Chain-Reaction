using UnityEngine;
public class Door : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Door is opening...");
    }
    public void SubscribeToGem(Gem gem)
    {
        gem.OnGemActivated += OpenDoor;
    }
    
    public void UnsubscribeFromGem(Gem gem)
    {
        gem.OnGemActivated -= OpenDoor;
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}