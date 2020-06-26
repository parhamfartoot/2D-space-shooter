using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManger;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameManger.instance == null)
            Instantiate(gameManger);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
