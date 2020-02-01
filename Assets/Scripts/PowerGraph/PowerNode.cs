using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerGraph {
    public enum NodeType {Generator, Socket};

    [System.Serializable]
    public class PowerNode : PowerTypes
    {
        public NodeType nodeType;
        public int charge;

        // Start is called before the first frame update
        void Start()
        {

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