using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

namespace PowerNetwork {
    public class PowerGraph : MonoBehaviour
    {
        private GameObject GameManagerGo;
        private GameManager gameManager;
        public PowerNode[] nodes;
        public PowerEdge[] edges;

        // Start is called before the first frame update
        void Start()
        {
            this.GameManagerGo = GameObject.FindWithTag("GameManager");
            this.gameManager = this.GameManagerGo.GetComponent<GameManager>();
            this.InitializeGraph();
        }

        void InitializeGraph() 
        {
            // Node initializations
            //for(int i = 0; i < nodes.Count; i++) {
                //PowerNode node = new PowerNode();
                //nodes.Add(node);
            //}

            // Edge initializations
            //Deprecated
            /*foreach(PowerEdge edge in edges) {
                PowerNode startNode = nodes[edge.startIndex];
                PowerNode endNode = nodes[edge.endIndex];
                if(startNode.IsWorking() && endNode.IsWorking()) {
                    edge.SetWorking(true);
                } else {
                    edge.SetWorking(false);
                }
            }*/
            this.InitializeNodes();
            this.UpdateEdges();
            Debug.Log("Initialize DONE");
        }

        public void InitializeNodes() {
            foreach(PowerNode node in nodes) {
                node.InitializeNode();
            }
        }

        public void UpdateEdges() 
        {
            foreach(PowerEdge edge in edges) {
                PowerNode startNode = nodes[edge.startIndex];
                PowerNode endNode = nodes[edge.endIndex];
                if(startNode.IsWorking() && endNode.IsWorking()) {
                    //Debug.Log("Edge " + edge.index);
                    edge.SetWorking(true);
                } else if((startNode.nodeType == EntityType.Generator) && (startNode.IsWorking())) {
                    //Debug.Log("Edge " + edge.index);
                    edge.SetWorking(true);
                } else if((endNode.nodeType == EntityType.Generator) && (endNode.IsWorking())) { 
                    edge.SetWorking(true);
                } else {
                    //Debug.Log("Edge " + edge.index);
                    edge.SetWorking(false);
                }
            }
        }

        public int CheckCharges(PowerNode node, HashSet<int> set) 
        {
            if(set.Contains(node.index)) {
                return 0;
            }
            set.Add(node.index);

            int edgeCount = node.nodeEdges.Length;
            int gainedCharge = 0;
            if((node.nodeType == EntityType.Generator) || (node.nodeType == EntityType.Socket))
                if(node.charge > 0) {
                    gainedCharge += node.Use();
                }

            for(int i = 0; i < edgeCount; i++) {
                PowerEdge edge = edges[node.nodeEdges[i]];
                if(edge.IsWorking()) {
                    if(node.index != edge.startIndex) {
                        PowerNode startNode = nodes[edge.startIndex];
                        gainedCharge += this.CheckCharges(startNode, set);
                    }
                    if(node.index != edge.endIndex) {
                        PowerNode endNode = nodes[edge.endIndex];
                        gainedCharge += this.CheckCharges(endNode, set);
                    }
                }

            }
            return gainedCharge;
        }

        public void UseNode(int index, EntityType entityType, GameObject go) 
        {
            Debug.Log("UseNode " + entityType.ToString());
            if(entityType == EntityType.Socket) {
                PowerNode node = nodes[index];
                HashSet<int> set = new HashSet<int>();
                int gain = this.CheckCharges(node, set);
                this.gameManager.IncreaseElectricity(gain);
            } else if (entityType == EntityType.Link) {
                PowerNode node = nodes[index];
                int scrap = this.gameManager.scrap;
                int cost = nodes[index].Repair(scrap);
                if(cost != -1) {
                    this.gameManager.DecreaseScrap(cost);
                    Debug.Log("Trying to disable " + go.name + " " + go.transform.GetChild(0).gameObject.name);
                    go.transform.GetChild(0).gameObject.SetActive(false);
                    this.UpdateEdges();
                }
            } else if (entityType == EntityType.Generator) {
                int scrap = this.gameManager.scrap;
                this.gameManager.DecreaseScrap(nodes[index].Repair(scrap));
                this.UpdateEdges();
            }
        }
    }
}
