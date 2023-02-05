using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class LookingDirectionComponent : MonoBehaviour
{
    [Header("Components")]
    private CinemachineVirtualCamera _virtualCamera;

    [Header("Camera Variables")]
    [SerializeField] private float _cameraOffset = 7.5f;
    [SerializeField] private float _smoothFactor = 3f;
    private float _currentCameraOffset = 7.5f;

    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        CinemachineFramingTransposer transposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        transposer.m_TrackedObjectOffset = Vector3.Lerp(transposer.m_TrackedObjectOffset, new Vector3(ObtainXOffset(context.ReadValue<Vector2>().x), transposer.m_TrackedObjectOffset.y, 0), _smoothFactor * Time.deltaTime);
    }

    private float ObtainXOffset(float xInput)
    {
        _currentCameraOffset = xInput == 0 ? _currentCameraOffset : xInput > 0 ? _cameraOffset : -_cameraOffset;
        return _currentCameraOffset;
    }
}
