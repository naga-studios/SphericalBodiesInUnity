using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private float cameraSensitivity = 5f;

    [SerializeField] private float yMin = 5f;
    [SerializeField] private float yMax = 5f;

    [SerializeField] private Transform player;

    private Transform cameraTransform;
    private Vector2 currentPos;
    private Vector2 newPos;

    private float verticalLookRotation;

    void Start()
    {
        cameraTransform = this.transform;
    }

    void Update()
    {
        CheckForMouseMovement();
    }

    private void CheckForMouseMovement()
    {
        player.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cameraSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * cameraSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, yMin, yMax);
        cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
}
