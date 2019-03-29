using System;
using Xunit;
using Xunit.Abstractions;

namespace Unicorn.Common.UnitTests
{
    public class IpUtilTests
    {
        private readonly ITestOutputHelper _output;

        public IpUtilTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void LocalIpTest()
        {
            var ip = IpUtil.GetLocalIp();
            _output.WriteLine("Local Ip: "+ip);
            Assert.False(string.IsNullOrEmpty(ip));
        }

        [Fact]
        public void LocalIpListTest()
        {
            var ipList = IpUtil.GetLocalIpAddressList();
            foreach (var ip in ipList)
            {
                _output.WriteLine("Local Ip: " + ip);
            }
            Assert.NotNull(ipList);
        }
    }
}
