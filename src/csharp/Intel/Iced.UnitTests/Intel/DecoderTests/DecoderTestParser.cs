// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using System.IO;
using Iced.Intel;

namespace Iced.UnitTests.Intel.DecoderTests {
	// GENERATOR-BEGIN: DecoderTestText
	// ⚠️This was generated by GENERATOR!🦹‍♂️
	static class DecoderTestParserConstants {
		internal const string DecoderError = "err";
		internal const string Broadcast = "bcst";
		internal const string Xacquire = "xacquire";
		internal const string Xrelease = "xrelease";
		internal const string Rep = "rep";
		internal const string Repe = "repe";
		internal const string Repne = "repne";
		internal const string Lock = "lock";
		internal const string ZeroingMasking = "zmsk";
		internal const string SuppressAllExceptions = "sae";
		internal const string Vsib32 = "vsib32";
		internal const string Vsib64 = "vsib64";
		internal const string RoundToNearest = "rc-rn";
		internal const string RoundDown = "rc-rd";
		internal const string RoundUp = "rc-ru";
		internal const string RoundTowardZero = "rc-rz";
		internal const string Op0Kind = "op0";
		internal const string Op1Kind = "op1";
		internal const string Op2Kind = "op2";
		internal const string Op3Kind = "op3";
		internal const string Op4Kind = "op4";
		internal const string EncodedHexBytes = "enc";
		internal const string Code = "code";
		internal const string DecoderOptions = "decopt";
		internal const string SegmentPrefix_ES = "es:";
		internal const string SegmentPrefix_CS = "cs:";
		internal const string SegmentPrefix_SS = "ss:";
		internal const string SegmentPrefix_DS = "ds:";
		internal const string SegmentPrefix_FS = "fs:";
		internal const string SegmentPrefix_GS = "gs:";
		internal const string OpMask_k1 = "k1";
		internal const string OpMask_k2 = "k2";
		internal const string OpMask_k3 = "k3";
		internal const string OpMask_k4 = "k4";
		internal const string OpMask_k5 = "k5";
		internal const string OpMask_k6 = "k6";
		internal const string OpMask_k7 = "k7";
		internal const string ConstantOffsets = "co";
		internal const string OpKind_Register = "r";
		internal const string OpKind_NearBranch16 = "nb16";
		internal const string OpKind_NearBranch32 = "nb32";
		internal const string OpKind_NearBranch64 = "nb64";
		internal const string OpKind_FarBranch16 = "fb16";
		internal const string OpKind_FarBranch32 = "fb32";
		internal const string OpKind_Immediate8 = "i8";
		internal const string OpKind_Immediate16 = "i16";
		internal const string OpKind_Immediate32 = "i32";
		internal const string OpKind_Immediate64 = "i64";
		internal const string OpKind_Immediate8to16 = "i8to16";
		internal const string OpKind_Immediate8to32 = "i8to32";
		internal const string OpKind_Immediate8to64 = "i8to64";
		internal const string OpKind_Immediate32to64 = "i32to64";
		internal const string OpKind_Immediate8_2nd = "i8_2nd";
		internal const string OpKind_MemorySegSI = "segsi";
		internal const string OpKind_MemorySegESI = "segesi";
		internal const string OpKind_MemorySegRSI = "segrsi";
		internal const string OpKind_MemorySegDI = "segdi";
		internal const string OpKind_MemorySegEDI = "segedi";
		internal const string OpKind_MemorySegRDI = "segrdi";
		internal const string OpKind_MemoryESDI = "esdi";
		internal const string OpKind_MemoryESEDI = "esedi";
		internal const string OpKind_MemoryESRDI = "esrdi";
		internal const string OpKind_Memory = "m";
		internal const string DecoderTestOptions_NoEncode = "noencode";
		internal const string DecoderTestOptions_NoOptDisableTest = "no_opt_disable_test";
		internal const string IP = "ip";
		internal const string EvictionHint = "eh";
		internal const string MVEX_RegSwizzleNone = "mvex-dcba";
		internal const string MVEX_RegSwizzleCdab = "mvex-cdab";
		internal const string MVEX_RegSwizzleBadc = "mvex-badc";
		internal const string MVEX_RegSwizzleDacb = "mvex-dacb";
		internal const string MVEX_RegSwizzleAaaa = "mvex-aaaa";
		internal const string MVEX_RegSwizzleBbbb = "mvex-bbbb";
		internal const string MVEX_RegSwizzleCccc = "mvex-cccc";
		internal const string MVEX_RegSwizzleDddd = "mvex-dddd";
		internal const string MVEX_MemConvNone = "mvex-mident";
		internal const string MVEX_MemConvBroadcast1 = "mvex-bcst1";
		internal const string MVEX_MemConvBroadcast4 = "mvex-bcst4";
		internal const string MVEX_MemConvFloat16 = "mvex-f16";
		internal const string MVEX_MemConvUint8 = "mvex-u8";
		internal const string MVEX_MemConvSint8 = "mvex-s8";
		internal const string MVEX_MemConvUint16 = "mvex-u16";
		internal const string MVEX_MemConvSint16 = "mvex-s16";
	}
	// GENERATOR-END: DecoderTestText

