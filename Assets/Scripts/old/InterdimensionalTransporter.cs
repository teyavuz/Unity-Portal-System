using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalTransporter : MonoBehaviour
{
    public Material[] _Materials;
    
    
    void Start()
    {
        foreach (var mat in _Materials)
        {
            mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.name != "Main Camera")
        {
            return;
        }

        //outside of otherworld
        if (transform.position.z > other.transform.position.z)
        {
            Debug.Log("dışarısı");
            foreach (var mat in _Materials)
            {
                mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
            }
        }
        else
        {
            Debug.Log("içerisi");
            foreach (var mat in _Materials)
            {
                mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
            }
        }
    }

    void OnDestroy()
    {
        foreach (var mat in _Materials)
        {
            mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
        }
    }


    void Update()
    {
        
    }
}
