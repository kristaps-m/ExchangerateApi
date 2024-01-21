@echo off

rem Start the backend
cd DotNETBackEnd/ExchangerateApi
start cmd /k dotnet run
cd ../..

rem Open the browser

start "" "FrontEnd\index.html"
