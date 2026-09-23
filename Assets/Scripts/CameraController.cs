//This script is attached to main camera, this script is used to have a camera that follows the player around, Arthur Phythian, 09/23/26
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
    transform.position = playerTransform.position + offset;
    }
}   
