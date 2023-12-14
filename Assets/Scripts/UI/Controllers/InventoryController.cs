using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventory uiInventory;
    public int gridInventorySize = 10;

    private void Start()
    {
        uiInventory.InitializeInventoryUI(gridInventorySize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!uiInventory.isActiveAndEnabled)
            {
                uiInventory.Show();
            }
            else
            {
                uiInventory.Hide();
            }
        }
    }
}
