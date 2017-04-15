using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParticleData : MonoBehaviour {

    private int lightValue;
    private string tempVal;
    private Transform cubeTransform;
    private float remappedValue;
    private Vector3 tempScale;

    IEnumerator GetText()
    {

        while (true)
        {
            WWW lightWWW = new WWW("https://api.particle.io/v1/devices/3d001c000e47353136383631/lightValue?access_token=b2f194d149625d4195b03a4d1de353cef0b45430");
            yield return lightWWW;
            JSONObject lightData = new JSONObject(lightWWW.text);

            //float light = lightData["light"].n;
            lightData = lightData["result"];

            lightValue = int.Parse(tempVal);
            //textMesh.text = tempVal;

            remappedValue = Remap(lightValue, 200, 800, 0.05f, 0.5f);

            tempScale = new Vector3(remappedValue, remappedValue, remappedValue);
            cubeTransform.localScale = tempScale;

            Debug.Log(lightValue);

            yield return new WaitForSeconds(1);
        }

    }

    void Start()
    {
        cubeTransform = gameObject.transform;
        a
        StartCoroutine(GetText());
    }


    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}