	static class DecoderTestParser {
		public static IEnumerable<DecoderTestCase> ReadFile(int bitness, string filename) {
			int lineNumber = 0;
			foreach (var line in File.ReadLines(filename)) {
				lineNumber++;
				if (line.Length == 0 || line[0] == '#')
					continue;
				DecoderTestCase testCase;
				try {
					testCase = ReadTestCase(bitness, line, lineNumber);
				}
				catch (Exception ex) {
					throw new InvalidOperationException($"Error parsing decoder test case file '{filename}', line {lineNumber}: {ex.Message}");
				}
				if (testCase is not null)
					yield return testCase;
			}
		}

		static readonly char[] seps = new char[] { ',' };
		static readonly char[] extraSeps = new char[] { ' ' };
		static readonly char[] semicolonSeparator = new char[] { ';' };
		static DecoderTestCase ReadTestCase(int bitness, string line, int lineNumber) {
			var parts = line.Split(seps);
			if (parts.Length != 5)
				throw new InvalidOperationException($"Invalid number of commas ({parts.Length - 1} commas)");

			var tc = new DecoderTestCase();
			tc.LineNumber = lineNumber;
			tc.TestOptions = DecoderTestOptions.None;
			tc.Bitness = bitness;
			tc.IP = bitness switch {
				16 => DecoderConstants.DEFAULT_IP16,
				32 => DecoderConstants.DEFAULT_IP32,
				64 => DecoderConstants.DEFAULT_IP64,
				_ => throw new InvalidOperationException(),
			};
			tc.HexBytes = ToHexBytes(parts[0].Trim());
			tc.EncodedHexBytes = tc.HexBytes;
			var code = parts[1].Trim();
			if (CodeUtils.IsIgnored(code))
				return null;
			tc.Code = ToCode(code);
			tc.Mnemonic = ToMnemonic(parts[2].Trim());
			tc.OpCount = NumberConverter.ToInt32(parts[3].Trim());
			tc.DecoderError = tc.Code == Code.INVALID ? DecoderError.InvalidInstruction : DecoderError.None;

			bool foundCode = false;
			foreach (var tmp in parts[4].Split(extraSeps)) {
				if (tmp == string.Empty)
					continue;
				var key = tmp;
				string value;
				int index = key.IndexOf('=');
				if (index >= 0) {
					value = key.Substring(index + 1);
					key = key.Substring(0, index);
				}
				else
					value = null;
				switch (key) {
				case DecoderTestParserConstants.DecoderError:
					if (value is null)
						throw new InvalidOperationException($"Missing decoder error value");
					if (!ToEnumConverter.TryDecoderError(value, out tc.DecoderError))
						throw new InvalidOperationException($"Invalid decoder error value: {value}");
					break;

				case DecoderTestParserConstants.Broadcast:
					tc.IsBroadcast = true;
					break;

				case DecoderTestParserConstants.Xacquire:
					tc.HasXacquirePrefix = true;
					break;

				case DecoderTestParserConstants.Xrelease:
					tc.HasXreleasePrefix = true;
					break;

				case DecoderTestParserConstants.Rep:
				case DecoderTestParserConstants.Repe:
					tc.HasRepePrefix = true;
					break;

				case DecoderTestParserConstants.Repne:
					tc.HasRepnePrefix = true;
					break;

				case DecoderTestParserConstants.Lock:
					tc.HasLockPrefix = true;
					break;

				case DecoderTestParserConstants.ZeroingMasking:
					tc.ZeroingMasking = true;
					break;

				case DecoderTestParserConstants.SuppressAllExceptions:
					tc.SuppressAllExceptions = true;
					break;

				case DecoderTestParserConstants.Vsib32:
					tc.VsibBitness = 32;
					break;

				case DecoderTestParserConstants.Vsib64:
					tc.VsibBitness = 64;
					break;

				case DecoderTestParserConstants.RoundToNearest:
					tc.RoundingControl = RoundingControl.RoundToNearest;
					break;

				case DecoderTestParserConstants.RoundDown:
					tc.RoundingControl = RoundingControl.RoundDown;
					break;

				case DecoderTestParserConstants.RoundUp:
					tc.RoundingControl = RoundingControl.RoundUp;
					break;

				case DecoderTestParserConstants.RoundTowardZero:
					tc.RoundingControl = RoundingControl.RoundTowardZero;
					break;

				case DecoderTestParserConstants.Op0Kind:
					if (tc.OpCount < 1)
						throw new InvalidOperationException($"Invalid OpCount: {tc.OpCount} < 1");
					ReadOpKind(tc, 0, value);
					break;

				case DecoderTestParserConstants.Op1Kind:
					if (tc.OpCount < 2)
						throw new InvalidOperationException($"Invalid OpCount: {tc.OpCount} < 2");
					ReadOpKind(tc, 1, value);
					break;

				case DecoderTestParserConstants.Op2Kind:
					if (tc.OpCount < 3)
						throw new InvalidOperationException($"Invalid OpCount: {tc.OpCount} < 3");
					ReadOpKind(tc, 2, value);
					break;

				case DecoderTestParserConstants.Op3Kind:
					if (tc.OpCount < 4)
						throw new InvalidOperationException($"Invalid OpCount: {tc.OpCount} < 4");
					ReadOpKind(tc, 3, value);
					break;

				case DecoderTestParserConstants.Op4Kind:
					if (tc.OpCount < 5)
						throw new InvalidOperationException($"Invalid OpCount: {tc.OpCount} < 5");
					ReadOpKind(tc, 4, value);
					break;

				case DecoderTestParserConstants.EncodedHexBytes:
					if (string.IsNullOrWhiteSpace(value))
						throw new InvalidOperationException($"Invalid encoded hex bytes: '{value}'");
					tc.EncodedHexBytes = ToHexBytes(value);
					break;

				case DecoderTestParserConstants.Code:
					if (string.IsNullOrWhiteSpace(value))
						throw new InvalidOperationException($"Invalid Code value: '{value}'");
					if (CodeUtils.IsIgnored(value))
						return null;
					foundCode = true;
					break;

				case DecoderTestParserConstants.DecoderOptions:
					if (string.IsNullOrWhiteSpace(value))
						throw new InvalidOperationException($"Invalid DecoderOption value: '{value}'");
					if (!TryParseDecoderOptions(value.Split(semicolonSeparator), ref tc.DecoderOptions))
						throw new Exception($"Invalid DecoderOptions value, '{value}'");
					break;

				case DecoderTestParserConstants.IP:
					if (string.IsNullOrWhiteSpace(value))
						throw new InvalidOperationException($"Invalid IP value: '{value}'");
					tc.IP = NumberConverter.ToUInt64(value);
					break;

				case DecoderTestParserConstants.EvictionHint:
#if MVEX
					tc.Mvex.EvictionHint = true;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleNone:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleNone;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleCdab:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleCdab;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleBadc:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleBadc;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleDacb:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleDacb;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleAaaa:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleAaaa;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleBbbb:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleBbbb;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleCccc:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleCccc;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_RegSwizzleDddd:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.RegSwizzleDddd;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvNone:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvNone;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvBroadcast1:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvBroadcast1;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvBroadcast4:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvBroadcast4;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvFloat16:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvFloat16;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvUint8:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvUint8;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvSint8:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvSint8;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvUint16:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvUint16;
					break;
#else
					throw new InvalidOperationException();
#endif

				case DecoderTestParserConstants.MVEX_MemConvSint16:
#if MVEX
					tc.Mvex.RegMemConv = MvexRegMemConv.MemConvSint16;
					break;
#else
					throw new InvalidOperationException();
#endif


				case DecoderTestParserConstants.SegmentPrefix_ES:
					tc.SegmentPrefix = Register.ES;
					break;

				case DecoderTestParserConstants.SegmentPrefix_CS:
					tc.SegmentPrefix = Register.CS;
					break;

				case DecoderTestParserConstants.SegmentPrefix_SS:
					tc.SegmentPrefix = Register.SS;
					break;

				case DecoderTestParserConstants.SegmentPrefix_DS:
					tc.SegmentPrefix = Register.DS;
					break;

				case DecoderTestParserConstants.SegmentPrefix_FS:
					tc.SegmentPrefix = Register.FS;
					break;

				case DecoderTestParserConstants.SegmentPrefix_GS:
					tc.SegmentPrefix = Register.GS;
					break;

				case DecoderTestParserConstants.OpMask_k1:
					tc.OpMask = Register.K1;
					break;

				case DecoderTestParserConstants.OpMask_k2:
					tc.OpMask = Register.K2;
					break;

				case DecoderTestParserConstants.OpMask_k3:
					tc.OpMask = Register.K3;
					break;

				case DecoderTestParserConstants.OpMask_k4:
					tc.OpMask = Register.K4;
					break;

				case DecoderTestParserConstants.OpMask_k5:
					tc.OpMask = Register.K5;
					break;

				case DecoderTestParserConstants.OpMask_k6:
					tc.OpMask = Register.K6;
					break;

				case DecoderTestParserConstants.OpMask_k7:
					tc.OpMask = Register.K7;
					break;

				case DecoderTestParserConstants.ConstantOffsets:
					if (!TryParseConstantOffsets(value, out tc.ConstantOffsets))
						throw new InvalidOperationException($"Invalid ConstantOffsets: '{value}'");
					break;

				case DecoderTestParserConstants.DecoderTestOptions_NoEncode:
					tc.TestOptions |= DecoderTestOptions.NoEncode;
					break;

				case DecoderTestParserConstants.DecoderTestOptions_NoOptDisableTest:
					tc.TestOptions |= DecoderTestOptions.NoOptDisableTest;
					break;

				default:
					throw new InvalidOperationException($"Invalid key '{key}'");
				}
			}

			if (tc.Code == Code.INVALID && !foundCode)
				throw new InvalidOperationException($"Test case decodes to {nameof(Code.INVALID)} but there's no {DecoderTestParserConstants.Code}=xxx showing the original {nameof(Code)} value so it can be filtered out if needed");

			return tc;
		}

