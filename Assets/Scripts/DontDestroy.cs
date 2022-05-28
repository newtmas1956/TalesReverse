using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

public  class DontDestroy: MonoBehaviour
{
    public static DontDestroy instance { get; private set; } = null;
       
    void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
