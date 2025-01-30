using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
//    LayerMask _layerMask = LayerMask.GetMask("PickUp");
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            { 
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); 
                Debug.Log("Did Hit");
               
                if (hit.collider.CompareTag("Gems"))
                {
                    hit.collider.gameObject.InteractWithGem();
                    Destroy(hit.collider.gameObject); 
                    Debug.Log("Gems Hit");
                }
            }
            else
            { 
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * 1000, Color.white); 
                Debug.Log("Did not Hit"); 
            }
        }
    }
}