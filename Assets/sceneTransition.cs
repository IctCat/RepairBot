using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class sceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.anyKey || Time.realtimeSinceStartup > 7f)
        {
            //Debug.Log("A key or mouse click has been detected");
            this.GetComponent<Animator>().SetBool("changeScene",true);
            SceneManager.LoadScene("MainScene");
        }
    }
}

