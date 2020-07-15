using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

[Serializable]
public class SerializableNumberFormatInfo : IFormatProvider
{
  NumberFormatInfo _formatInfo = new NumberFormatInfo();
  public object GetFormat(Type formatType)
  {
    _formatInfo.CurrencyDecimalDigits = CurrencyDecimalDigits;
    _formatInfo.CurrencyDecimalSeparator = CurrencyDecimalSeparator;
    _formatInfo.CurrencyGroupSeparator = CurrencyGroupSeparator;
    _formatInfo.CurrencyGroupSizes = CurrencyGroupSizes;
    _formatInfo.CurrencyNegativePattern = CurrencyNegativePattern;
    _formatInfo.CurrencyPositivePattern = CurrencyPositivePattern;
    _formatInfo.CurrencySymbol = CurrencySymbol;
    _formatInfo.NaNSymbol = NaNSymbol;
    _formatInfo.NativeDigits = NativeDigits;
    _formatInfo.NegativeInfinitySymbol = NegativeInfinitySymbol;
    _formatInfo.NegativeSign = NegativeSign;
    _formatInfo.NumberDecimalDigits = NumberDecimalDigits;
    _formatInfo.NumberDecimalSeparator = NumberDecimalSeparator;
    _formatInfo.NumberGroupSeparator = NumberGroupSeparator;
    _formatInfo.NumberGroupSizes = NumberGroupSizes;
    _formatInfo.NumberNegativePattern = NumberNegativePattern;
    _formatInfo.PercentDecimalDigits = PercentDecimalDigits;
    _formatInfo.PercentDecimalSeparator = PercentDecimalSeparator;
    _formatInfo.PercentGroupSeparator = PercentGroupSeparator;
    _formatInfo.PercentGroupSizes = PercentGroupSizes;
    _formatInfo.PercentNegativePattern = PercentNegativePattern;
    _formatInfo.PercentPositivePattern = PercentPositivePattern;
    _formatInfo.PercentSymbol = PercentSymbol;
    _formatInfo.PerMilleSymbol = PerMilleSymbol;
    _formatInfo.PositiveInfinitySymbol = PositiveInfinitySymbol;
    _formatInfo.PositiveSign = PositiveSign;
    return _formatInfo;
  }

  static NumberFormatInfo Default => NumberFormatInfo.InvariantInfo;

  public int CurrencyDecimalDigits = Default.CurrencyDecimalDigits;
  public string CurrencyDecimalSeparator = Default.CurrencyDecimalSeparator;
  public string CurrencyGroupSeparator = Default.CurrencyGroupSeparator;
  public int[] CurrencyGroupSizes = Default.CurrencyGroupSizes;
  public int CurrencyNegativePattern = Default.CurrencyNegativePattern;
  public int CurrencyPositivePattern = Default.CurrencyPositivePattern;
  public string CurrencySymbol = Default.CurrencySymbol;
  public string NaNSymbol = Default.NaNSymbol;
  public string[] NativeDigits = Default.NativeDigits;
  public string NegativeInfinitySymbol = Default.NegativeInfinitySymbol;
  public string NegativeSign = Default.NegativeSign;
  public int NumberDecimalDigits = Default.NumberDecimalDigits;
  public string NumberDecimalSeparator = Default.NumberDecimalSeparator;
  public string NumberGroupSeparator = Default.NumberGroupSeparator;
  public int[] NumberGroupSizes = Default.NumberGroupSizes;
  public int NumberNegativePattern = Default.NumberNegativePattern;
  public int PercentDecimalDigits = Default.PercentDecimalDigits;
  public string PercentDecimalSeparator = Default.PercentDecimalSeparator;
  public string PercentGroupSeparator = Default.PercentGroupSeparator;
  public int[] PercentGroupSizes = Default.PercentGroupSizes;
  public int PercentNegativePattern = Default.PercentNegativePattern;
  public int PercentPositivePattern = Default.PercentPositivePattern;
  public string PercentSymbol = Default.PercentSymbol;
  public string PerMilleSymbol = Default.PerMilleSymbol;
  public string PositiveInfinitySymbol = Default.PositiveInfinitySymbol;
  public string PositiveSign = Default.PositiveSign;
}
