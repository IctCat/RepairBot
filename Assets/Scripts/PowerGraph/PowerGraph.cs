using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerGraph {
    public class PowerGraph : MonoBehaviour
    {
        public int electricity;
        public List<PowerNode> nodes = new List<PowerNode>();
        public List<PowerEdge> edges = new List<PowerEdge>();

        // Start is called before the first frame update
        void Start()
        {
            this.InitializeGraph();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitializeGraph() {
            // Node initializations
            for(int i = 0; i < nodes.Count; i++) {
                //PowerNode node = new PowerNode();
                //nodes.Add(node);
            }

            // Edge initializations
            for(int j = 0; j < edges.Count; j++) {
                //PowerEdge edge = new PowerEdge();
                //edges.Add(edge);
            }
        }
    }
}
