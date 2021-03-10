using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Passing,
    Shooting,
    Defending
}

public class Attribute
{
    public AttributeType attributeType;
    public float value;

    public Attribute(AttributeType type)
    {
        attributeType = type;

        value = Random.value;
    }
}
