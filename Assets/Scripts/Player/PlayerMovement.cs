using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerMovement : MonoBehaviour
    {
        public bool isMovementRelativeToCamera = true;
        public float speed = 10f;
        public float cameraRotateSpeed = 1f;
        public float cameraDistance = 10f;
        public float velocityTreshold = 0.1f;
        public float initialCameraRotation = 0f;
        public float rotationTreshold = 30f;
        public Transform pushPoint;
        public Transform camera;

        private float lastCameraTargetRotation;

        void Start() {
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>().transform;
            }

            lastCameraTargetRotation = initialCameraRotation;
        }

        private void LateUpdate()
        {
            UpdateCamera();
        }

        void FixedUpdate () {
            var move = Vector3.zero;

            if (Input.GetKey ("w") || Input.GetKey("up")) {
                move.z = 1f;
            }
            if (Input.GetKey ("s") || Input.GetKey("down")) {
                move.z = -1f;
            }

            if (isMovementRelativeToCamera)
            {
                move = camera.rotation * move;
                move.y = 0;
                move.Normalize();
            }
            
            GetComponent<Rigidbody>().AddForceAtPosition(move *= speed, pushPoint.position);
        }

        private void UpdateCamera()
        {
            var velocity = GetComponent<Rigidbody>().velocity.ToVector2();

            //Manual camera rotate
            var cameraTargetRotation = lastCameraTargetRotation;
            if (Input.GetKeyDown(KeyCode.A))
            {
                cameraTargetRotation += 90f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                cameraTargetRotation -= 90f;
            }

            if (velocity.magnitude > velocityTreshold)
            {
                lastCameraTargetRotation = cameraTargetRotation;
            }
            else
            {
                cameraTargetRotation = lastCameraTargetRotation;
            }


            var cameraCurrentRotation = (transform.position - camera.position).ToVector2().GetAngle();

            var newCameraAngle = Mathf.MoveTowardsAngle(cameraCurrentRotation, cameraTargetRotation, Time.deltaTime * cameraRotateSpeed);

            var cameraDeltaPosition =
                new Vector2(
                    -Mathf.Cos(Mathf.Deg2Rad * newCameraAngle),
                    -Mathf.Sin(Mathf.Deg2Rad * newCameraAngle));

            var player2DPos = transform.position.ToVector2();
            camera.position = (player2DPos + (cameraDeltaPosition * cameraDistance)).ToVector3(camera.position.y);

            //Look player
            var rot = camera.rotation;
            rot.SetLookRotation(transform.position - camera.position);
            camera.rotation = rot;

        }
    }
}