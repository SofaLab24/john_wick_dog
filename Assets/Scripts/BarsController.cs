using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BarsController : MonoBehaviour
{
    private int maxHealth;
    private int maxSanity;

    private UIDocument gameViewUI;
    private VisualElement healthBar;
    private VisualElement sanityBar;
    
    void Start()
    {
        gameViewUI = GetComponent<UIDocument>();
        healthBar = gameViewUI.rootVisualElement.Q<VisualElement>("HealthBar");
        sanityBar = gameViewUI.rootVisualElement.Q<VisualElement>("SanityBar");
        maxHealth = 100;
        maxSanity = 100;
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
}
