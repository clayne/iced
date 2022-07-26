// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

package com.github.icedland.iced.x86.internal.enc;

/**
 * DO NOT USE: INTERNAL API
 */
public final class EncFlags2 {
	private EncFlags2() {
	}

	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int NONE = 0x0000_0000;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int OP_CODE_SHIFT = 0x0000_0000;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int OP_CODE_IS2_BYTES = 0x0001_0000;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int TABLE_SHIFT = 0x0000_0011;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int TABLE_MASK = 0x0000_0007;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int MANDATORY_PREFIX_SHIFT = 0x0000_0014;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int MANDATORY_PREFIX_MASK = 0x0000_0003;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int WBIT_SHIFT = 0x0000_0016;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int WBIT_MASK = 0x0000_0003;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int LBIT_SHIFT = 0x0000_0018;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int LBIT_MASK = 0x0000_0007;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int GROUP_INDEX_SHIFT = 0x0000_001B;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int GROUP_INDEX_MASK = 0x0000_0007;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int HAS_MANDATORY_PREFIX = 0x4000_0000;
	/**
	 * DO NOT USE: INTERNAL API
	 */
	public static final int HAS_GROUP_INDEX = 0x8000_0000;
}