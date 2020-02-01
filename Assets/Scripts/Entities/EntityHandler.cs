using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerNetwork;

namespace Entities {
    public enum EntityType {Generator, Socket, Link, Obstacle};

    public class EntityHandler : MonoBehaviour
    {
        public EntityType entityType;
        private bool isActivated = false;
        public int entityIndex;
        private GameObject PowerGraphGo;
        private PowerGraph powerGraph;

        // Start is called before the first frame update
        void Start()
        {
            this.PowerGraphGo = GameObject.FindWithTag("PowerGraph");
            this.powerGraph = this.PowerGraphGo.GetComponent<PowerGraph>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Activate() {
            if(!isActivated) {
                this.isActivated = true;
                if(entityType == EntityType.Socket) {
                    this.powerGraph.UseNode(this.entityIndex, this.entityType);
                } else if (entityType == EntityType.Link) {
                    this.powerGraph.RepairNode(this.entityIndex, this.entityType);
                } else if (entityType == EntityType.Generator) {
                    this.powerGraph.UseNode(this.entityIndex, this.entityType);
                } else if (entityType == EntityType.Obstacle) {
                    // Todo call for removing the obstacle
                }
            }
        }
    }
}