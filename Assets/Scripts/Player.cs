using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // properties
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;

    // call for each frame
    private void Update() {
        Vector2 inputVector = gameInput.getInputMovementNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float rotateSpeed = 20f;

        // Update position
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        isWalking = moveDirection != Vector3.zero;
    }

    public bool IsWalking() {
        return isWalking;
    }

    //  call for each fixed time interval
    // default is 0.02 seconds
    private void FixedUpdate() {

    }

    // call for each frame after update
    private void LateUpdate() {
    }
}
