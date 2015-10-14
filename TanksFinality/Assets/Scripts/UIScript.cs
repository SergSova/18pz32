using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Slider healthSlider;
    public Slider armorSlider;

    private int health;
    private int armor;

    void Start()
    {
        // Get health and armor for current tank
        health = 100;
        armor = 100;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X) && armor != 0)
        {
            armor -= 20;
            armorSlider.value = armor;
        }
        else if (Input.GetKeyUp(KeyCode.X) && armor == 0)
        {
            health -= 10;
            healthSlider.value = health;
        }
    }
}
