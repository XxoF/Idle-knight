using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(0, 10f)]
    public float scrollSpeed = 0.2f;
    private Vector2 _savedOffset;
    [SerializeField]
    private Renderer _renderer;

    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    

    private void Update()
    {
        /*
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, _savedOffset.y);
        _renderer.material.SetVector("_ScrollSpeed", offset);
        */
        
        float offset = Time.time * scrollSpeed / 10f;
        _renderer.material.SetTextureOffset("_MainTex", Vector2.right * offset);
    }

}
