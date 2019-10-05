using UnityEngine;
public class DemoScaler : MonoBehaviour
{
    public int bandIndex = 0;
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, AudioSpecterSampler.frequencyBand[bandIndex] + 2, 0);
    }
}
