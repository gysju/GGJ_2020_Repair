using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    // Start is called before the first frame update

    private bool m_IsGrab = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsGrab)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = mousePos;
        }

        if (m_IsGrab 
            && Input.GetMouseButtonUp(0) 
            && !GameManager.sInstance.m_TowerIsTurning)
        {
            Debug.Log("Drop");
            m_IsGrab = false;
            GameManager.sInstance.ParentGear(this);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Grab");
            m_IsGrab = true;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
