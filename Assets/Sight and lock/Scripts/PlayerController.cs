using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public Vector2 mousePosition, hotSpot;
    public float mousePositionX, mousePositionY;
    private CursorMode cursorMode;
    public Texture2D cursorT2D;
    public CinemachineFreeLook thirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        // cursorMode = CursorMode.Auto;
        // hotSpot = new Vector2(cursorT2D.height / 2, cursorT2D.width / 2);
        // Cursor.SetCursor(cursorT2D, hotSpot, cursorMode);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.x = Mathf.Clamp(mousePosition.x, Screen.width * 0.05f, Screen.width - Screen.width * 0.05f);
        mousePosition.y = Mathf.Clamp(mousePosition.y, Screen.height / 2, Screen.height - Screen.height / 10);

        hotSpot = new Vector2(cursorT2D.height / 2, cursorT2D.width / 2);
        Cursor.SetCursor(cursorT2D, hotSpot, cursorMode);

        mousePositionX = mousePosition.x / Screen.width;
        mousePositionY = mousePosition.y / Screen.height;
        thirdPersonCamera.m_YAxis.Value = (mousePositionY - 0.5f) * 2 / 0.8f;
        thirdPersonCamera.m_XAxis.Value = ((mousePositionX - 0.5f) * 2 / 0.9f) * 27;
    }

    void OnGUI()
    {
        // mousePosition = Input.mousePosition;
        // mousePosition.x = Mathf.Clamp(mousePosition.x, Screen.width * 0.05f, Screen.width - Screen.width * 0.05f);
        // mousePosition.y = Mathf.Clamp(mousePosition.y, Screen.height / 2, Screen.height - Screen.height / 10);

        GUI.DrawTexture(new Rect( mousePosition.x - (cursorT2D.width/2),
                        Screen.height - mousePosition.y - (cursorT2D.height/2),
                        cursorT2D.width,
                        cursorT2D.height), cursorT2D);
    }
}
