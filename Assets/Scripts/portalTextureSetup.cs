using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTextureSetup : MonoBehaviour
{

    public Camera cameraSag;
    public Material cameraSagMat;
    
    public Camera cameraSol;
    public Material cameraSolMat;
    void Start()
    {
        if (cameraSag.targetTexture != null)
        {
            cameraSag.targetTexture.Release();
        }

        cameraSag.targetTexture = new RenderTexture(Screen.width, Screen.height,24);
        cameraSagMat.mainTexture = cameraSag.targetTexture;
        
        if (cameraSol.targetTexture != null)
        {
            cameraSol.targetTexture.Release();
        }

        cameraSol.targetTexture = new RenderTexture(Screen.width, Screen.height,24);
        cameraSolMat.mainTexture = cameraSol.targetTexture;
    }
}
