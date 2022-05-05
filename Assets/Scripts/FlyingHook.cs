using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHook : MonoBehaviour
{
    [SerializeField] const float MOVE_SPEED = 4f;
    [SerializeField] const float ATTACH_DISTANCE =2f;
    MeshRenderer m_DetectedObject;
    ConfigurableJoint m_JointForObject;
    [SerializeField] LineRenderer m_Cable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_JointForObject == null)
        {
            DetectObjects();
        }

        //else { UpdateCable(); }


        if (Input.GetKeyDown (KeyCode.Space))
        {
            AttachOrDetachObject();
        }

        
    }

    void DetectObjects ()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit; // A RaycastHit to store the raycast result


       
        if (m_JointForObject != null)
        {
            return;
        }

        if (Physics.Raycast(ray, out hit, ATTACH_DISTANCE))
        {
            if (m_DetectedObject != null && m_DetectedObject == hit.collider.gameObject.GetComponent<MeshRenderer>())
            {
                return;
                
            }

            RecoverDetectObject();

            MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderer.material.color = Color.yellow;
                m_DetectedObject = renderer;
            }
        }
        else
        {
            RecoverDetectObject();
        }
    }

    void RecoverDetectObject()
    {
        if (m_DetectedObject != null)
        {
            m_DetectedObject.material.color = Color.white;
            m_DetectedObject = null;
        }
    }

    void AttachOrDetachObject()
    {


        if (m_JointForObject == null)
        {
  
            if (m_DetectedObject != null)
            {
                
                var joint = this.gameObject.AddComponent <ConfigurableJoint> ();
                Debug.Log("1");
                joint.xMotion = ConfigurableJointMotion.Limited;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Limited;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;

                var limit = joint.linearLimit;
                limit.limit = 0.5f;

                joint.linearLimit = limit;

                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = new Vector3(0f, 1.5f, 0f);
                joint.anchor = new Vector3(0f, 0f, 0f);

                joint.connectedBody = m_DetectedObject.gameObject.GetComponent<Rigidbody>();

                m_JointForObject = joint;
                

                m_DetectedObject.material.color = Color.red;
            }
        }
        else
        {
            GameObject.Destroy(m_JointForObject);
            m_JointForObject = null;
            m_DetectedObject.material.color = Color.white;
            m_DetectedObject = null; 
        }
    }

    //void UpdateCable()
    //{
    //    m_Cable.enabled = m_JointForObject.connectedBody != null;

    //    if (m_Cable.enabled)
    //    {
    //        m_Cable.SetPosition (0, this.transform.position);

    //        var connectedBodyTransform = m_JointForObject.connectedBody.transform;
    //        m_Cable.SetPosition(1, connectedBodyTransform.TransformPoint(m_JointForObject.connectedAnchor));
    //    }
    //}
}
