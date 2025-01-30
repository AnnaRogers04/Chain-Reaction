using UnityEngine;
public class GameController : MonoBehaviour
{
    public Gem[] gems;  
    public Door[] doors;  
    private void Start()
    {
        if (gems.Length != doors.Length)
        {
            Debug.LogError("The number of gems and doors must be the same!");
            return;
        }
        for (int i = 0; i < gems.Length; i++)
        {
            doors[i].SubscribeToGem(gems[i]);
        }
    }
}