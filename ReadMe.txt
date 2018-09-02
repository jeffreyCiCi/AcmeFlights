
INTRODUCTION
-------------
This demo web API is implemented on .net Core 2.1, with In-Membery database.
The design adopted Onion Architecture.
The application can run without installing external database.
Flights information is loaded into database in the code.
Sample test cases have been added in the test project.


FUNCTIONALITY
-------------
By calling "http://localhost:57123/api/Flight/search", and providing Start Date, End Date and 
Number of pax through query string, the API will return a viewmodel object containing a list of 
available flights in JSON format.

Some input restrictions have been imposed based on assumptions, such as:
	- Start date cannot be earlier than today
	- End date cannot be earlier than start date
	- End date cannot be later than 3 months from now
	- Number of pax must between 1 and 10


SAMPLE REQUEST
--------------
Request:
	http://localhost:57123/api/Flight/search?StartDate=2018-09-12&EndDate=2018-09-15&NumberOfPax=5
	Start date: 2018-09-12
	End date: 2018-09-15
	Number of pax: 5

Response JSON:
{
    "flightList": [
        {
            "flightCode": "CA579",
            "flightDateTime": "2018-09-12T11:35:00"
        },
        {
            "flightCode": "CA579",
            "flightDateTime": "2018-09-13T11:35:00"
        },
        {
            "flightCode": "CA579",
            "flightDateTime": "2018-09-14T11:35:00"
        },
        {
            "flightCode": "JT231",
            "flightDateTime": "2018-09-12T11:35:00"
        },
        {
            "flightCode": "JT231",
            "flightDateTime": "2018-09-14T11:35:00"
        },
        {
            "flightCode": "JT231",
            "flightDateTime": "2018-09-15T11:35:00"
        }
    ]
}


