using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makine : MonoBehaviour
{
    private float machineTime=1f;
    private void Start()
    {
        StartCoroutine(MakineVer(machineTime,50));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    private IEnumerator MakineVer(float time,int maxDebug) 
    {
        var debugSayisi = 0;
        while (debugSayisi<maxDebug)
        {
            Debug.Log("Makine çalisti");
            debugSayisi++;
            yield return new WaitForSecondsRealtime(time);
        }
    }
}
