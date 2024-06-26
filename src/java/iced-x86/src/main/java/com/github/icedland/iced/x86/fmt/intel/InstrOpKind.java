// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

package com.github.icedland.iced.x86.fmt.intel;

final class InstrOpKind {
	private InstrOpKind() {
	}

	static final int REGISTER = 0;
	static final int NEAR_BRANCH16 = 1;
	static final int NEAR_BRANCH32 = 2;
	static final int NEAR_BRANCH64 = 3;
	static final int FAR_BRANCH16 = 4;
	static final int FAR_BRANCH32 = 5;
	static final int IMMEDIATE8 = 6;
	static final int IMMEDIATE8_2ND = 7;
	static final int IMMEDIATE16 = 8;
	static final int IMMEDIATE32 = 9;
	static final int IMMEDIATE64 = 10;
	static final int IMMEDIATE8TO16 = 11;
	static final int IMMEDIATE8TO32 = 12;
	static final int IMMEDIATE8TO64 = 13;
	static final int IMMEDIATE32TO64 = 14;
	static final int MEMORY_SEG_SI = 15;
	static final int MEMORY_SEG_ESI = 16;
	static final int MEMORY_SEG_RSI = 17;
	static final int MEMORY_SEG_DI = 18;
	static final int MEMORY_SEG_EDI = 19;
	static final int MEMORY_SEG_RDI = 20;
	static final int MEMORY_ESDI = 21;
	static final int MEMORY_ESEDI = 22;
	static final int MEMORY_ESRDI = 23;
	static final int MEMORY = 24;
	static final int DECLARE_BYTE = 25;
	static final int DECLARE_WORD = 26;
	static final int DECLARE_DWORD = 27;
	static final int DECLARE_QWORD = 28;
}
