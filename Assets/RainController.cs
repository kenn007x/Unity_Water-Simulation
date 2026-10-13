using UnityEngine;
using UnityEngine.InputSystem;

public class RainController : MonoBehaviour
{
    public GameObject rainEffect;
    private bool isRaining = false;

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ToggleRain();
        }
    }

    void ToggleRain()
    {
        isRaining = !isRaining;
        rainEffect.SetActive(isRaining);
    }

    
    public void SetRain(bool state)
    {
        isRaining = state;
        rainEffect.SetActive(isRaining);
    }
}
