using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static List<AudioInstanceScript> audioInstances = new List<AudioInstanceScript>();

    private void Awake()
    {
        audioInstances.Clear();
    }

    public static void DimAudio()
    {
        foreach (var item in audioInstances)
        {
            item.Dim();
        }
    }
    public static void EnableAudio()
    {
        foreach (var item in audioInstances)
        {
            item.Enable();
        }
    }
    public static void DisableAudio()
    {
        foreach (var item in audioInstances)
        {
            item.Disable();
        }
    }
}
