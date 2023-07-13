using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float axis = 0;
    private const int _xRange = 7;
    private  float _cameraSpeedX, _cameraSpeedY, _leftScreen, _rightScreen, _bottomScreen, _topScreen;
    public Vector2 mousePosition, hotSpot;
    private CursorMode _cursorMode;
    public Texture2D cursorTexture2D;
    public CinemachineFreeLook thirdPersonCamera;

    void Init()
    {
        _cameraSpeedX = 14 * Time.deltaTime;
        _cameraSpeedY = Time.deltaTime;
        _leftScreen = Screen.width / 10;
        _rightScreen = Screen.width - _leftScreen;
        _bottomScreen = Screen.height / 10;
        _topScreen = Screen.height - _bottomScreen;
    }

    void Start()
    {
        Init();
        _cursorMode = CursorMode.Auto;
        hotSpot = new Vector2(cursorTexture2D.height / 2, cursorTexture2D.width / 2);
        Cursor.SetCursor(cursorTexture2D, hotSpot, _cursorMode);
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        mousePosition = Input.mousePosition;
        MoveCamera();
        if(Input.GetKeyUp(KeyCode.Q))
        {
            ChangeAxis(-1);
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            ChangeAxis(1);
        }
    }

    void ChangeAxis(int sign)
    {
        if(Mathf.Abs(axis) == 180)
        {
            thirdPersonCamera.m_XAxis.Value = -90 * sign;
        }
        else
        {
            thirdPersonCamera.m_XAxis.Value = axis + sign * 90;
        }

        axis = thirdPersonCamera.m_XAxis.Value;
    }

    void MoveCamera()
    {
        if(Mathf.Abs(axis) == 180)
        {
            if(thirdPersonCamera.m_XAxis.Value > 0)
            {
                if(Input.mousePosition.x < _leftScreen)
                {
                    if(thirdPersonCamera.m_XAxis.Value -180 > 0 -_xRange)
                    {
                        thirdPersonCamera.m_XAxis.Value -= _cameraSpeedX;
                    }
                }
                else if(Input.mousePosition.x > _rightScreen)
                {
                    if(thirdPersonCamera.m_XAxis.Value -180 < 0 +_xRange)
                    {
                        thirdPersonCamera.m_XAxis.Value += _cameraSpeedX;
                    }
                }
            }
            else
            {
                if(Input.mousePosition.x < _leftScreen)
                {
                    if(thirdPersonCamera.m_XAxis.Value +180 > 0 -_xRange)
                    {
                        thirdPersonCamera.m_XAxis.Value -= _cameraSpeedX;
                    }
                }
                else if(Input.mousePosition.x > _rightScreen)
                {
                    if(thirdPersonCamera.m_XAxis.Value +180 < 0 +_xRange)
                    {
                        thirdPersonCamera.m_XAxis.Value += _cameraSpeedX;
                    }
                }
            }
        }
        else
        {
            if(Input.mousePosition.x < _leftScreen)
            {
                if(thirdPersonCamera.m_XAxis.Value > axis -_xRange)
                {
                    thirdPersonCamera.m_XAxis.Value -= _cameraSpeedX;
                }
            }
            else if(Input.mousePosition.x > _rightScreen)
            {
                if(thirdPersonCamera.m_XAxis.Value < axis +_xRange)
                {
                    thirdPersonCamera.m_XAxis.Value += _cameraSpeedX;
                }
            }
        }
        if(Input.mousePosition.y < _bottomScreen)
        {
            if(thirdPersonCamera.m_YAxis.Value > 0)
            {
                thirdPersonCamera.m_YAxis.Value -= _cameraSpeedY;
            }
        }
        else if(Input.mousePosition.y > _topScreen)
        {
            if(thirdPersonCamera.m_YAxis.Value < 1)
            {
                thirdPersonCamera.m_YAxis.Value += _cameraSpeedY;
            }
        }
    }
}
