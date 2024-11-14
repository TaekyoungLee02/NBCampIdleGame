using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Player player;

    public GameObject inventory;

    public GameObject itemPrefab;

    private void Start()
    {
        var items = player.Inventory.Items;

        foreach (var item in items)
        {
            var go = Instantiate(itemPrefab, inventory.transform);
            go.GetComponentInChildren<TextMeshProUGUI>().text = item.GetName();
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
    }

    public void CloseInventroy()
    {
        inventory.SetActive(false);

    }

}
