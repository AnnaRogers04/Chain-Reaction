using UnityEngine;
using UnityEngine.SceneManagement;
public class pinkgem : MonoBehaviour
{
    private void OnDestroy()
    {
        if (gameObject.name == "Pink gem")
        {
            SceneManager.LoadScene(2);
        }
    }
}