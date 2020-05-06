using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music music;
    public bool Always;
    public GameObject go;
    // Start is called before the first frame update


    private void Awake()
    {
        if (music == null)
        {
            DontDestroyOnLoad(gameObject);
            music = this;
        }
        else if (music != this)
        {
            Destroy(gameObject);
        }
    }
}