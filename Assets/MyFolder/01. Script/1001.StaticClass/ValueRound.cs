using UnityEngine;

namespace MyFolder._01._Script._1001.StaticClass
{
    public static class ValueRound
    {
        public static int FloatToInt(float value)
        {
            if (value % 1 >= 0.5f)
            {
                return Mathf.RoundToInt(value);
            }
            else
            {
                return Mathf.FloorToInt(value);
            }
        }
    }
}