using UnityEngine;
using UnityEngine.UI;

public class SensorDisplay : MonoBehaviour
{
    public Text tempText;
    public Text humText;
    public Text waterText;
    public Text wetText;
    public Text ldrText;
    public Text lightText;

    public GameObject rainEffect;      
    public int waterThreshold = 1500;

    public Light sunLight;             
    public int nightThreshold = 2500;  
    public Material daySkybox;      
    public Material nightSkybox;    

    public GameObject fogPrefab;
    private GameObject fogInstance;
    public int fogHumidity = 70;   


    public void UpdateUI(MQTTManager.SensorData data)
    {
        tempText.text = "Temp: " + data.temp + "°C";
        humText.text = "Humidity: " + data.humidity + "%";
        waterText.text = "Water: " + data.water;
        wetText.text = "Wet: " + data.wet;
        ldrText.text = "LDR: " + data.ldr;
        lightText.text = "Light: " + data.light;

       
        if (data.water > waterThreshold || data.wet == "lot of water")
        {
            if (!rainEffect.activeSelf)
                rainEffect.SetActive(true);
        }
        else
        {
            if (rainEffect.activeSelf)
                rainEffect.SetActive(false);
        }

        
        if (data.ldr > nightThreshold)
        {
            
            RenderSettings.skybox = nightSkybox;

            sunLight.intensity = 0.2f;
            sunLight.color = new Color(0.7f, 0.7f, 0.8f);
        }
        else
        {
            
            RenderSettings.skybox = daySkybox;

            sunLight.intensity = 1.0f;
            sunLight.color = Color.white;
        }
        
        if (data.humidity > fogHumidity)
        {
            if (fogInstance == null)
            {
                fogInstance = Instantiate(fogPrefab, Vector3.zero, Quaternion.identity);
            }
        }
        else
        {
            if (fogInstance != null)
            {
                Destroy(fogInstance);
                fogInstance = null;
            }
        }

    }
}
