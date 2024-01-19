using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //LinklenecekPortal
    public Portal linkedPortal;
    //Kendi ekranı
    public MeshRenderer screen;

    private Camera playerCam;
    private Camera portalCam;

    private RenderTexture viewTexture;

    void Awake()
    {
        playerCam = Camera.main;
        portalCam = GetComponentInChildren<Camera>();
        portalCam.enabled = false;
    }

    void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }

            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);

            portalCam.targetTexture = viewTexture;
            
            linkedPortal.screen.material.SetTexture("_MainTex", viewTexture);
        }
    }

    public void Render()
    {
        screen.enabled = false;
        CreateViewTexture();


        var m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix *
                playerCam.transform.localToWorldMatrix;
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
        
        portalCam.Render();

        screen.enabled = true;
    }
}
