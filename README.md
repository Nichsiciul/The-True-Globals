# The True Globals - Autothon 2019

## What's inside
Repository contains a Shell Framework over Selenium that covers both UI tests, REST testing and Mobile Testing.
Project Tests are split into 2:

* TestCasesUI
* TestCasesRest

Framework is split into 3 Components:
* UI Keywords (contains the UI locators) found in Keywords.UiMap
* Actions (contains UI and API specific actions) found in Keywords.UIKeywords and Keywords.RestKeywords
* Tests (contains UI and API tests) 


## Requirements
* Visual Studio
* Selenium webdrivers for each browser

## How to run
* Build Solution in Visual Studio
* Test -> TestSettings -> Pick a configuration file provided in Tests\RunSettings
* Run Tests

## CrossBrowserSpecific how to run
Run in a comand line: 

```bash
Start-Process -FilePath "*PATH TO PROJECT*\The-True-Globals\Tests\Util\cbt_tunnels-win-x64.exe" -ArgumentList "--username (alexandru.mutescul@nagarro.com) --authkey (u073976e6cc3a78a)"
```

License is a trial license and will expire at 29th september 2019.