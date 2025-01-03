using System;
using System.Globalization;
using UnityEngine;

namespace COM3D2.Highheel.Plugin.UI;

public class NumberInput
{
    private static readonly GUILayoutOption TextFieldLayout = GUILayout.Width(70f);
    private readonly GUIContent label;

    private string textFieldValue = string.Empty;

    private float value;

    public NumberInput(string label, float value = 0f)
    {
        this.label = new GUIContent(label);
        Value = value;
    }

    public float Value
    {
        get => value;
        set
        {
            this.value = value;
            textFieldValue = FormatValue(this.value);
        }
    }

    public event EventHandler<NumberInputEventArgs> InputChangeEvent;

    public void Draw()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label(label);

        var tempText = GUILayout.TextField(textFieldValue, TextFieldLayout);

        if (tempText != textFieldValue)
        {
            textFieldValue = tempText;

            if (float.TryParse(tempText, out var newValue) && !Mathf.Approximately(Value, newValue))
            {
                Value = newValue;
                InputChangeEvent?.Invoke(this, new NumberInputEventArgs(Value));
            }
        }

        GUILayout.EndHorizontal();
    }

    private static string FormatValue(float value)
    {
        return value.ToString("0.####", CultureInfo.InvariantCulture);
    }
}