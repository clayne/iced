// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

using System;
using System.Collections.Generic;
using Iced.Intel;

namespace Iced.UnitTests.Intel {
	static partial class ToEnumConverter {
		public static bool TryDecoderOptions(string value, out DecoderOptions decoderOptions) => decoderOptionsDict.TryGetValue(value, out decoderOptions);
		public static DecoderOptions GetDecoderOptions(string value) => TryDecoderOptions(value, out var decoderOptions) ? decoderOptions : throw new InvalidOperationException($"Invalid DecoderOptions value: {value}");

		static readonly Dictionary<string, DecoderOptions> decoderOptionsDict =
			// GENERATOR-BEGIN: DecoderOptionsHash
			// ⚠️This was generated by GENERATOR!🦹‍♂️
			new Dictionary<string, DecoderOptions>(26, StringComparer.Ordinal) {
				{ "None", DecoderOptions.None },
				{ "NoInvalidCheck", DecoderOptions.NoInvalidCheck },
				{ "AMD", DecoderOptions.AMD },
				{ "ForceReservedNop", DecoderOptions.ForceReservedNop },
				{ "Umov", DecoderOptions.Umov },
				{ "Xbts", DecoderOptions.Xbts },
				{ "Cmpxchg486A", DecoderOptions.Cmpxchg486A },
				{ "OldFpu", DecoderOptions.OldFpu },
				{ "Pcommit", DecoderOptions.Pcommit },
				{ "Loadall286", DecoderOptions.Loadall286 },
				{ "Loadall386", DecoderOptions.Loadall386 },
				{ "Cl1invmb", DecoderOptions.Cl1invmb },
				{ "MovTr", DecoderOptions.MovTr },
				{ "Jmpe", DecoderOptions.Jmpe },
				{ "NoPause", DecoderOptions.NoPause },
				{ "NoWbnoinvd", DecoderOptions.NoWbnoinvd },
				{ "Udbg", DecoderOptions.Udbg },
				{ "NoMPFX_0FBC", DecoderOptions.NoMPFX_0FBC },
				{ "NoMPFX_0FBD", DecoderOptions.NoMPFX_0FBD },
				{ "NoLahfSahf64", DecoderOptions.NoLahfSahf64 },
				{ "MPX", DecoderOptions.MPX },
				{ "Cyrix", DecoderOptions.Cyrix },
				{ "Cyrix_SMINT_0F7E", DecoderOptions.Cyrix_SMINT_0F7E },
				{ "Cyrix_DMI", DecoderOptions.Cyrix_DMI },
				{ "ALTINST", DecoderOptions.ALTINST },
				{ "KNC", DecoderOptions.KNC },
			};
			// GENERATOR-END: DecoderOptionsHash
	}
}
