using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject uiShopWindow;
    
    [SerializeField]
    private GameObject uiMessageWindow;

    [SerializeField] private Text textField;
    
    public void ToggleUI(bool val, GameObject window)
    {
        window.SetActive(val);
    }

    public void ShowText(string text)
    {
        ToggleUI(true, uiMessageWindow);
        textField.text = text;
    }

    public void ShowShop()
    {
        ToggleUI(true, uiShopWindow);
    }


}