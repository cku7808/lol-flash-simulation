using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 이동 : MonoBehaviour
{
    Vector3 target = new Vector3(0,0,-1.5f);
    RaycastHit hit;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            getPosition();
        }
        if (flag){
            moving();
        }
    }
    void getPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            target = new Vector3(hit.point.x, hit.point.y, -1.5f);
            flag = true;
        }
    }
    void moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
        if (transform.position == target)
        {
            flag = false;
        }
    }
}
