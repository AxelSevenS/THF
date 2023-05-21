using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

public abstract class Sliceable : MonoBehaviour
{
    
    [SerializeField] private AudioClip sliceSound;
    [SerializeField] private float pitchRange = 0.1f;
    
    [SerializeField] private GameObject sliceEffect;
    [SerializeField] private float sliceEffectDuration = 5f;

    public void Slice() {

        if ( !enabled )
            return;

        SliceBehaviour();

        // AudioSource.PlayClipAtPoint doesn't allow for pitch changes
        // so we have to create a temporary game object with an audio source
        // this is better than setting up the component on the object itself
        if (sliceSound != null) {

            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = transform.position;
            AudioSource audioSource = tempGO.AddComponent<AudioSource>();
            audioSource.clip = sliceSound;
            audioSource.pitch = Random.Range(1f - pitchRange, 1f + pitchRange);
            audioSource.Play();

            Destroy(tempGO, sliceSound.length);
        }

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
