using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light dirLight;           
    public float dayIntensity = 1.2f;
    public float nightIntensity = 0.1f;

    public void UpdateLightByLDR(int ldr)
    {
        if (ldr > 2500)
        {
            
            dirLight.intensity = nightIntensity;
            dirLight.color = new Color(0.6f, 0.7f, 1f); 
        }
        else
        {
            
            dirLight.intensity = dayIntensity;
            dirLight.color = Color.white;
        }
    }
}
