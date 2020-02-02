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
        //Indexes for edges connected to the node
        public int[] nodeEdges;

        // Start is called before the first frame update
        public PowerNode()
        {
            /*Debug.Log("PowerNode Start " + nodeType.ToString());
            if(this.nodeType == EntityType.Link) {
                Debug.Log("Link");
                this.SetWorking(false);
            } else if(this.nodeType == EntityType.Socket) {
                // Socket is always working
                Debug.Log("Socket");
                this.SetWorking(true);
            } else if(this.nodeType == EntityType.Generator) {
                Debug.Log("Generator");
                this.SetWorking(false);
            }*/
        }

        public void InitializeNode() {
            //Debug.Log("Initializing node " + this.index);
            //Debug.Log(this.nodeType.ToString());
        }

        /// <summary> Uses the charge.</summary>
        public int Use() {
            int gain = this.charge;
            this.charge = 0;
            return gain;
        }

        public void IncreaseCharge(int addition) {
            this.charge += addition;
        }

        public void DecreaseCharge(int cost) {
            this.charge -= cost;
        }
    }
}