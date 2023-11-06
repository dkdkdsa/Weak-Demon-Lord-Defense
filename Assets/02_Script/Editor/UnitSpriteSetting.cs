using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitDataController))]
public class UnitSpriteSetting : Editor
{

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        if (GUILayout.Button("SetMat"))
        {

            var t = target as UnitDataController;
            var sp = t.GetComponentsInChildren<SpriteRenderer>();

            foreach(var c in sp )
            {

                c.material = t.rootMat;

            }

        }

    }

}
