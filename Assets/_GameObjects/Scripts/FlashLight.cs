using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private int lightState;
    [SerializeField] GameObject torch;
    private float lightIntensity;
    private void Start()
    {
        lightIntensity = torch.GetComponent<Light>().intensity;
        lightState = 1;
    }
    void Update()
    {
        torch.GetComponent<Light>().intensity = lightIntensity;
      if (Input.GetKeyDown(KeyCode.F))
        {
            lightChange();
            print(lightState);
        }
    }
   private void lightChange()
    {
        if (lightState == 0)
        {
            lightIntensity = 0;
            lightState++;
        }
        else if(lightState == 1)
        {
            lightIntensity = 2;
            lightState++;
        }
        else if (lightState == 2)
        {
            lightIntensity = 5;
            lightState = 0;
        }

    }
}
