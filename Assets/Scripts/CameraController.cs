using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothing;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] float cameraFloor = -2;

    void Update()
    {
        if (player.position.y > cameraFloor)
        {
            Vector3 target = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref cameraVelocity, smoothing);
            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
    }
}
