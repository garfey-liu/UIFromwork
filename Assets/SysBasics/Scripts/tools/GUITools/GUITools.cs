using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    static public class GUITools
    {

        /// <summary>
        /// Instantiate an object and add it to the specified parent.
        /// </summary>
        static public GameObject AddChild(this GameObject parent, GameObject prefab)
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
#if UNITY_EDITOR
            UnityEditor.Undo.RegisterCreatedObjectUndo(go, "Create Object");
#endif
            if (go != null && parent != null)
            {
                Transform t = go.transform;
                t.SetParent(parent.transform);
                //t.parent = parent.transform;
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;
                go.layer = parent.layer;
                go.name = go.name.Replace("(Clone)", "");
            }
            return go;
        }
    }
}
