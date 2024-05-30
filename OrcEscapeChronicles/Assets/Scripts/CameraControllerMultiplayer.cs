using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    #region Variables
    private Camera _mainCamera;
    
    [SerializeField] private List<Transform> targets;
    [SerializeField] private float edgeBuffer = 4.0f;
    [SerializeField] private float minSize = 6.0f;
    [SerializeField] private float maxSize = 18.0f;

    [SerializeField] private float smoothTime = 0.2f;
    private Vector3 _velocity;
    private float _zoomSpeed;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _mainCamera = Camera.main;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (targets.Count == 0)
        {
            Vector3 def = new Vector3(0, 0, 0);

            transform.position = def;
        }
        else
        {
            transform.position = GetAveragePosition();
        }
        _mainCamera.orthographicSize = GetDesiredSize();
    }

    private void LateUpdate()
    {
        if (targets.Count > 0)
        {
            SetPosition();
            SetSize();
        }
    }

    #endregion

    #region Setters

    private void SetPosition()
    {
        transform.position = GetAveragePosition();
    }

    private void SetSize()
    {
        _mainCamera.orthographicSize = Mathf.SmoothDamp(_mainCamera.orthographicSize, GetDesiredSize(), ref
            _zoomSpeed, smoothTime);
    }
    
    public void AddTarget(Transform target)
    {
        targets.Add(target);
    }
    #endregion

    #region Getters
    
    private Vector3 GetAveragePosition()
    {
        var averagePosition = new Vector3();

        foreach (var target in targets)
        {
            averagePosition += target.position;
        }

        averagePosition /= targets.Count;

        return averagePosition;
    }

    private float GetDesiredSize()
    {
        var size = 0.0f;
        var desiredLocalPosition = transform.InverseTransformPoint(GetAveragePosition());

        foreach (var target in targets)
        {
            var targetLocalPos = transform.InverseTransformPoint(target.position);
            var desiredPosToTarget = targetLocalPos - desiredLocalPosition;

            size = Mathf.Max(
                size,
                Mathf.Abs(desiredPosToTarget.y),
                Mathf.Abs(desiredPosToTarget.x) / _mainCamera.aspect);
        }

        return Mathf.Clamp(size + edgeBuffer, minSize, maxSize);
    }

    #endregion
    
}
