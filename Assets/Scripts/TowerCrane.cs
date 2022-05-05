using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCrane : MonoBehaviour
{
    [SerializeField] const float ROTATION_SPEED = 6f; // for rotation of the jib
    [SerializeField] const float MOVE_SPEED = 1; // for moving of the trolley
    [SerializeField] const float CRANE_SOEED = 1f; // for lifting and lower of the hook


    [SerializeField] GameObject m_Jib;
    [SerializeField] GameObject m_Trolley;
    [SerializeField] ConfigurableJoint m_Joint;
    //[SerializeField] GameObject m_Hook;
    [SerializeField] LineRenderer m_Cable;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Jib.transform.Rotate(0, 0, -ROTATION_SPEED * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Jib.transform.Rotate(0, 0, +ROTATION_SPEED * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && m_Trolley.transform.localPosition.y > -16f)
        {
            m_Trolley.transform.Translate(0, -MOVE_SPEED * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && m_Trolley.transform.localPosition.y < 0f)
        {
            m_Trolley.transform.Translate(0, MOVE_SPEED * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //var joint = m_Trolley.gameObject.GetComponent<ConfigurableJoint>();
            var limit = m_Joint.linearLimit;
            if (limit.limit >= 1f)
            {
                limit.limit -= CRANE_SOEED * Time.deltaTime;
                m_Joint.linearLimit = limit;
            }

        }
        else if (Input.GetKey(KeyCode.E))
        {
            //var joint = m_Trolley.gameObject.GetComponent<ConfigurableJoint>();
            var limit = m_Joint.linearLimit;
            if (limit.limit <= 20f)
            {
                limit.limit += CRANE_SOEED * Time.deltaTime;
                m_Joint.linearLimit = limit;
            }
        }

        UpdateCable();
    }

    void UpdateCable()
    {
        m_Cable.SetPosition(0, m_Trolley.transform.position);
        var connectedBodyTransform = m_Joint.connectedBody.transform;
        m_Cable.SetPosition(1, connectedBodyTransform.TransformPoint(m_Joint.connectedAnchor));
    }

    void SelfDestruct()
    {
    Destroy(this.gameObject);
    
    }


}
