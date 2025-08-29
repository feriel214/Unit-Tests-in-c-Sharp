using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _service;

        public NetworkServiceTests()
        {
            _service = new NetworkService();
        }

        [Fact]
        public void NetworkService_sendPing_ReturnString()
        {
            //Arrange
           

            //Act
            string res = _service.sendPing();

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
          

            //Act
            var result=_service.pingTimeOut(a,b);

            //Assert
            result.Should().Be(expected);
            result.Should().NotBeInRange(-10000, 0);
        }


        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            //Arrange

            //Act

            var result = _service.LastPingDate();

            //Assert
            
            result.Should().BeAfter(1.February(2010));
            result.Should().BeBefore(2.March(2028));
        }



        [Fact]
        public void NetworkService_GetPingOptions_PingOptions()
        {
            //Arrange
            var expected= new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act

            var result = _service.GetPingOptions();

            //Assert

            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
          
        }










        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnumerable()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act

            var result = _service.MostRecentPings();

            //Assert

            result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment ==true);

        }


    }
}
