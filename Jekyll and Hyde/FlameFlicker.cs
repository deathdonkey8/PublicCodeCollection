using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFlicker : MonoBehaviour
{
    public int FlickerSpeed;
    public float DivisionAmount;
    public bool RangeFlicker;
    public bool IntensityFlicker;
    private Light Flame;
    private float startRange;
    private float startIntensity;
    private bool RangeBot = false;
    private float rangeDip;
    private bool IntensityBot = false;
    private float intensityValue;
    private float intensityDip;
    private float rangeValue;
    // Start is called before the first frame update
    void Start()
    {
        Flame = gameObject.GetComponent<Light>();
        startRange = Flame.range;
        startIntensity = Flame.intensity;
        intensityDip = startIntensity - DivisionAmount;
        rangeDip = startRange - DivisionAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(RangeFlicker == true)
        {
            if(RangeBot != true)
            {
                rangeValue = Mathf.Lerp(Flame.range, rangeDip, 0.002f * FlickerSpeed);
            }
            if (RangeBot == true)
            {
                rangeValue = Mathf.Lerp(Flame.range, startRange, 0.002f * FlickerSpeed);
            }
        }
        if(IntensityFlicker == true)
        {
            if(IntensityBot != true)
            {
                //intensityValue = Mathf.Lerp(startIntensity, startIntensity - DivisionAmount, 0.002f * FlickerSpeed);
                intensityValue = Mathf.Lerp(Flame.intensity, intensityDip, 0.002f * FlickerSpeed);
                Debug.Log(intensityValue);
            }
            if (IntensityBot == true)
            {
                intensityValue = Mathf.Lerp(Flame.intensity, startIntensity, 0.002f * FlickerSpeed);
            }
        }

        if(Flame.range < rangeDip + 0.002f)
        {
            Flame.range = rangeDip;
            RangeBot = true;
        }
        else if (Flame.range > startRange - 0.0001f)
        {
            RangeBot = false;
        }

        if(Flame.intensity < intensityDip + 0.002f)
        {
            Flame.intensity = intensityDip;
            IntensityBot = true;
        }
        else if (Flame.intensity > startIntensity - 0.0001f)
        {
            IntensityBot = false;
        }
    }

    void LateUpdate()
    {
        Flame.intensity = intensityValue;
        Flame.range = startRange;//rangeValue;
    }
}
