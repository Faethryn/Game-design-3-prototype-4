using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowMouse : MonoBehaviour
{
    public RectTransform MovingObject;
    public Vector3 offset;
    public RectTransform basisObject;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Input.mousePosition + offset;
            pos.z = basisObject.position.z;
            MovingObject.position = cam.ScreenToWorldPoint(pos);
            this.GetComponent<Player>().UpdateTransform();
        }
    }
}
