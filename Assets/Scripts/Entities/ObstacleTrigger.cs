using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities {
    public class ObstacleTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        private bool isNear = false;
        private ObstacleHandler obstacleHandler;
        void Start()
        {
            this.obstacleHandler = GetComponent<ObstacleHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown ("e") || Input.GetKeyDown("f")) {
                this.CanActivate();
            }
        }

        void CanActivate() 
        {
            //Debug.Log("CanIActivate");
            if(this.isNear) {
                //Debug.Log("Is near");
                this.obstacleHandler.Activate();
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            Debug.Log("Triggered " + other.gameObject.name + " : " + this.gameObject.name);
            this.isNear = true;
        }
        private void OnTriggerExit(Collider other)
        {
            this.isNear = false;
        }
    }
}