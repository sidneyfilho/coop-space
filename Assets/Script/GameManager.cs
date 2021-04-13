using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Rain manager")]
    public ParticleSystem rainParticle;
    public ParticleSystem.EmissionModule emissionModule;


    // Start is called before the first frame update
    void Start()
    {
        emissionModule = rainParticle.emission;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RainManager(bool isRain)
    {
        float total = emissionModule.rateOverTime.constant;
        if(rainParticle.isStopped)
        {
            rainParticle.Play();
            for (float r = total; r <= 40f; r += 5f)
            {
                emissionModule.rateOverTime = r;
                yield return new WaitForSeconds(3f);
            }
        } 
        else 
        {
            for (float r = total; r > 0f; r -= 5f)
            {
                emissionModule.rateOverTime = r;
                yield return new WaitForSeconds(3f);
            }
            rainParticle.Stop();
        }
    }

    public void OnOffRain(bool isRain)
    {
        StartCoroutine("RainManager", isRain);
    }
}
