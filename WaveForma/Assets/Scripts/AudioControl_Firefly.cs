using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioControl_Firefly : MonoBehaviour
{
    [SerializeField]
    private VisualEffect firefly;

    [SerializeField] float _EndLifetime = 3f;
    public float EndLifetime
    {
        get => _EndLifetime;
        set => _EndLifetime = value;
    }
    [SerializeField] float _SpawnRate = 25f;
    public float SpawnRate
    {
        get => _SpawnRate;
        set => _SpawnRate = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        firefly.SetFloat("LifeTimeEnd", _EndLifetime);
        firefly.SetFloat("SpawnRate", _SpawnRate);
    }
}
