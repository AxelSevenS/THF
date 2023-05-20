using UnityEngine;
using UnityEngine.UI;

using SevenGame.Utility;


public class ScoreEffect : MonoBehaviour
{

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Graphic visual;
    [SerializeField] private float lifeTime = 1f;

    private float startTime = 0;



    private void Awake()
    {
        startTime = Time.unscaledTime;
    }

    private void Update()
    {
        float lifeTime = Time.unscaledTime - startTime;

        if (lifeTime > this.lifeTime)
            Destroy(gameObject);

        float curveValue = lifeTime / this.lifeTime;
        transform.position += Vector3.up * curve.Evaluate(curveValue) * 50f * GameUtility.timeUnscaledDelta;
        visual.color = new Color(visual.color.r, visual.color.g, visual.color.b, 1 - curveValue);
    }
}
