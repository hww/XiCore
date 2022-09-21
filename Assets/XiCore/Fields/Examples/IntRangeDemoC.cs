using UnityEngine;

namespace XiCore.Fields.Behaviours
{
	public class IntRangeDemoC : MonoBehaviour
	{
		[Range(-10,10)]
		public RandomInteger RandomValue = new RandomInteger();
	}
}