		static bool TryParseDecoderOptions(string[] stringOptions, ref DecoderOptions options) {
			foreach (var opt in stringOptions) {
				if (!ToEnumConverter.TryDecoderOptions(opt.Trim(), out var decOpts))
					return false;
				options |= decOpts;
			}
			return true;
		}

		static readonly char[] coSeps = new char[] { ';' };
		internal static bool TryParseConstantOffsets(string value, out ConstantOffsets constantOffsets) {
			constantOffsets = default;
			if (value is null)
				return false;

			var parts = value.Split(coSeps);
			if (parts.Length != 6)
				return false;
			constantOffsets.ImmediateOffset = NumberConverter.ToUInt8(parts[0]);
			constantOffsets.ImmediateSize = NumberConverter.ToUInt8(parts[1]);
			constantOffsets.ImmediateOffset2 = NumberConverter.ToUInt8(parts[2]);
			constantOffsets.ImmediateSize2 = NumberConverter.ToUInt8(parts[3]);
			constantOffsets.DisplacementOffset = NumberConverter.ToUInt8(parts[4]);
			constantOffsets.DisplacementSize = NumberConverter.ToUInt8(parts[5]);
			return true;
		}

		static readonly char[] opKindSeps = new char[] { ';' };
		static void ReadOpKind(DecoderTestCase tc, int operand, string value) {
			var parts = value.Split(opKindSeps);
			switch (parts[0]) {
			case DecoderTestParserConstants.OpKind_Register:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpRegister(operand, ToRegister(parts[1]));
				tc.SetOpKind(operand, OpKind.Register);
				break;

			case DecoderTestParserConstants.OpKind_NearBranch16:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.NearBranch16);
				tc.NearBranch = NumberConverter.ToUInt16(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_NearBranch32:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.NearBranch32);
				tc.NearBranch = NumberConverter.ToUInt32(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_NearBranch64:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.NearBranch64);
				tc.NearBranch = NumberConverter.ToUInt64(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_FarBranch16:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.FarBranch16);
				tc.FarBranchSelector = NumberConverter.ToUInt16(parts[1]);
				tc.FarBranch = NumberConverter.ToUInt16(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_FarBranch32:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.FarBranch32);
				tc.FarBranchSelector = NumberConverter.ToUInt16(parts[1]);
				tc.FarBranch = NumberConverter.ToUInt32(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate8:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate8);
				tc.Immediate = NumberConverter.ToUInt8(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate16:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate16);
				tc.Immediate = NumberConverter.ToUInt16(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate32:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate32);
				tc.Immediate = NumberConverter.ToUInt32(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate64:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate64);
				tc.Immediate = NumberConverter.ToUInt64(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate8to16:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate8to16);
				tc.Immediate = NumberConverter.ToUInt16(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate8to32:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate8to32);
				tc.Immediate = NumberConverter.ToUInt32(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate8to64:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate8to64);
				tc.Immediate = NumberConverter.ToUInt64(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate32to64:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate32to64);
				tc.Immediate = NumberConverter.ToUInt64(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Immediate8_2nd:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Immediate8_2nd);
				tc.Immediate_2nd = NumberConverter.ToUInt8(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegSI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegSI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegESI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegESI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegRSI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegRSI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegDI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegDI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegEDI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegEDI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemorySegRDI:
				if (parts.Length != 3)
					throw new InvalidOperationException($"Operand {operand}: expected 3 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemorySegRDI);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemorySize = ToMemorySize(parts[2]);
				break;

			case DecoderTestParserConstants.OpKind_MemoryESDI:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemoryESDI);
				tc.MemorySize = ToMemorySize(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_MemoryESEDI:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemoryESEDI);
				tc.MemorySize = ToMemorySize(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_MemoryESRDI:
				if (parts.Length != 2)
					throw new InvalidOperationException($"Operand {operand}: expected 2 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.MemoryESRDI);
				tc.MemorySize = ToMemorySize(parts[1]);
				break;

			case DecoderTestParserConstants.OpKind_Memory:
				if (parts.Length != 8)
					throw new InvalidOperationException($"Operand {operand}: expected 8 values, actual = {parts.Length}");
				tc.SetOpKind(operand, OpKind.Memory);
				tc.MemorySegment = ToRegister(parts[1]);
				tc.MemoryBase = ToRegister(parts[2]);
				tc.MemoryIndex = ToRegister(parts[3]);
				tc.MemoryIndexScale = NumberConverter.ToInt32(parts[4]);
				tc.MemoryDisplacement = NumberConverter.ToUInt64(parts[5]);
				tc.MemoryDisplSize = NumberConverter.ToInt32(parts[6]);
				tc.MemorySize = ToMemorySize(parts[7]);
				break;

			default:
				throw new InvalidOperationException($"Invalid opkind: '{parts[0]}'");
			}
		}

		static string ToHexBytes(string value) {
			try {
				HexUtils.ToByteArray(value);
			}
			catch {
				throw new InvalidOperationException($"Invalid hex bytes: '{value}'");
			}
			return value;
		}

		static Code ToCode(string value) {
			if (!ToEnumConverter.TryCode(value, out var code))
				throw new InvalidOperationException($"Invalid Code value: '{value}'");
			return code;
		}

		static Mnemonic ToMnemonic(string value) {
			if (!ToEnumConverter.TryMnemonic(value, out var mnemonic))
				throw new InvalidOperationException($"Invalid Mnemonic value: '{value}'");
			return mnemonic;
		}

		static Register ToRegister(string value) {
			if (value == string.Empty)
				return Register.None;
			if (!ToEnumConverter.TryRegister(value, out var reg))
				throw new InvalidOperationException($"Invalid Register value: '{value}'");
			return reg;
		}

		static MemorySize ToMemorySize(string value) {
			if (!ToEnumConverter.TryMemorySize(value, out var memSize))
				throw new InvalidOperationException($"Invalid MemorySize value: '{value}'");
			return memSize;
		}
	}
}
