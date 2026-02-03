using UnityEngine;
using UnityEngine.InputSystem;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier = 1f;
    public float smoothTime = .3f;
    
    private Vector2 startPosition;
    private Vector3 velocity;
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 offset = Camera.main.ScreenToViewportPoint(mousePos);
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplier), ref velocity, smoothTime);
    }
}
