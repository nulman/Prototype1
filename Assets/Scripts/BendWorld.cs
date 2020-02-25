using UnityEngine;
public class BendWorld : MonoBehaviour
{
    [SerializeField] private Material curvedSurfaceMat;
    [SerializeField] private Material curvedSurfaceMat2;
    void Start()
    {
        curvedSurfaceMat.SetFloat("_BendFallOff", 2.0f);
        curvedSurfaceMat.SetFloat("_BendFallOffStr", 2.0f);
        curvedSurfaceMat2.SetFloat("_BendFallOff", 17.0f);
        curvedSurfaceMat2.SetFloat("_BendFallOffStr", 2.0f);
    }

    void Update()
    {
        curvedSurfaceMat.SetVector("_BendOrigin", transform.position);
        curvedSurfaceMat2.SetVector("_BendOrigin", transform.position);
        // curvedSurfaceMat.SetVector("_BendAmount", new Vector3(0, -0.01f, (Mathf.Sin(Time.time) * 0.03f)));
        curvedSurfaceMat.SetVector("_BendAmount", new Vector3(0, -0.0002f, 0));
        curvedSurfaceMat2.SetVector("_BendAmount", new Vector3(0, -0.0002f, 0));
    }
}
