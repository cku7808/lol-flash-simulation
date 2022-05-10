using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 점멸1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z - 1.5f));
            print("target:" + target);
            if ((transform.position - target).magnitude <= 10)
            {
                //target = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, -Camera.main.transform.position.z - 1.5f));

                //print((transform.position - target).magnitude);
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);

            }
            else
            {
                //print((transform.position - target).magnitude);
                Vector3 tmp = (target - transform.position).normalized + Vector3.forward * 10;
                print("tmp:"+tmp);

                tmp = Camera.main.ScreenToWorldPoint(new Vector3(tmp.x, tmp.y, -Camera.main.transform.position.z - 1.5f));
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10);
            }
        }
    }
}
