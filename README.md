###### Initialize tools:
Invoke-WebRequest https://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1

###### Task Commands:
- **./build.ps1 -Target Run** - Will compile the files, runs unit and integration tests, copies files to dist folder and runs web api.

- **./build.ps1 -Target BuildAndTest** - Will compile the files, runs unit and integration tests.

- **./build.ps1 -Target Default** - Will compile the files, runs unit and integration tests, copies files to dist folder.
