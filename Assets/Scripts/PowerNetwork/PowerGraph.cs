using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

namespace PowerNetwork {
    public class PowerGraph : MonoBehaviour
    {
        public PowerNode[] nodes;
        public PowerEdge[] edges;

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
            //for(int i = 0; i < nodes.Count; i++) {
                //PowerNode node = new PowerNode();
                //nodes.Add(node);
            //}

            // Edge initializations
            foreach(PowerEdge edge in edges) {
                PowerNode startNode = nodes[edge.startIndex];
                PowerNode endNode = nodes[edge.endIndex];
                if(startNode.IsWorking() && endNode.IsWorking()) {
                    edge.SetWorking(true);
                } else {
                    edge.SetWorking(false);
                }
            }
        }

        public void UpdateEdges() {
            foreach(PowerEdge edge in edges) {
                PowerNode startNode = nodes[edge.startIndex];
                PowerNode endNode = nodes[edge.endIndex];
                if(startNode.IsWorking() && endNode.IsWorking()) {
                    edge.SetWorking(true);
                } else {
                    edge.SetWorking(false);
                }
            }
        }

        public void RepairNode(int index, EntityType entityType) {
            
        }

        public void UseNode(int index, EntityType entityType) {

        }
    }
}
