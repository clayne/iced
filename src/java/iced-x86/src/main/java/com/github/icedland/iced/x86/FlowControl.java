// SPDX-License-Identifier: MIT
// Copyright (C) 2018-present iced project and contributors

// ⚠️This file was generated by GENERATOR!🦹‍♂️

package com.github.icedland.iced.x86;

/**
 * Control flow
 */
public final class FlowControl {
	private FlowControl() {
	}

	/**
	 * The next instruction that will be executed is the next instruction in the instruction stream
	 */
	public static final int NEXT = 0;
	/**
	 * It's an unconditional branch instruction: {@code JMP NEAR}, {@code JMP FAR}
	 */
	public static final int UNCONDITIONAL_BRANCH = 1;
	/**
	 * It's an unconditional indirect branch: {@code JMP NEAR reg}, {@code JMP NEAR [mem]}, {@code JMP FAR [mem]}
	 */
	public static final int INDIRECT_BRANCH = 2;
	/**
	 * It's a conditional branch instruction: {@code Jcc SHORT}, {@code Jcc NEAR}, {@code LOOP}, {@code LOOPcc}, {@code JRCXZ}, {@code JKccD SHORT}, {@code JKccD NEAR}
	 */
	public static final int CONDITIONAL_BRANCH = 3;
	/**
	 * It's a return instruction: {@code RET NEAR}, {@code RET FAR}, {@code IRET}, {@code SYSRET}, {@code SYSEXIT}, {@code RSM}, {@code SKINIT}, {@code RDM}, {@code UIRET}
	 */
	public static final int RETURN = 4;
	/**
	 * It's a call instruction: {@code CALL NEAR}, {@code CALL FAR}, {@code SYSCALL}, {@code SYSENTER}, {@code VMLAUNCH}, {@code VMRESUME}, {@code VMCALL}, {@code VMMCALL}, {@code VMGEXIT}, {@code VMRUN}, {@code TDCALL}, {@code SEAMCALL}, {@code SEAMRET}
	 */
	public static final int CALL = 5;
	/**
	 * It's an indirect call instruction: {@code CALL NEAR reg}, {@code CALL NEAR [mem]}, {@code CALL FAR [mem]}
	 */
	public static final int INDIRECT_CALL = 6;
	/**
	 * It's an interrupt instruction: {@code INT n}, {@code INT3}, {@code INT1}, {@code INTO}, {@code SMINT}, {@code DMINT}
	 */
	public static final int INTERRUPT = 7;
	/**
	 * It's {@code XBEGIN}
	 */
	public static final int XBEGIN_XABORT_XEND = 8;
	/**
	 * It's an invalid instruction, eg.<!-- --> {@link com.github.icedland.iced.x86.Code#INVALID}, {@code UD0}, {@code UD1}, {@code UD2}
	 */
	public static final int EXCEPTION = 9;
}
