using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

using UnityEngine.EventSystems;

public sealed class SliceManager : Singleton<SliceManager>, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private GameObject slicePrefab;
    [SerializeField] private LayerMask sliceLayerMask;
    
    private TrailRenderer sliceEffect;
    private AudioClip sliceSound;



    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create the Trail Renderer Object at the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;

        GameObject sliceEffectGO = GameObject.Instantiate(slicePrefab, mousePos, Quaternion.identity);
        sliceEffect = sliceEffectGO.GetComponent<TrailRenderer>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        // Add a new point to the trail renderer
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;

        Vector3 direction = mousePos - sliceEffect.transform.position;

        if ( Physics.SphereCast(sliceEffect.transform.position, 1f, direction, out RaycastHit hit, direction.magnitude, sliceLayerMask) ) 
        {
            Sliceable sliceable = hit.collider.GetComponent<Sliceable>();
            sliceable?.Slice();
        }

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

    private void OnEnable()
    {
        SetCurrent();
    }
}
