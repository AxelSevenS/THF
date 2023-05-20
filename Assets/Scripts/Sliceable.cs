using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

public abstract class Sliceable : MonoBehaviour
{
    
    [SerializeField] private AudioClip sliceSound;
    [SerializeField] private GameObject sliceEffect;
    [SerializeField] private float sliceEffectDuration = 5f;

    public void Slice() {

        if ( !enabled )
            return;

        SliceBehaviour();

        if (sliceSound != null)
            AudioSource.PlayClipAtPoint(sliceSound, transform.position);

        if (sliceEffect != null)
        {
            GameObject sliceEffectInstance = Instantiate(sliceEffect, transform.position, Quaternion.identity);
            Destroy(sliceEffectInstance, sliceEffectDuration);
        }

        Destroy(gameObject);
    }

    public void Destroy() {
        DestroyBehaviour();

        GameUtility.SafeDestroy(gameObject);
    }

    
    public abstract void SliceBehaviour();

    public abstract void DestroyBehaviour();


    protected virtual void OnEnable() {
        SliceManager.sliceables.Add(this);
    }

    protected virtual void OnDisable() {
        SliceManager.sliceables.Remove(this);
    }

}
