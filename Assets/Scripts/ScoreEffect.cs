using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEffect : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Graphic visual;
    [SerializeField] private float lifeTime = 1f;

    private float startTime = 0;



    private void Update()
    {
        float lifeTime = Time.time - startTime;

        if (lifeTime > this.lifeTime)
            Destroy(gameObject);

        float curveValue = lifeTime / this.lifeTime;
        transform.position += Vector3.up * curve.Evaluate(curveValue) * 50f * Time.deltaTime;
        visual.color = new Color(visual.color.r, visual.color.g, visual.color.b, 1 - curveValue);
    }

    private void Awake()
    {
        startTime = Time.time;
    }
}
