using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class affichebutton : MonoBehaviour
{
    [Header("Shop : ")]
    public GameObject shopObject; // Reference to the shop object to enable/disable
    public InputActionReference ShopAction; // Unity Input Action used to open the shop

    [Header("Button to Open Shop")]
    public List<ControllerBinding> ShopInput = new List<ControllerBinding>() { ControllerBinding.None };

    private bool isShopOpen = false;

    private void Update()
    {
        // Check if the shop button is pressed
        bool shopButtonDown = CheckShop();

        // Check if shop state has changed
        if (shopButtonDown && !isShopOpen)
        {
            // Shop button pressed, open the shop
            OpenShop();
        }
        else if (!shopButtonDown && isShopOpen)
        {
            // Shop button released, close the shop
            CloseShop();
        }

        isShopOpen = shopButtonDown;
    }

    private void OpenShop()
    {
        if (shopObject != null)
        {
            shopObject.SetActive(true);
        }
    }

    private void CloseShop()
    {
        if (shopObject != null)
        {
            shopObject.SetActive(false);
        }
    }

    public virtual bool CheckShop()
    {
        // Check for bound controller button for opening the shop
        for (int x = 0; x < ShopInput.Count; x++)
        {
            if (InputBridge.Instance.GetControllerBindingValue(ShopInput[x]))
            {
                return true;
            }
        }

        // Check Unity Input Action for opening the shop
        if (ShopAction != null)
        {
            return ShopAction.action.triggered;
        }

        return false;
    }
}
