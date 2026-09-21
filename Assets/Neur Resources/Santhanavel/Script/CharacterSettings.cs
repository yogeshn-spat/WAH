using System.Collections.Generic;
using UnityEngine;
public enum CharacterType
{
    None, // Default
    DrV,
    Rescuer1,
    Rescuer2
    // Add more characters as needed
}

public enum ParameterType
{
    Float,
    Int,
    Bool,
    Trigger
}

[System.Serializable]
public class CharacterSettings
{
    [Header("Select Character")]
    public CharacterType selectedCharacter;
    [Header("Set Animations")]
    public List<AnimationData> animations = new List<AnimationData>();
    [Header("Set TargetPositions")]
    public List<Transform> targetPositions = new List<Transform>();
}
[System.Serializable]
public class AnimationData
{
    public string parameterName;
    public ParameterType parameterType;
}
