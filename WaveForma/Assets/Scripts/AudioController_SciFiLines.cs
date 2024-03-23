using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioController_SciFiLines : MonoBehaviour
{
    [SerializeField]
    private VisualEffect linesEmitter;

    [SerializeField] float _Fewquencey = 10f;
    public float Fewquencey
    {
        get => _Fewquencey;
        set => _Fewquencey = value;
    }
    [SerializeField] float _Velocity = 1.5f;
    public float Velocity
    {
        get => _Velocity;
        set => _Velocity = value;
    }
    [SerializeField] float _LineCount = 4f;
    public float LineCount
    {
        get => _LineCount;
        set => _LineCount = value;
    }
    [SerializeField] float _Lifetime = 1f;
    public float Lifetime
    {
        get => _Lifetime;
        set => _Lifetime = value;
    }

    // Update is called once per frame
    void Update()
    {
        linesEmitter.SetFloat("Fewquencey", _Fewquencey);
        linesEmitter.SetFloat("Velocity", _Velocity);
        linesEmitter.SetFloat("Line Count", _LineCount);
        linesEmitter.SetFloat("Lifetime", _Lifetime);
    }
}
