# RoofStockCodingExercise
## How to Run
1. Install SQL server. You can use docker for this.

docker pull microsoft/mssql-server-linux:2017-latest

docker run --name anqb-sql2017 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=4lv4r0P4ssw0rd$" -p 1433:1433  -d microsoft/mssql-server-linux:2017-latest

2. Publish Database

In VS, publish: RoofStock.CodingExersice.Database project. This will create the RoofStock database and create the Properties table

3. Execute RoofStock.CodingExercise.DatabaseUtil

This tool will retrieve the dataset from https://samplerspubcontent.blob.core.windows.net/public/properties.json and create the data inside the database

4. Execute RoofStock.CodingExercise.Api and RoofStock.CodingExercise.UI. You can use the Multiple startup project option in Visual Studio
