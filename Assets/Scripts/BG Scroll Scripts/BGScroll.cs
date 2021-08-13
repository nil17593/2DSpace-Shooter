using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private float scrolling_speed=0.1f;
    private MeshRenderer meshRenderer;
    private float x_Scroll;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }  
   
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x_Scroll = Time.time * scrolling_speed;
        Vector2 offset = new Vector2(x_Scroll, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
