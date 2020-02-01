using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

namespace PowerNetwork {

    [System.Serializable]
    public class PowerNode : PowerTypes
    {
        public EntityType nodeType;
        public int charge;

        // Start is called before the first frame update
        void Start()
        {
            if(this.nodeType == EntityType.Link) {
                this.SetWorking(false);
            } 
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary> Uses the charge.</summary>
        public int Use() {
            int gain = this.charge;
            this.charge = 0;
            return gain;
        }
    }
}