using System;
using System.Net.Http;
using System.Threading.Tasks;

public class VPNConnector
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task ConnectToVPN(string vpnServer, string username, string password)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("server", vpnServer),
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password)
        });

        HttpResponseMessage response = await client.PostAsync("https://vpn-service.com/connect", content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Connected to VPN: {responseBody}");
    }

    public static async Task Main(string[] args)
    {
        string vpnServer = "vpn.example.com";  // Replace with your VPN server
        string username = "your-username";  // Replace with your VPN username
        string password = "your-password";  // Replace with your VPN password
        await ConnectToVPN(vpnServer, username, password);
    }
}
