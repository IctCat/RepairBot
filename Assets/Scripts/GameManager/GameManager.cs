using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int electricity = 5;
    public int scrap = 0;
    private float timer = 0.0f;
    public GameObject electricityTextObject;
    private TextMeshProUGUI electricityText;
    public GameObject scrapTextObject;
    private TextMeshProUGUI scrapText;
    
    void Start()
    {
        this.electricityText = this.electricityTextObject.GetComponent<TextMeshProUGUI>();
        this.electricityText.text = this.electricity.ToString();
        this.scrapText = this.scrapTextObject.GetComponent<TextMeshProUGUI>();
        this.scrapText.text = this.scrap.ToString();
        
        //InvokeRepeating("DrainElectricity", 1.0f, 1.0f);    
        StartCoroutine(DrainEnumerator(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator DrainEnumerator(int cost, int repeatRate) {
        this.DecreaseElectricity(cost);
        yield return new WaitForSeconds(repeatRate);
    }

    void IncreaseElectricity(int addition) {
        this.electricity += addition;
        this.electricityText.text = this.electricity.ToString();
    }
    
    void DecreaseElectricity(int cost) {
        this.electricity -= cost;
        this.electricityText.text = this.electricity.ToString();
    }

    void IncreaseScrap(int addition) {
        this.scrap += addition;
        this.scrapText.text = this.scrap.ToString();
    }

    void DecreaseScrap(int cost) {
        this.scrap -= cost;
        this.scrapText.text = this.scrap.ToString();
    }
}
