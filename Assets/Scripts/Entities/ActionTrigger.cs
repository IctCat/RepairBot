using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities {
    public class ActionTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        private bool isNear = false;
        private EntityHandler entityHandler;
        void Start()
        {
            this.entityHandler = GetComponent<EntityHandler>();
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
                this.entityHandler.Activate();
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            Debug.Log("Triggered");
            this.isNear = true;
        }
        private void OnTriggerExit(Collider other)
        {
            this.isNear = false;
        }
    }
}