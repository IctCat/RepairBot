using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerNetwork {
    [System.Serializable]
    public class PowerEdge : PowerTypes
    {
        //Start node
        public int startIndex;
        //End node
        public int endIndex;
    }
}