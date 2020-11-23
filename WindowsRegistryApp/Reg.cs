using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRegistryApp
{
    class Reg
    {
        static public RegistryKey GetRegistryKeyByName(string regKeyName, ArrayList regKeysList)
        {
            foreach (RegistryKey rk in regKeysList)
            {
                if (rk.ToString().Contains(regKeyName))
                {
                    return rk;
                }
            }

            return null;
        }

        public enum RegistryValueKindNative
        {
            NONE = -1,
            UNKNOWN = 0,
            REG_SZ = 1,
            REG_EXPAND_SZ = 2,
            REG_BINARY = 3,
            REG_DWORD = 4,
            REG_MULTI_SZ = 7,
            REG_QWORD = 11
        }
    }
}
