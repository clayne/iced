# SPDX-License-Identifier: MIT
# Copyright (C) 2018-present iced project and contributors

# ⚠️This file was generated by GENERATOR!🦹‍♂️

# pylint: disable=invalid-name
# pylint: disable=line-too-long
# pylint: disable=too-many-lines

"""
Operand, register and memory access
"""

import typing
if typing.TYPE_CHECKING:
	from ._iced_x86_py import OpAccess
else:
	OpAccess = int

NONE: OpAccess = 0 # type: ignore
"""
Nothing is read and nothing is written
"""
READ: OpAccess = 1 # type: ignore
"""
The value is read
"""
COND_READ: OpAccess = 2 # type: ignore
"""
The value is sometimes read and sometimes not
"""
WRITE: OpAccess = 3 # type: ignore
"""
The value is completely overwritten
"""
COND_WRITE: OpAccess = 4 # type: ignore
"""
Conditional write, sometimes it's written and sometimes it's not modified
"""
READ_WRITE: OpAccess = 5 # type: ignore
"""
The value is read and written
"""
READ_COND_WRITE: OpAccess = 6 # type: ignore
"""
The value is read and sometimes written
"""
NO_MEM_ACCESS: OpAccess = 7 # type: ignore
"""
The memory operand doesn't refer to memory (eg. ``LEA`` instruction) or it's an instruction that doesn't read the data to a register or doesn't write to the memory location, it just prefetches/invalidates it, eg. ``INVLPG``, ``PREFETCHNTA``, ``VGATHERPF0DPS``, etc. Some of those instructions still check if the code can access the memory location.
"""
