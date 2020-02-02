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
        public float initialCameraRotation = 0f;
        public float cameraTestRayRadius = 0.1f;
        
        public Transform pushPoint;
        public Transform camera;

        public Collider stabilityCollider;

        private float lastCameraTargetRotation;
        private float initialCameraHeight;
        private bool isAlive;

        public void Die()
        {
            isAlive = false;

            //Force recalculate center of mass
            var rigidbody = GetComponent<Rigidbody>();
            var velocity = rigidbody.velocity;
            var angularVelocity = rigidbody.angularVelocity;

            DestroyImmediate(stabilityCollider);
            DestroyImmediate(rigidbody);
            
            var newRigidbody = gameObject.AddComponent<Rigidbody>();

            newRigidbody.velocity = velocity;
            newRigidbody.angularVelocity = angularVelocity;
        }

        void Start() {
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>().transform;
            }

            initialCameraHeight = camera.position.y;
            lastCameraTargetRotation = initialCameraRotation;
            isAlive = true;
        }

        private void LateUpdate()
        {
            UpdateCamera();
        }

        void FixedUpdate ()
        {
            if (!isAlive)
            {
                return;
            }
            
            var move = Vector3.zero;

            if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                move.z = 1f;
            }
            if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                move.z = -1f;
            }

            if (isMovementRelativeToCamera)
            {
                move = camera.rotation * move;
                move.y = 0;
                move.Normalize();
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))
            {
                move *= 2f;
            }

            GetComponent<Rigidbody>().AddForceAtPosition(move * speed, pushPoint.position);

            //GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * stabilityForce, stabilityPoint.position);
        }

        private void UpdateCamera()
        {
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

//if DEBUG
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Die();
            }
//#endif

            lastCameraTargetRotation = cameraTargetRotation;
            
            var cameraCurrentRotation = (transform.position - camera.position).ToVector2().GetAngle();

            var newCameraAngle = Mathf.LerpAngle(cameraCurrentRotation, cameraTargetRotation, Time.deltaTime * cameraRotateSpeed);

            var cameraDeltaPosition =
                new Vector2(
                    -Mathf.Cos(Mathf.Deg2Rad * newCameraAngle),
                    -Mathf.Sin(Mathf.Deg2Rad * newCameraAngle));

            var player2DPos = transform.position.ToVector2();
            var wantedCameraPosition = (player2DPos + (cameraDeltaPosition * cameraDistance)).ToVector3(initialCameraHeight);

            var cameraRayStart = transform.position + (Vector3.up * 2f);
            var rayDelta = wantedCameraPosition - cameraRayStart;
            cameraRayStart += rayDelta.normalized * 0.1f;

            if (Physics.SphereCast(new Ray(cameraRayStart, rayDelta), cameraTestRayRadius, out var raycastHit, rayDelta.magnitude, ~(1 << 9)))
            {
                wantedCameraPosition = rayDelta.normalized * raycastHit.distance + cameraRayStart;
            }

            camera.position = wantedCameraPosition;

            //Look player
            var rot = camera.rotation;
            rot.SetLookRotation(transform.position - camera.position);
            camera.rotation = rot;

        }
    }
}