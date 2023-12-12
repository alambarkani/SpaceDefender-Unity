using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float paddingHorizontal = 0.5f;
    [SerializeField] float paddingVertical = 0.5f;

    Vector2 minBounds;
    Vector2 maxBounds;

    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingHorizontal, maxBounds.x - paddingHorizontal);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingVertical, maxBounds.y - paddingVertical);
        transform.position = newPos;
    }

    void InitBounds()
    {
        Camera camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
