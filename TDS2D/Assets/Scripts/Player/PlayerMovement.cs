using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    Vector2 moveInput;
    Vector2 screenBoundary;
    Vector2 dash;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dashSpeed = 15f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnDash()
    {
        Debug.Log("Dash");
        rb.AddForce(transform.forward * 500, ForceMode2D.Impulse);
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);

        //rb.velocity = moveInput * moveSpeed;

        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundary.x, screenBoundary.x),Mathf.Clamp(transform.position.y, -screenBoundary.y, screenBoundary.y));
    }
}
