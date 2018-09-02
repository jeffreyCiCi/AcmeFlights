using System;
using Xunit;
using System.Net;

namespace FlightsTest
{
    public class FlightTest
    {
        [Fact]
        public async void Test1_OK()
        {
            using (var client = new TestClientProvider().Client)
            {
                DateTime startDate = new DateTime(2018, 9, 12);
                DateTime endDate   = new DateTime(2018, 9, 16);
                int numOfPax = 3;

                string testUrl = "http://localhost:57123/api/Flight/search?StartDate=" 
                    + startDate.ToString("yyyy-MM-dd")
                    + "&EndDate=" + endDate.ToString("yyyy-MM-dd") 
                    + "&NumberOfPax=" + numOfPax.ToString();

                var response = await client.GetAsync(testUrl);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async void Test2_NoContent()
        {
            using (var client = new TestClientProvider().Client)
            {
                DateTime startDate = new DateTime(2018, 10, 12);
                DateTime endDate = new DateTime(2018, 10, 16);
                int numOfPax = 3;

                string testUrl = "http://localhost:57123/api/Flight/search?StartDate="
                    + startDate.ToString("yyyy-MM-dd")
                    + "&EndDate=" + endDate.ToString("yyyy-MM-dd")
                    + "&NumberOfPax=" + numOfPax.ToString();

                var response = await client.GetAsync(testUrl);

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }

        [Fact]
        public async void Test3_400_StartDateEarlierThanToday()
        {
            using (var client = new TestClientProvider().Client)
            {
                DateTime startDate = new DateTime(2018, 8, 5);
                DateTime endDate = new DateTime(2018, 9, 16);
                int numOfPax = 3;

                string testUrl = "http://localhost:57123/api/Flight/search?StartDate="
                    + startDate.ToString("yyyy-MM-dd")
                    + "&EndDate=" + endDate.ToString("yyyy-MM-dd")
                    + "&NumberOfPax=" + numOfPax.ToString();

                var response = await client.GetAsync(testUrl);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async void Test4_400_EndDateOver3MonthsFromNow()
        {
            using (var client = new TestClientProvider().Client)
            {
                DateTime startDate = new DateTime(2018, 8, 5);
                DateTime endDate = new DateTime(2018, 12, 16);
                int numOfPax = 3;

                string testUrl = "http://localhost:57123/api/Flight/search?StartDate="
                    + startDate.ToString("yyyy-MM-dd")
                    + "&EndDate=" + endDate.ToString("yyyy-MM-dd")
                    + "&NumberOfPax=" + numOfPax.ToString();

                var response = await client.GetAsync(testUrl);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async void Test5_400_EndEarlierThanStart()
        {
            using (var client = new TestClientProvider().Client)
            {
                DateTime startDate = new DateTime(2018, 9, 15);
                DateTime endDate = new DateTime(2018, 9, 12);
                int numOfPax = 3;

                string testUrl = "http://localhost:57123/api/Flight/search?StartDate="
                    + startDate.ToString("yyyy-MM-dd")
                    + "&EndDate=" + endDate.ToString("yyyy-MM-dd")
                    + "&NumberOfPax=" + numOfPax.ToString();

                var response = await client.GetAsync(testUrl);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
    }
}
