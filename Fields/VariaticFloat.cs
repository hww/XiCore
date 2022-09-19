namespace XiCore.Fields
{
    /// <summary>
    /// Makes field with two values minimum and maxmum.
    /// Produce random value in this range.
    /// </summary>
    [System.Serializable]
    public struct VariaticFloat
    {
        public float value;     // The minimum value in this range.
        public float range;     // The maximum value in this range.

        // Constructor to set the values.
        public VariaticFloat(float value, float range)
        {
            this.value = value;
            this.range = range;
        }

        // Get a random value from the range.
        public float Random
        {
            get { return UnityEngine.Random.Range(value - range, value + range); }
        }
    }

}
