﻿using System;
namespace Geheb.DevMon.Agent.Models
{
    public sealed class OsUtilization
    {
        public int Processes { get; set; }
        public TimeSpan UpTime { get; set; }
        public WindowsUpdateInfo Update { get; set; }
    }
}
