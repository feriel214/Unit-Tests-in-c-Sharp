using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_sendPing_ReturnString()
        {
            //Arrange
            NetworkService service = new NetworkService();

            //Act
            string res = service.sendPing();

            //Assert
            res.Should().BeEquivalentTo("Ping Sent",res);
            res.Should().NotBeEmpty();
            res.Should().NotBeNull();
            res.Should().Contain("Ping", Exactly.Once());
        }


        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_pingTimeOut_ReturnSumInteger(int a,int b,int expected) {

            //Arrange
            NetworkService service = new NetworkService();

            //Act
            var result=service.pingTimeOut(a,b);

            //Assert
            result.Should().Be(expected);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
