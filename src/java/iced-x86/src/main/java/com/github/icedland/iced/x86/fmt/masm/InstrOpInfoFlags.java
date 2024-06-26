// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

package com.github.icedland.iced.x86.fmt.masm;

final class InstrOpInfoFlags {
	private InstrOpInfoFlags() {
	}

	static final int NONE = 0x0000_0000;
	static final int MEM_SIZE_MASK = 0x0000_0007;
	static final int MEM_SIZE_SSE = 0x0000_0000;
	static final int MEM_SIZE_MMX = 0x0000_0001;
	static final int MEM_SIZE_NORMAL = 0x0000_0002;
	static final int MEM_SIZE_NOTHING = 0x0000_0003;
	static final int MEM_SIZE_XMMWORD_PTR = 0x0000_0004;
	static final int MEM_SIZE_DWORD_OR_QWORD = 0x0000_0005;
	static final int SHOW_NO_MEM_SIZE_FORCE_SIZE = 0x0000_0008;
	static final int SHOW_MIN_MEM_SIZE_FORCE_SIZE = 0x0000_0010;
	static final int JCC_NOT_TAKEN = 0x0000_0020;
	static final int JCC_TAKEN = 0x0000_0040;
	static final int BND_PREFIX = 0x0000_0080;
	static final int IGNORE_INDEX_REG = 0x0000_0100;
	static final int MNEMONIC_IS_DIRECTIVE = 0x0000_0200;
}
