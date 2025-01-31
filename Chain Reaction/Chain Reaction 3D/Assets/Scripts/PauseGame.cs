using UnityEngine;

 public class PauseGame : MonoBehaviour
 {
     public GameObject PauseScreen;
     private bool isShowing;
     public bool lockcursor = true;
     void Update()
     {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
             isShowing = !isShowing;
             PauseScreen.SetActive(isShowing);
             lockcursor = !lockcursor;
         }
         Cursor.lockState = lockcursor?CursorLockMode.Locked:CursorLockMode.None;
         Cursor.visible = !lockcursor;
     }
}