using UnityEngine;
public class BendSphere : MonoBehaviour
{
    [SerializeField] private Material curvedSurfaceMat;
    void Start()
    {
        curvedSurfaceMat.SetVector("_BendAmount", new Vector3(0, 0.01f, 0));
        curvedSurfaceMat.SetFloat("_BendFallOff", -9.8f);
        curvedSurfaceMat.SetFloat("_BendFallOffStr", 2.0f);
    }

    void Update()
    {
        curvedSurfaceMat.SetVector("_BendOrigin", transform.position);
    }
}
