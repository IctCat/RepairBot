using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PowerNetwork {
    abstract public class PowerTypes
    {
        public bool working;
        public int cost;
        public int index;

        // Start is called before the first frame update
        void Start()
        {
            // TODO initializations?
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetWorking(bool working) {
            //Debug.Log("Set working!" + working.ToString());
            this.working = working;
        }

        public bool IsWorking() {
            return this.working;
        }


        /// <summary> Repairs the element and returns reduced resource(int)</summary>
        /// <param name="resource">Int value</param>
        public int Repair(int resource) {
            Debug.Log("Attempting repair " + resource);
            if(!this.IsWorking() && resource >= cost) {
                this.working = true;
                Debug.Log("Repair success " + cost);
                return cost;
            }
            return -1;
        }

        //TODO if time. Generators have to be activated and electricity starts flowing to socket.
        /*public void Activate() {
            this.working = true;
        }*/
    }
}