using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationHandlerC : MonoBehaviour
{
    public void EndCredits()
    {
        SceneManager.LoadScene("Menu");
    }
}