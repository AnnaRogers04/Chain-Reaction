using UnityEngine;
public class Movement : MonoBehaviour
{
    
    [SerializeField] Transform playerCamera;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float speed = 6.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;  
 
    public float jumpHeight = 6f;
    float _velocity;
    bool _isGrounded;
 
    float _cameraCap;
    Vector2 _currentMouseDelta;
    Vector2 _currentMouseDeltaVelocity;
    
    CharacterController _controller;
    Vector2 _currentDir;
    Vector2 _currentDirVelocity;
    Vector3 Velocity;
 
    void Start()
    {
        _controller = GetComponent<CharacterController>();
 
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }
    
    void Update()
    {
        UpdateMouse();
        UpdateMove();
    }
 //below you can see how we attached the camera movemovement
    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetMouseDelta, ref _currentMouseDeltaVelocity, mouseSmoothTime);
        _cameraCap -= _currentMouseDelta.y * mouseSensitivity;
        playerCamera.localEulerAngles = Vector3.right * _cameraCap;
        transform.Rotate(Vector3.up * _currentMouseDelta.x);
    }
 //below you can see the player movement 
    void UpdateMove()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, moveSmoothTime);
        _velocity += gravity * 2f * Time.deltaTime;
        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * speed + Vector3.up * _velocity;
        _controller.Move(velocity * Time.deltaTime);
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        if(_isGrounded! && _controller.velocity.y < -1f)
        {
            _velocity = -8f;
        }
    }
}