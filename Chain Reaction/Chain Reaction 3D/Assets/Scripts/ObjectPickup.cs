using UnityEngine;
public class ObjectPickup : MonoBehaviour
{
    public float pickupRange = 2f;
    public Transform holdPosition; 

    private GameObject _heldObject;
    private Rigidbody _heldObjectRb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_heldObject == null)
            {
                TryPickupObject();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_heldObject != null)
            {
                DropObject();
            }
        }
    }

    private void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            string[] allowedObjects = { "YellowG", "RedG", "BlueG" , "GreenG" };
            if (System.Array.Exists(allowedObjects, element => element == hit.collider.gameObject.name))
            {
                PickupObject(hit.collider.gameObject);
            }
        }
    }

    private void PickupObject(GameObject obj)
    {
        _heldObject = obj;
        _heldObjectRb = obj.GetComponent<Rigidbody>();
        if (_heldObjectRb != null)
        {
            _heldObjectRb.useGravity = false;
            _heldObjectRb.isKinematic = true;
            _heldObject.transform.position = holdPosition.position;
            _heldObject.transform.parent = holdPosition;
        }
    }

    private void DropObject()
    {
        if (_heldObjectRb != null)
        {
            _heldObjectRb.useGravity = true;
            _heldObjectRb.isKinematic = false;
            _heldObject.transform.parent = null;
            _heldObject = null;
        }
    }
}