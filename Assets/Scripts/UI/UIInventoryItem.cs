using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    [SerializeField] private Image borderImage;

    public event Action<UIInventoryItem> OnItemClicked;

    public bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }
    public void ResetData()
    {
        itemImage.gameObject.SetActive(false);
        empty = true;
    }
    public void Deselect()
    {
        borderImage.enabled = false;
    }
    public void SetData(Sprite sprite)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = sprite;
        empty = false;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnPointerClick(BaseEventData data)
    {
        if (empty) return;
            
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Left)
        {
            OnItemClicked?.Invoke(this);
        }
    }


}
