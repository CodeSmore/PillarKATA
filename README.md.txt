# PillarKata - CheckoutOrderTotalKATA

The solution for a KATA that contains an API for adding items
to an order, removing items, and calculating the pre-tax total
at any point in the process. 

All data used in the solution are present in 'Catalogue' classes contained
in the /Classes/Data folder


### Setup

Microsoft Visual Studio is required to open the solution.
The free Community Edition for Windows and maxOS can be downloading at 
https://visualstudio.microsoft.com/downloads/

Once installed, the solution can be opened by double-clicking the PillarKata.sln file.

In Order to run the Unit Tests, the QualityTools.UnitTestFramework reference must
be included in the project. If it's missing follow the steps below to add it
to the project...

1. Open the PillarKata.sln file in Microsoft Visual Studio
2. In the Solution Explorer, type 'references' into the search
box at the top.
3. Right-click 'References' in the search results
4. Click 'Add Reference'
5. In the top-right search bar, type 'QualityTools.UnitTestFramework'
6. Check the check-box next to the name of latest version
7. Click the OK button at the bottom of the Reference Manager

## Running the tests

To run all of the tests, hold the control key and press R then A
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