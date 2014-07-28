﻿//
// Reaktion - An audio reactive animation toolkit for Unity.
//
// Copyright (C) 2013, 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Reaktion {

[CustomEditor(typeof(CameraGear)), CanEditMultipleObjects]
public class CameraGearEditor : Editor
{
    SerializedProperty propAutoBind;
    SerializedProperty propReaktor;

    SerializedProperty propFieldOfView;
    SerializedProperty propViewportWidth;
    SerializedProperty propViewportHeight;

    void OnEnable()
    {
        propAutoBind = serializedObject.FindProperty("autoBind");
        propReaktor  = serializedObject.FindProperty("reaktor");

        propFieldOfView    = serializedObject.FindProperty("fieldOfView");
        propViewportWidth  = serializedObject.FindProperty("viewportWidth");
        propViewportHeight = serializedObject.FindProperty("viewportHeight");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(propAutoBind);

        if (propAutoBind.hasMultipleDifferentValues || !propAutoBind.boolValue)
            EditorGUILayout.PropertyField(propReaktor);

        EditorGUILayout.PropertyField(propFieldOfView);
        EditorGUILayout.PropertyField(propViewportWidth);
        EditorGUILayout.PropertyField(propViewportHeight);

        serializedObject.ApplyModifiedProperties();
    }
}

} // namespace Reaktion