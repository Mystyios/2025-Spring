﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Single Variables/IntData")]
public class IntData : ScriptableObject
{
    [SerializeField] private int value, minValue, maxValue;

    [FormerlySerializedAs("minValueEvent")] public UnityEvent<float> valueOutOfRange;
    [FormerlySerializedAs("updateValueEvent")] public UnityEvent onValueChanged;
    public UnityEvent isZeroEvent;
    
    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            onValueChanged.Invoke();
            CheckValueRange();
        }
    }

    public void UpdateValue(int amount)
    {
        Value += amount;
    }

    public void SetValue(IntData data)
    {
        Value = data.Value;
    }
    
    public void SetValue(int amount)
    {
        Value = amount;
    }

    private void CheckValueRange()
    {
        if (Value >= minValue && Value <= maxValue) return;
        valueOutOfRange.Invoke(Value);
        Value = Mathf.Clamp(Value, minValue, maxValue);
    }

    public void UpdateValueZeroCheck(int i)
    {
        if (Value + i < 0) return;
        Value += i;
    }

    public void IsZero()
    {
        if (Value <= 0)
        {
            isZeroEvent.Invoke();
        }
    }

    public void CompareValueSetHigher(IntData data)
    {
        if (Value > data.Value) return;
        else if (Value < data.Value)
        {
            Value = data.Value;
        }
    }
}