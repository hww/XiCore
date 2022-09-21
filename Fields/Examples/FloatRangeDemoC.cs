using UnityEngine;

namespace XiCore.Fields.Behaviours
{
	public class FloatRangeDemoC : MonoBehaviour
	{
		[Range(-10,10)]
		public RandomFloat RandomValue = new RandomFloat();
	}
}
