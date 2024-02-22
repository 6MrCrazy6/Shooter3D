using TMPro;
using UnityEngine;

public class PlayerUIElements : MonoBehaviour
{
    public WeaponAmmo ammo; 

    public TextMeshProUGUI ammoText;

    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        if (ammo != null && ammoText != null)
        {
            ammoText.text = ammo.currentAmmo + "/" + ammo.extraAmmo;
        }
    }
}
