using System.Runtime.InteropServices;
using UnityEditor;
using XLuaTest;

namespace LuaDeepin.Structs
{
	public static class MenuHelper
	{
		[MenuItem("Lua Deepin/Debug/TryParse")]
		public static void TryParse()
		{
			var env = LuaBehaviour.luaEnv.L;
			var lua_State = Marshal.PtrToStructure<lua_State>(env);
			var G = Marshal.PtrToStructure<global_State>(lua_State.l_G);
			var GC0 = Marshal.PtrToStructure<GCObject>(lua_State.gclist);
		}
	}
}