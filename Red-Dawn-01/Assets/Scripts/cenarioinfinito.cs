using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenarioinfinito : MonoBehaviour 
{
  private Renderer myRenderer;
  private Material myMaterial;

  private float offSet;

  public float increase;
  public float speed;

  public string sortingLayer;
  public int sortingOrder;

    void Start() 
    {
        myRenderer = GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;
        myRenderer.sortingLayerName = sortingLayer;
        myRenderer.sortingOrder = sortingOrder;
    }

    private void FixedUpdate()
    {
        offSet += increase;
        myMaterial.SetTextureOffset("_MainTex", new Vector2((offSet * speed) / 1000, 0));
    }
}
