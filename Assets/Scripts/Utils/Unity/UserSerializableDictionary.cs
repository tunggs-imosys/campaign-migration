using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System;
using TMPro;
using Utils;
using UnityEngine.UI;
using UnityEngine.Events;
using MyBox;

[Serializable]
public class SerializableDictionaryStringString
  : SerializableDictionaryBase<string, string>
{ }

[Serializable]
public class SerializableDictionaryCharInt
  : SerializableDictionaryBase<char, int>
{ }

[Serializable]
public class SerializableDictionaryStringTMPInputField
  : SerializableDictionaryBase<string, TMP_InputField>
{ }

[Serializable]
public class SerializableDictionaryStringSprite
  : SerializableDictionaryBase<string, Sprite>
{ }

[Serializable]
public class SerializableDictionaryStringUnityEvent
  : SerializableDictionaryBase<string, UnityEvent>
{ }

[Serializable]
public class SerializableDictionaryBoolUnityEvent
  : SerializableDictionaryBase<bool, UnityEvent>
{ }

[Serializable]
public class SerializableDictionaryRangedFloatUnityEvent
  : SerializableDictionaryBase<RangedFloat, UnityEvent>
{ }
