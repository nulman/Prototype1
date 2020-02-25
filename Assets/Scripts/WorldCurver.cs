using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	[Range(-0.1f, 0.1f)]
	public float curveStrength = 0.01f;

    int m_CurveStrengthID;
	int m_CurvePower;
	int m_Direction;
	int m_x;
	int m_y;
	float x;
	float y;
	int direciton;
	float prevTime;
    private Globals globals;
    float temp;

    private void OnEnable()
    {
        m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
		// m_CurvePower = Shader.PropertyToID("_CurvePower");
		m_y = Shader.PropertyToID("_y");
		m_x = Shader.PropertyToID("_x");
		m_Direction = Shader.PropertyToID("_Direction");
		Shader.SetGlobalFloat(m_Direction, 1);
		// Shader.SetGlobalFloat(m_CurvePower, 0.0f);
		Shader.SetGlobalFloat(m_x, 0.0f);
		Shader.SetGlobalFloat(m_y, 0.0f);
		prevTime = Time.fixedTime;
		globals = Globals.GetGlobals();
    }

	void Update()
	{
		// print(Time.fixedTime);
		// if(Time.fixedTime % 5 == 0){
		// 	direciton = (int)Random.Range(-1f, 1f);
		// 	Shader.SetGlobalFloat(m_Direction, direciton);
		// 	print("changing direction to: " + direciton);
		// 	temp = Random.Range(-1f, 1f);
		// 	x = Shader.GetGlobalFloat(m_x);
		// 	x += temp*0.001f;
		// 	if(x > 1f) x=1f;
		// 	if(x < -1f) x=-1f;
		// 	Shader.SetGlobalFloat(m_x, x);
		// 	temp = Random.Range(-1f, 1f);
		// 	y = Shader.GetGlobalFloat(m_y);
		// 	y += temp*0.001f;
		// 	if(y > 1f) y=1f;
		// 	if(y < -1f) y=-1f;
		// 	Shader.SetGlobalFloat(m_y, y);
		// }
		x = Shader.GetGlobalFloat(m_x);
		x = x + (globals.direction.x - x)*0.0035f;
		x = x > 1f ? 1f : x;
		x = x < -1f ? -1f : x;
		Shader.SetGlobalFloat(m_x, x);
		y = Shader.GetGlobalFloat(m_y);
		y = y + (globals.direction.y - y)*0.0035f;
		y = y > 1f ? 1f : y;
		y = y < -1f ? -1f : y;
		Shader.SetGlobalFloat(m_y, y);
		Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
	}
}
