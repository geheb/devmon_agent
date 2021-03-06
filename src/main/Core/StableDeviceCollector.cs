﻿using Geheb.DevMon.Agent.Models;
using System.Threading.Tasks;

namespace Geheb.DevMon.Agent.Core
{
    internal sealed class StableDeviceCollector
    {
        private readonly ICpuCollector _cpuCollector;
        private readonly IMemoryCollector _memoryCollector;
        private readonly IDriveCollector _driveCollector;
        private readonly INetworkCollector _networkCollector;
        private readonly IOsCollector _osCollector;

        public StableDeviceCollector(
            ICpuCollector cpuCollector,
            IMemoryCollector memoryCollector,
            INetworkCollector networkCollector,
            IDriveCollector driveCollector,
            IOsCollector osCollector)
        {
            _cpuCollector = cpuCollector;
            _memoryCollector = memoryCollector;
            _driveCollector = driveCollector;
            _networkCollector = networkCollector;
            _osCollector = osCollector;
        }

        public async Task<StableDeviceInfo> Read()
        {
            return new StableDeviceInfo
            {
                Cpu = await _cpuCollector.ReadCpuInfo(),
                Mem = await _memoryCollector.ReadMemoryInfo(),
                Net = await _networkCollector.ReadNetworkInfo(),
                Drives = await _driveCollector.ReadDriveInfo(),
                Os = await _osCollector.ReadOsInfo()
            };
        }
    }
}
