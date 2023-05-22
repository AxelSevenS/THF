using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

using UnityEngine.EventSystems;

using System.Linq;

public sealed class SliceManager : Singleton<SliceManager>, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static List<Sliceable> sliceables = new List<Sliceable>();

    [SerializeField] private Camera camera;

    public float maxSliceDistance = 10f;
    public float minSliceDistance = 0.5f;

    [SerializeField] private GameObject slicePrefab;
    [SerializeField] private LayerMask sliceLayerMask;

    [SerializeField] private TrailRenderer sliceEffect;
    [SerializeField] private float sliceLength;
    [SerializeField] private AudioClip sliceSound;



    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create the Trail Renderer Object at the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        mousePos.z = -1f;

        GameObject sliceEffectGO = GameObject.Instantiate(slicePrefab, mousePos, Quaternion.identity);
        sliceEffect = sliceEffectGO.GetComponent<TrailRenderer>();

        sliceLength = 0f;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (sliceEffect == null)
            return;

        Vector3 initialPos = camera.ScreenToWorldPoint(eventData.position - eventData.delta);
        Vector3 currentPos = camera.ScreenToWorldPoint(eventData.position);
        initialPos.z = -1f;
        currentPos.z = -1f;

        Vector3 direction = currentPos - initialPos;

        sliceLength += direction.magnitude;
        sliceEffect.transform.position = currentPos;


        if (sliceLength < minSliceDistance)
            return;

        if (sliceLength > maxSliceDistance)
        {
            OnEndDrag(eventData);
            return;
        }


        float radius = .25f;
        Vector3 origin = sliceEffect.transform.position + direction.normalized * Mathf.Min(radius, direction.magnitude);
        Vector3 end = sliceEffect.transform.position - direction.normalized * Mathf.Min(radius, direction.magnitude);

        var overlaps = Physics.OverlapCapsule(origin, end, radius, sliceLayerMask, QueryTriggerInteraction.Collide);
        foreach (var sliceable in overlaps)
        {
            sliceable.GetComponent<Sliceable>()?.Slice();
        }

        // if (sliceLength > maxSliceDistance)
        //     OnEndDrag(eventData);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sliceEffect = null;
        sliceLength = 0f;
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
