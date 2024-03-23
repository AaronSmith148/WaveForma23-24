using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioController_GalaxyCorners : MonoBehaviour
{
    [Header("VFX Emitter Assignments")]
    [SerializeField]
    private VisualEffect galaxyCenter;
    [SerializeField]
    private VisualEffect galaxyTR;
    [SerializeField]
    private VisualEffect galaxyTL;
    [SerializeField]
    private VisualEffect galaxyBR;
    [SerializeField]
    private VisualEffect galaxyBL;

    [Header("Center Paramaters")]
    [SerializeField] float _RateCenter = 1500f;
    public float RateCenter
    {
        get => _RateCenter;
        set => _RateCenter = value;
    }
    [SerializeField] float _IntensityCenter = 0.005f;
    public float IntensityCenter
    {
        get => _IntensityCenter;
        set => _IntensityCenter = value;
    }
    [SerializeField] Vector3 _ForceCenter = new Vector3(0, 0, 0);
    public Vector3 ForceCenter
    {
        get => _ForceCenter;
        set => _ForceCenter = value;
    }
    [Header("Top Right Paramaters")]
    [SerializeField] float _RateTR = 1500f;
    public float RateTR
    {
        get => _RateTR;
        set => _RateTR = value;
    }
    [SerializeField] float _IntensityTR = 0.005f;
    public float IntensityTR
    {
        get => _IntensityTR;
        set => _IntensityTR = value;
    }
    [SerializeField] Vector3 _ForceTR = new Vector3(0, 0, 0);
    public Vector3 ForceTR
    {
        get => _ForceTR;
        set => _ForceTR = value;
    }
    [Header("Top Left Paramaters")]
    [SerializeField] float _RateTL = 1500f;
    public float RateTL
    {
        get => _RateTL;
        set => _RateTL = value;
    }
    [SerializeField] float _IntensityTL = 0.005f;
    public float IntensityTL
    {
        get => _IntensityTL;
        set => _IntensityTL = value;
    }
    [SerializeField] Vector3 _ForceTL = new Vector3(0, 0, 0);
    public Vector3 ForceTL
    {
        get => _ForceTL;
        set => _ForceTL = value;
    }
    [Header("Bottom Right Paramaters")]
    [SerializeField] float _RateBR = 1500f;
    public float RateBR
    {
        get => _RateBR;
        set => _RateBR = value;
    }
    [SerializeField] float _IntensityBR = 0.005f;
    public float IntensityBR
    {
        get => _IntensityBR;
        set => _IntensityBR = value;
    }
    [SerializeField] Vector3 _ForceBR = new Vector3(0, 0, 0);
    public Vector3 ForceBR
    {
        get => _ForceBR;
        set => _ForceBR = value;
    }
    [Header("Bottom Left Paramaters")]
    [SerializeField] float _RateBL = 1500f;
    public float RateBL
    {
        get => _RateBL;
        set => _RateBL = value;
    }
    [SerializeField] float _IntensityBL = 0.005f;
    public float IntensityBL
    {
        get => _IntensityBL;
        set => _IntensityBL = value;
    }
    [SerializeField] Vector3 _ForceBL = new Vector3(0, 0, 0);
    public Vector3 ForceBL
    {
        get => _ForceBL;
        set => _ForceBL = value;
    }
    // Update is called once per frame
    void Update()
    {
        SetCenter();
        SetTR();
        SetTL();
        SetBR();
        SetBL();
    }
    private void SetCenter()
    {
        galaxyCenter.SetFloat("Rate", _RateCenter);
        galaxyCenter.SetFloat("Intensity", _IntensityCenter);
        galaxyCenter.SetVector3("Force", _ForceCenter);
    }
    private void SetTR()
    {
        galaxyTR.SetFloat("Rate", _RateTR);
        galaxyTR.SetFloat("Intensity", _IntensityTR);
        galaxyTR.SetVector3("Force", _ForceTR);
    }
    private void SetTL()
    {
        galaxyTL.SetFloat("Rate", _RateTL);
        galaxyTL.SetFloat("Intensity", _IntensityTL);
        galaxyTL.SetVector3("Force", _ForceTL);
    }
    private void SetBR()
    {
        galaxyBR.SetFloat("Rate", _RateBR);
        galaxyBR.SetFloat("Intensity", _IntensityBR);
        galaxyBR.SetVector3("Force", _ForceBR);
    }
    private void SetBL()
    {
        galaxyBL.SetFloat("Rate", _RateBL);
        galaxyBL.SetFloat("Intensity", _IntensityBL);
        galaxyBL.SetVector3("Force", _ForceBL);
    }
}
