using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class SliceManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Material sliceMaterial;
    
    private TrailRenderer sliceEffect;
    private AudioClip sliceSound;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create the Trail Renderer Object at the mouse position
        GameObject sliceEffectGO = new GameObject("SliceEffect");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;
        sliceEffectGO.transform.position = mousePos;

        // Add the Trail Renderer Component, we do this after setting the position so the trail starts at the right position.
        sliceEffect = sliceEffectGO.AddComponent<TrailRenderer>();
        sliceEffect.alignment = LineAlignment.TransformZ;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Add a new point to the trail renderer
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;
        sliceEffect.transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (sliceEffect != null)
            Destroy(sliceEffect.gameObject, 0.5f);

        sliceEffect = null;
    }

    private void AddPoint()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;
        sliceEffect?.AddPosition(mousePos);
    }
}
