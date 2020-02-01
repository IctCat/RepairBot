using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        // Start is called before the first frame update
        void Start() {
            Debug.Log("Start!");
        }

        void Update () {
            Vector3 pos = transform.position;
    
            if (Input.GetKey ("w") || Input.GetKey("up")) {
               pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey ("s") || Input.GetKey("down")) {
               pos.z -= speed * Time.deltaTime;
            }
            if (Input.GetKey ("d") || Input.GetKey("right")) {
               pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey ("a") || Input.GetKey("left")) {
               pos.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey ("space")) {
               pos.y += speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }
}