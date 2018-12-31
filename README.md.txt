# PillarKata - CheckoutOrderTotalKATA

The solution for a KATA that contains an API for adding items
to an order, removing items, and calculating the pre-tax total
at any point in the process. 

All data used in the solution are present in 'Catalogue' classes contained
in the /Classes/Data folder


### Setup

Microsoft Visual Studio is required to open the solution.
The free Community Edition for Windows and maxOS can be downloading at...
https://visualstudio.microsoft.com/downloads/

The .NET Core SDK is also required, which can be downloaded from...
https://dotnet.microsoft.com/download

Once installed, the solution can be opened by double-clicking the PillarKata.sln file.

In Order to run the Unit Tests, the .NET Core SDK and several NuGet packages must
be present under 'Dependencies' in the Solution Explorer
- Microsoft.NET.Test.SDK
- MSTest.TestAdapter
- MSTest.TestFramework

If any are missing, they can be added to the project via the NuGet Package Manager.
This can be accessed via Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
From there, click 'Browse' at the top and search for each package by name and select the project
and click install.

## Running the tests

To run the tests from the command prompt without needing to open Visual Studio... 
run the command prompt, move the directory to the root 'PillarKata' folder 
(the one with the PillarKata.sln file),
and input `dotnet test` to run all tests. 

Within Visual Studio...
To run all of the tests using hotkeys, hold the control key and press R then A
or...
At the top menu of Visual Studio, select Test, then Run, then All Tests
or...
At the top menu of Visual Studio, select Test, Windows, TestExplorer
This will open a new window containing all of the unit tests. By clicking the arrows
to the left of each test, all of the available tests will be presented and individual tests
can be run by right-clicking the test and selecting 'Run Selected Tests'

More information on the Test Explorer can be found in Microsoft's Docs via
https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2017

### Break down into end to end tests

The unit tests test the API's ability to correctly calculate pre-tax totals
in situations where markdowns, order alterations, and different types of specials
are applied. 

```
Ex. Test04_CalculateTotalPriceWithMarkdownedItem() tests that the markdown of $0.10
is correctly applied to the total calculated price.
```

## Authors

* **Peter Kirk**