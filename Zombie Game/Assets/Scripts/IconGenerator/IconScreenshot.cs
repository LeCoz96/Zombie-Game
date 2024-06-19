using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEngine;

public class IconScreenshot : MonoBehaviour
{
    private Camera _camera;

    void TakeScreenshot(string filepath)
    {
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }

        RenderTexture renderTexture = new RenderTexture(256, 256, 24);
        _camera.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        _camera.Render();
    }
}
