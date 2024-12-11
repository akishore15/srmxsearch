using System;
using System.Net;
using System.Net.Sockets;

public class Subnetter
{
    public static void CreateSubnet(string ipAddress, int prefixLength)
    {
        IPAddress ip = IPAddress.Parse(ipAddress);
        byte[] addressBytes = ip.GetAddressBytes();
        int subnetMask = ~((1 << (32 - prefixLength)) - 1);

        Console.WriteLine($"IP Address: {ip}");
        Console.WriteLine($"Subnet Mask: {new IPAddress(BitConverter.GetBytes(subnetMask))}");
    }

    public static void Main(string[] args)
    {
        string ipAddress = "192.168.1.0";  // Replace with your desired IP address
        int prefixLength = 24;  // Replace with your desired prefix length
        CreateSubnet(ipAddress, prefixLength);
    }
}
