using System;
using System.Runtime.InteropServices;

using size_t = System.UIntPtr;

namespace LuaDeepin.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct GCObject
	{
		// CommonHeader
		public IntPtr next;
		public byte tt;
		public byte marked;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CallInfo
	{
		public IntPtr func;
		public IntPtr top;
		public IntPtr previous;
		public IntPtr next;

		//union's largest situation
		public IntPtr k;
		public size_t old_errfunc;
		public size_t ctx;

		public size_t extra;
		public short nresults;
		public ushort callstatus;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct Value
	{
		[FieldOffset(0)]
		public IntPtr gc; // GCObject*

		[FieldOffset(0)]
		public IntPtr p; // void*

		[FieldOffset(0)]
		public int b;

		[FieldOffset(0)]
		public IntPtr f; // lua_CFunction

		[FieldOffset(0)]
		public int i; // lua_Integer

		[FieldOffset(0)]
		public float n; // lua_Number;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct TValue
	{
		// TValuefields
		public Value value_;
		public int tt_;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct lua_State
	{
		// CommonHeader
		public IntPtr next;
		public byte tt;
		public byte marked;

		public ushort nci;
		public byte status;
		public IntPtr top;
		public IntPtr l_G;
		public IntPtr ci;
		public IntPtr oldpc;
		public IntPtr stack_last;
		public IntPtr stack;
		public IntPtr openupval;
		public IntPtr gclist;
		public IntPtr twups;
		public IntPtr errorjmp;
		public CallInfo base_ci;
		public IntPtr hook;			// to hook function
		public size_t errfunc;
		public int stacksize;
		public int basehookcount;
		public int hookcount;
		public ushort nny;
		public ushort nCcalls;
		public int hookmask;
		public byte allowhook;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct stringtable
	{
		public IntPtr hash; // TString **
		public int nuse;
		public int size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct global_State
	{
		public IntPtr frealloc; // lua_Alloc
		public IntPtr ud; // void*
		public size_t totalbytes;
		public size_t GCdebt;
		public size_t GCmemtrav;
		public size_t GCestimate;
		public stringtable strt;
		public TValue l_registry;
		public uint seed;
		public byte currentwhite;
		public byte gcstate;
		public byte gckind;
		public byte gcrunning;
		public IntPtr allgc; // GCObject*
		public IntPtr sweepgc; // GCObject**
		public IntPtr finobj; // GCObject*
		public IntPtr gray; // GCObject*
		public IntPtr grayagain; // GCObject*
		public IntPtr weak; // GCObject*
		public IntPtr ephemeron; // GCObject*
		public IntPtr allweak; // GCObject*
		public IntPtr tobefnz; // GCObject*
		public IntPtr fixedgc; // GCObject*
		public IntPtr twups; // lua_State*
		public uint gcfinnum;
		public int gcpause;
		public int gcstepmul;
		public IntPtr panic; // lua_CFunction
		public IntPtr mainthread; // lua_State*
		public IntPtr verison; // const lua_Number*
		public IntPtr memerrmsg; // TString*
		public IntPtr tmname; // TString* []
		public IntPtr mt; // Table* []
		public IntPtr strcache; // TString* [][]
	}
}