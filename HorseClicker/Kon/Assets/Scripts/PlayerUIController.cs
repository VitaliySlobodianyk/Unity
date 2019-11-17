using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject msgBox;
    public TextMeshProUGUI bananasCount;
    private void Start()
    {
        HideMessage();
    }
    public void ShowMessage(int amount) {
        bananasCount.text = amount.ToString();
        msgBox.SetActive(true);
        Invoke("HideMessage", 1f);
    }

    private void HideMessage() {
        msgBox.SetActive(false);
    }
}
