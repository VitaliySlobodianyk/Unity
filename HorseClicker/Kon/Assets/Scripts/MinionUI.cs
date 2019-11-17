using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinionUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float offsetX = 1f;
    public float offsetY = 0f;
    public GameObject msgBox;
    public TextMeshProUGUI bananasCount;

    void Start()
    {
        HideMessage();
        
    }

 
    void Update()
    {
        msgBox.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);  
    }

    public void ShowMessage( int amount) {
        msgBox.SetActive(true);
        bananasCount.text = amount.ToString();
        Invoke("HideMessage", 1f);

    }

    private void HideMessage() {
        msgBox.SetActive(false);
    }
}
