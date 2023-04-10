using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Vector3 startPosition_;
    // Start is called before the first frame update
    void Start()
    {
        startPosition_ = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z <= -35)
        {
            this.transform.position = startPosition_;
            GetComponent<Rigidbody>().Sleep();
        }
    }


    private void FixedUpdate()
    {
       GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, GameManager.Instance.Gravity * Time.deltaTime));
    }
}
