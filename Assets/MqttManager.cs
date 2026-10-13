using UnityEngine;
using Newtonsoft.Json;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;

public class MQTTManager : MonoBehaviour
{
    private IMqttClient client;

    
    private SensorData latestData;
    private bool hasNewData = false;

    [System.Serializable]
    public class SensorData
    {
        public float temp;
        public float humidity;
        public int water;
        public string wet;
        public int ldr;
        public string light;
    }

    public string broker = "broker.emqx.io";
    public int port = 1883;
    public string topic = "esp32/sensors";

    public SensorDisplay ui;
 

    async void Start()
    {
        var factory = new MqttFactory();
        client = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port)
            .Build();

        client.UseConnectedHandler(async e =>
        {
            Debug.Log("MQTT Connected!");
            await client.SubscribeAsync(topic);
        });

        client.UseApplicationMessageReceivedHandler(e =>
        {
            string msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Debug.Log("Received: " + msg);

           
            latestData = JsonConvert.DeserializeObject<SensorData>(msg);

            
            hasNewData = true;
        });

        await client.ConnectAsync(options);
    }

    void Update()
    {
       
        if (hasNewData)
        {
            ui.UpdateUI(latestData);

            

            

            hasNewData = false;
        }
    }
}
