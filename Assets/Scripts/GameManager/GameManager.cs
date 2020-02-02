using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int electricity = 5;
    public int scrap = 4;
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
        StartCoroutine(DrainEnumerator(1, 10));
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator DrainEnumerator(int cost, int repeatRate) {
        yield return new WaitForSeconds(repeatRate); // New line
        while (true) {
            this.DecreaseElectricity(cost);
            yield return new WaitForSeconds(repeatRate);
        }
        yield return null;
    }

    public void IncreaseElectricity(int addition) {
        this.electricity += addition;
        this.electricityText.text = this.electricity.ToString();
    }
    
    public void DecreaseElectricity(int cost) {
        this.electricity -= cost;
        this.electricityText.text = this.electricity.ToString();
    }

    public void IncreaseScrap(int addition) {
        Debug.Log("Scrap increase!");
        this.scrap += addition;
        this.scrapText.text = this.scrap.ToString();
    }

    public void DecreaseScrap(int cost) {
        Debug.Log("Scrap decrease! " + cost);
        this.scrap -= cost;
        this.scrapText.text = this.scrap.ToString();
    }
}
