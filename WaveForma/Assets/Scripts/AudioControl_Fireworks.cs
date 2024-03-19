using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioControl_Fireworks : MonoBehaviour
{
    [SerializeField]
    private VisualEffect fireworks;
    [SerializeField] float _SpawnRate = 5f;
    public float SpawnRate
    {
        get => _SpawnRate;
        set => _SpawnRate = value;
    }

    [ColorUsage(true, true)]
    [SerializeField] Color _RocketColor = Color.white;
    public Color RocketColor
    {
        get => _RocketColor;
        set => _RocketColor = value;
    }

    [Header("Gradient Controls")]
    public Gradient explosionGradient;
    [ColorUsage(true, true)]
    public Color explosionColor1;
    [ColorUsage(true, true)]
    public Color explosionColor2;
    [ColorUsage(true, true)]
    public Color explosionColor3;

    public GradientColorKey[] colors = new GradientColorKey[3];
    private GradientAlphaKey[] alphas = new GradientAlphaKey[2];

    // Start is called before the first frame update
    void Start()
    {
        

        colors[0] = new GradientColorKey(explosionColor1, 0.0f);
        colors[1] = new GradientColorKey(explosionColor2, 0.5f);
        colors[2] = new GradientColorKey(explosionColor3, 1.0f);

        
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);

        explosionGradient.SetKeys(colors, alphas);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGradient();
        
        fireworks.SetFloat("Rate", _SpawnRate);
        fireworks.SetVector4("RocketColor", _RocketColor);
        fireworks.SetGradient("ExplosionGradient", explosionGradient);
    }

    private void UpdateGradient()
    {
        colors[0] = new GradientColorKey(explosionColor1, 0.0f);
        colors[1] = new GradientColorKey(explosionColor2, 0.5f);
        colors[2] = new GradientColorKey(explosionColor3, 1.0f);
        explosionGradient.SetKeys(colors, alphas);
    }
}
