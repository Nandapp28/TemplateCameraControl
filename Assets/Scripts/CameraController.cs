using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    // === CAMERA REFERENCES ===
    [Header("Player References")]
    public Transform player;
    public Transform playerBody;
    public Transform orientation;
    public Rigidbody rb;

    [Header("Combat System")]
    public Transform CombatCenter;

    [Header("Camera Settings")]
    public float speed = 10f;

    // Camera GameObjects for different modes
    [Header("Camera Objects")]
    public GameObject thirdPersonCam;
    public GameObject thirdPersonCombat;
    public GameObject thirdPersonTopdown;

    // === CAMERA STATE ===
    private int camMode = 0; // 0=Basic, 1=Combat, 2=Topdown

    public enum CamStyle
    {
        Basic,
        Combat,
        Topdown
    }

    public CamStyle camStyle = CamStyle.Basic;

    // === UNITY LIFECYCLE ===
    private void Start()
    {
        // Lock cursor for camera control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize camera
        changeCamPress();
    }

    private void Update()
    {
        // Handle camera switching input
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeCamPress();
        }

        // Update player orientation based on camera
        UpdatePlayerOrientation();
    }

    // === CAMERA CONTROL METHODS ===
    private void UpdatePlayerOrientation()
    {
        if (camStyle == CamStyle.Combat)
        {
            // Combat mode: face combat center
            Vector3 combatDir = CombatCenter.position - new Vector3(transform.position.x, CombatCenter.position.y, transform.position.z);
            orientation.forward = combatDir.normalized;
            playerBody.forward = combatDir.normalized;
        }
        else
        {
            // Basic/Topdown: face camera direction
            Vector3 cameraDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = cameraDir.normalized;

            // Handle movement input
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = orientation.forward * vertical + orientation.right * horizontal;

            if (moveDir != Vector3.zero)
            {
                playerBody.forward = Vector3.Slerp(playerBody.forward, moveDir.normalized, Time.deltaTime * speed);
            }
        }
    }

    private void switchCamera(CamStyle style)
    {
        // Disable all cameras
        thirdPersonCam.SetActive(false);
        thirdPersonCombat.SetActive(false);
        thirdPersonTopdown.SetActive(false);

        // Set new style
        camStyle = style;

        // Enable appropriate camera
        switch (camStyle)
        {
            case CamStyle.Basic:
                thirdPersonCam.SetActive(true);
                break;
            case CamStyle.Combat:
                thirdPersonCombat.SetActive(true);
                break;
            case CamStyle.Topdown:
                thirdPersonTopdown.SetActive(true);
                break;
        }
    }

    private void changeCamPress()
    {
        switch (camMode)
        {
            case 0: // Basic -> Combat
                switchCamera(CamStyle.Combat);
                CombatCenter.gameObject.SetActive(true);
                camMode = 1;
                break;

            case 1: // Combat -> Topdown
                switchCamera(CamStyle.Topdown);
                CombatCenter.gameObject.SetActive(false);
                camMode = 2;
                break;

            case 2: // Topdown -> Basic
            default: // Reset to Basic
                switchCamera(CamStyle.Basic);
                CombatCenter.gameObject.SetActive(false);
                camMode = 0;
                break;
        }
    }
}
