using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioControl_Galaxy : MonoBehaviour
{
    [SerializeField]
    private VisualEffect galaxy;

    [SerializeField] float _CountX = 1f;
    public float CountX
    {
        get => _CountX;
        set => _CountX = value;
    }
    [SerializeField] float _CountY = 1f;
    public float CountY
    {
        get => _CountY;
        set => _CountY = value;
    }
    [SerializeField] Vector3 _AxisX = new Vector3(0, 0, 0);
    public Vector3 AxisX
    {
        get => _AxisX;
        set => _AxisX = value;
    }
    [SerializeField] Vector3 _AxisY = new Vector3(0, 0, 0);
    public Vector3 AxisY
    {
        get => _AxisY;
        set => _AxisY = value;
    }

    [SerializeField] Vector3 _Force = new Vector3(1,0,20);
    public Vector3 Force
    {
        get => _Force;
        set => _Force = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        galaxy.SetFloat("CountX", _CountX);
        galaxy.SetFloat("CountY", _CountY);
        galaxy.SetVector3("Force", _Force);
        galaxy.SetVector3("AxisX", _AxisX);
        galaxy.SetVector3("AxisY", _AxisY);
    }
}
