using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BarsController : MonoBehaviour
{
    private int maxHealth;
    private int maxSanity;
    private int currentMaxAmmo;

    private UIDocument gameViewUI;
    private VisualElement healthBar;
    private VisualElement sanityBar;
    private VisualElement weaponIcon;
    private Label weaponName;
    private Label weaponAmmo;
    
    void Start()
    {
        gameViewUI = GetComponent<UIDocument>();
        healthBar = gameViewUI.rootVisualElement.Q<VisualElement>("HealthBar");
        sanityBar = gameViewUI.rootVisualElement.Q<VisualElement>("SanityBar");
        weaponIcon = gameViewUI.rootVisualElement.Q<VisualElement>("WeaponIcon");
        weaponName = gameViewUI.rootVisualElement.Q<Label>("WeaponName");
        weaponAmmo = gameViewUI.rootVisualElement.Q<Label>("Ammo");
        maxHealth = 100;
        maxSanity = 100;
        currentMaxAmmo = 0;
        UpdateHealthBar(maxHealth);
        UpdateSanityBar(0);
    }

    public void UpdateHealthBar(int health)
    {
        VisualElement topHealth = healthBar.Q<VisualElement>("TopHealth");
        VisualElement botHealth = healthBar.Q<VisualElement>("BotHealth");
        topHealth.style.height = Length.Percent(maxHealth - health);
        botHealth.style.height = Length.Percent(health);
    }
    public void UpdateSanityBar(int sanity)
    {
        VisualElement topSanity = sanityBar.Q<VisualElement>("TopSanity");
        VisualElement botSanity = sanityBar.Q<VisualElement>("BotSanity");
        topSanity.style.height = Length.Percent(maxSanity - sanity);
        botSanity.style.height = Length.Percent(sanity);
    }

    public void ChangeWeapon(Texture2D img, string newName, int maxAmmo)
    {
        weaponIcon.style.backgroundImage = img;
        weaponName.text = newName;
        weaponAmmo.text = string.Format("{0} / {0}", maxAmmo);
        currentMaxAmmo = maxAmmo;
    }

    public void UpdateAmmo(int ammo)
    {
        weaponAmmo.text = string.Format("{0} / {1}", ammo, currentMaxAmmo);
    }
}
