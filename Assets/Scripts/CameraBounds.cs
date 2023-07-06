using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class CameraBounds : MonoBehaviour
    {
        private BoxCollider2D bounds;
        private CameraController cameraController;

        private void Awake()
        {
            bounds = GetComponent<BoxCollider2D>();
            cameraController = FindObjectOfType<CameraController>();
            cameraController.SetBounds(bounds);
        }
    }
}
