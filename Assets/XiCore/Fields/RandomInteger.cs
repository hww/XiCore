namespace XiCore.Fields
{
    /// <summary>
    /// Makes field with two values minimum and maxmum.
    /// Produce random value in this range.
    /// </summary>
    [System.Serializable]
    public struct RandomInteger
    {
        public int min; // The minimum value in this range.
        public int max; // The maximum value in this range.

        // Constructor to set the values.
        public RandomInteger(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        // Get a random value from the range.
        public int Random
        {
            get { return UnityEngine.Random.Range(min, max); }
        }
    }

}
