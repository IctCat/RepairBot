using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerNetwork;

namespace Entities {
    public enum EntityType {Generator, Socket, Link};

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

        public void Activate() {
            Debug.Log("Activate " + this.entityType.ToString() + " " + this.entityIndex);
            if(!isActivated) {
                this.isActivated = true;
                //if(entityType == EntityType.Socket) {
                //    this.powerGraph.UseNode(this.entityIndex, this.entityType);
                //} else if (entityType == EntityType.Link) {
                //    this.powerGraph.UseNode(this.entityIndex, this.entityType);
                //} else if (entityType == EntityType.Generator) {
                //    this.powerGraph.UseNode(this.entityIndex, this.entityType);
                //}
                this.powerGraph.UseNode(this.entityIndex, this.entityType, this.gameObject);
            } else if(entityType == EntityType.Socket) {
                this.powerGraph.UseNode(this.entityIndex, this.entityType, this.gameObject);
            }
        }
    }
}