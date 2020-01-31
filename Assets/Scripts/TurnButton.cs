using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{
    public bool m_IsLeftType = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.sInstance != null)
        {
            if (m_IsLeftType)
            {
                GameManager.sInstance.TurnLeft();
            }
            else
            {
                GameManager.sInstance.TurnRight();
            }
            Debug.Log("click on arrow");
        }
    }
}
