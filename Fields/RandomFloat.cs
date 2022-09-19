namespace XiCore.Fields
{
    /// <summary>
    /// Makes field with two values minimum and maxmum.
    /// Produce random value in this range.
    /// </summary>
    [System.Serializable]
    public struct RandomFloat
    {
        public float min; // The minimum value in this range.
        public float max; // The maximum value in this range.

        // Constructor to set the values.
        public RandomFloat(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        // Get a random value from the range.
        public float Random
        {
            get { return UnityEngine.Random.Range(min, max); }
        }
    }

}
