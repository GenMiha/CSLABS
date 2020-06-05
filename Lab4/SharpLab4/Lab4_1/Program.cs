using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace lab4_1
{
    class Program
    {

        public enum ProcessorArchitecture
        {
            X86 = 0,
            X64 = 9,
            @Arm = -1,
            Itanium = 6,
            Unknown = 0xFFFF,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemInfo
        {
            public ProcessorArchitecture ProcessorArchitecture; // WORD
            public uint PageSize; // DWORD
            public IntPtr MinimumApplicationAddress; // (long)void*
            public IntPtr MaximumApplicationAddress; // (long)void*
            public IntPtr ActiveProcessorMask; // DWORD*
            public uint NumberOfProcessors; // DWORD (WTF)
            public uint ProcessorType; // DWORD
            public uint AllocationGranularity; // DWORD
            public ushort ProcessorLevel; // WORD
            public ushort ProcessorRevision; // WORD
        }

        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern void GetSystemInfo(out SystemInfo Info);

        static void Main(string[] args)
        {
            Console.WriteLine("Try get system information for \"kernel32\" dll");
            SystemInfo sysinfo;
            GetSystemInfo(out sysinfo);
            Console.WriteLine("Active processor mask {0}", sysinfo.ActiveProcessorMask);
            Console.WriteLine("Allocation granularity {0}", sysinfo.AllocationGranularity);
            Console.WriteLine("Maximum application address {0}", sysinfo.MaximumApplicationAddress);
            Console.WriteLine("Minimum application address {0}", sysinfo.MinimumApplicationAddress);
            Console.WriteLine("Number of processors {0}", sysinfo.NumberOfProcessors);
            Console.WriteLine("Page size {0}", sysinfo.PageSize);
            Console.WriteLine("Processor architecture {0}", sysinfo.ProcessorArchitecture);
            Console.WriteLine("Processor level {0}", sysinfo.ProcessorLevel);
            Console.WriteLine("Processor type {0}", sysinfo.ProcessorType);
            Console.WriteLine("Processor revision {0}", sysinfo.ProcessorRevision);
            Console.ReadKey(true);
        }
    }
}