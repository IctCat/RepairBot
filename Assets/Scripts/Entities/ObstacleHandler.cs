using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerNetwork;

namespace Entities {
    public class ObstacleHandler : MonoBehaviour
    {
        private bool isActivated = false;
        public int entityIndex;
        public int cost;
        private GameObject GameManagerGo;
        private GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            this.GameManagerGo = GameObject.FindWithTag("GameManager");
            this.gameManager = this.GameManagerGo.GetComponent<GameManager>();
        }

        public void Activate() {
            if(!this.isActivated) {
                this.isActivated = true;
                this.gameManager.DecreaseScrap(this.cost);
            }
        }
    }
}