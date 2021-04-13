using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    private GameManager _GameManager;
    public bool isRain;
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           _GameManager.OnOffRain(false);
        }
    }
}
