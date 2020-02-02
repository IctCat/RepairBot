using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuC : MonoBehaviour
{
    public const string MenuScene = "Menu";
    public const string GameScene = "MainScene";
    public const string CreditsScene = "Credits";

    [SerializeField] private GameObject StartObject = null;
    [SerializeField] private GameObject CreditsObject = null;

    /*private Button StartBt;
    private Button CreditsBt;*/
    
    void Awake()
    {
        /*StartBt = StartObject.GetComponent<Button>();
        StartBt.onClick.AddListener(StartGame);
        CreditsBt = CreditsObject.GetComponent<Button>();
        CreditsBt.onClick.AddListener(PlayCredits);*/
    }

    void StartGame() {
        SceneManager.LoadScene(GameScene);
    }

    void PlayCredits() {
        SceneManager.LoadScene(CreditsScene);
    }
}
