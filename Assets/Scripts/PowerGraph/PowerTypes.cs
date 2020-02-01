using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerGraph {
    abstract public class PowerTypes
    {
        private bool working;
        public int cost;

        // Start is called before the first frame update
        void Start()
        {
            // TODO initializations?
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsWorking() {
            return this.working;
        }


        /// <summary> Repairs the element and returns reduced resource(int)</summary>
        /// <param name="resource">Int value</param>
        public int Repair(int resource) {
            this.working = true;
            resource -= this.cost;
            return resource;
        }
    }
}