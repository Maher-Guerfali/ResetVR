using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class slliceobject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public Material crossSectionMat;
    public LayerMask sliceableLayer;
    public float forcecut = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hashit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if(hashit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }
    public void Slice (GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal); ;
        if(hull != null)
        {
            GameObject upperhull = hull.CreateUpperHull(target,crossSectionMat);
            SetupSlicedCompoent(upperhull);
            GameObject lowerhull = hull.CreateLowerHull(target, crossSectionMat);
            SetupSlicedCompoent(lowerhull);
            Destroy(target);
        }
    }
    public void SetupSlicedCompoent (GameObject sliceobject)
    {
        Rigidbody rb = sliceobject.AddComponent<Rigidbody>();
        MeshCollider collider = sliceobject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(forcecut, sliceobject.transform.position, 1);
    }
}
