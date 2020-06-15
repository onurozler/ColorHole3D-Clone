using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    public static class OnurExtensionMethods
    {
        public static void SafeInvoke(this Action source)
        {
            if (source != null) source.Invoke();
        }

        public static void SafeInvoke<T>(this Action<T> source, T value)
        {
            if (source != null) source.Invoke(value);
        }
        
        public static void SafeInvoke<T1, T2>(this Action<T1, T2> source, T1 firstValue, T2 secondValue)
        {
            if (source != null) source.Invoke(firstValue, secondValue);
        }
        
        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> source, T1 firstValue, T2 secondValue, T3 thirdValue)
        {
            if (source != null) source.Invoke(firstValue, secondValue, thirdValue);
        }

        public static Vector3 ScaleMultiplier(this Vector3 vector3, float multiplier)
        {
            var newVector = vector3;
            newVector.x *= multiplier;
            newVector.y *= multiplier;
            newVector.z *= multiplier;
            
            return newVector;
        }

        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable  
        {  
            return listToClone.Select(item => (T)item.Clone()).ToList();  
        }

        public static T GetRandomElementFromList<T>(this List<T> list)
        {
            int random = Random.Range(0, list.Count);
            return list[random];
        }
        
        public static T GetRandomElementFromList<T>(this List<T> list, T exclude)
        {
            int random = Random.Range(0, list.Count);
            while (Equals(list[random], exclude))
            {
                random = Random.Range(0, list.Count);
            }

            return list[random];
        }

        public static List<Transform> GetAllChilds(this Transform thisTransform)
        {
            return thisTransform.Cast<Transform>().ToList();
        }
        
    }
}
