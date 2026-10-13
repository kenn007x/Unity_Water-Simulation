using UnityEngine;

public class DHTDisplay : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textUI;

    public void SetValues(float temp, float humidity, int water, string wet, int ldr, string light)
    {
        textUI.text =
            $"Temperature: {temp}°C\n" +
            $"Humidity: {humidity}%\n" +
            $"Water: {water}\n" +
            $"Wet: {wet}\n" +
            $"LDR: {ldr}\n" +
            $"Light: {light}";
    }
}
