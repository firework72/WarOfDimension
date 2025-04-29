using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject goldText;
    public GameObject expText;
    public GameObject nexusHpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<TextMeshProUGUI>().text = "Gold : " + GameManager.Instance.gold.ToString();
        expText.GetComponent<TextMeshProUGUI>().text = "Exp : " + GameManager.Instance.exp.ToString();
        nexusHpText.GetComponent<TextMeshProUGUI>().text = "NexusHp : " + GameManager.Instance.nexusHp.ToString();
    }
}
