using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    private List<UIInventoryItem> listOfUiItems = new List<UIInventoryItem>();

    public Sprite image;

    public void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            uiItem.transform.localScale = new Vector3(1f, 1f, 1f);
            listOfUiItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
        }
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        listOfUiItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        listOfUiItems[0].SetData(image);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
