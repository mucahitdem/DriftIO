using UnityEngine;

namespace Scripts.GameScripts
{
    public static class GetGivenPointAtWhichDirection
    {
        public static Way DirectionOfPoint(Vector3 a, Vector3 b, Vector3 p)
        {
            // subtracting co-ordinates of point A 
            // from B and P, to make A as origin
            b.x -= a.x;
            b.z -= a.z;
            p.x -= a.x;
            p.z -= a.z;

            // Determining cross Product
            float crossProduct = b.x * p.z - b.z * p.x;

            if (crossProduct > 0) //right
                return Way.Right;
            else if (crossProduct < 0) //left
                return Way.Left;
            
            return Way.Zero;
        }
    }
    
    public enum Way
    {
        Right,
        Left,
        Zero
    }
}