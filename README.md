# _AnimalShelter.Solution_

#### By _Joe Roaden_

#### _Brief description of application_

---
## Table of Contents
[Technologies Used](#technologies-used)  
[Description](#description)  
[Setup/Installation Requirements](#setup-and-installation-requirements)
[API Documentation](#api-documentation)
[Known Bugs](#known-bugs)  
[License](#License)

---
## Technologies Used

* _C#_
* _.NET_
* _HTML_
* _CSS_
* _SQL Workbench_
* _Entity Framework_
* _MVC_
* _Swagger_

---
## Description

_This is a detailed description of your application. Give as much detail as needed to explain what the application does as well as any other information you want users or other developers to have._

---
## Setup and Installation Requirements

<details>
<summary><strong>Initial Setup</strong></summary>  

1. Copy the git repository url: https://github.com/joeroaden/HousePlant.Solution 
2. Open a shell program and navigate to your desktop.
3. Clone the repository for this project using the `git clone` command and including the copied URL.
4. While still in the shell program, navigate to the root directory of the newly created file named `HousePlant.Solution`.
5. From the root directory, navigate to the `HousePlant` directory.
6. Move onto SQL Workbench instructions below to re-create database necessary to run this project.
</details>

<details>
<summary><strong>SQL Workbench Configuration</strong></summary>

1. Create an `appsetting.json` file in the `HousePlant` directory of the project  
   <pre>HousePlant.Solution
   └── HousePlant
    └── <strong>appsetting.json</strong></pre>
2. Insert the following code [^1]  
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=house_plant;uid=root;pwd=[YOUR-PASSWORD-HERE];"
      }
    }
    ```

3. Once `appsettings.json` file has been created, navigate back to SQL Workbench.
</details>

<details>
<summary><strong>To Run</strong></summary>

1. Navigate to:  
   <pre>HousePlant.Solution
   └── <strong>HousePlant</strong></pre>

2. Run `$ dotnet restore` in the console.  
3. Run `$ dotnet database update` in the console.  
4. Run `$ dotnet run` in the console
</details><br>

## API Documentation

## Using Swagger Documentation

To explore HousePlant API with Swagger/Swashbuckle, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `https://localhost:5001/index.html`

## Using the JSON Web Token

In order to be authorized to use the POST, PUT, DELETE functionality of the API, please authenticate yourself through Postman._

Open Postman and create a POST request using the URL: `http://localhost:5000/api/users/authenticate`
Add the following query to the request as raw data in the Body tab:
{\
    "UserName": "test",\
    "Password": "test"\
}\
The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab.

## Endpoints

Base URL: https://localhost:5000

## HTTP Request Structure
* GET /api/plants
* POST /api/plants
* GET /api/plants/{id}
* PUT /api/plants/{id}
* DELETE /api/plants/{id}

Example Query
https://localhost:5000/api/plants/1

## Sample JSON Response

{\
    "plantId": 1,\
    "name": "AGAVE PLANT",\
    "commonName": "AGAVE",\
    "description": "An agave plant comes in all different sizes and shapes; some are extremely  large and belong growing outside while the smaller varieties make perfect indoor potted houseplants. Agave plants are succulents with multi-layered rosettes of thick, fleshy, leaves. The short, thick stem is often hidden by the large, leathery leaves. If there are children and pets in the house, avoid purchasing agave plants that have sharp, pointed leaves with spiny margins. The sap in the agave leaves is very irritating and the spines and sharp points are painful if they puncture your skin. It takes many, many years for an agave plant to flower, especially when grown indoors. Some varieties may eventually produce a very tall stalk with clusters of flowers at the top. You may not want your agave plant to bloom since, strangely, they often die after flowering.",\
    "type": "Earth",\
    "sunlight": "bright light",\
    "water": "every 2-3 weeks",\
    "humidity": "drought resistance",\
    "soil": "succulent potting soil",\
    "propagation": "Offset",\
    "tempMin": 65,\
    "tempMax": 80\
}\

## Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | true | Return matches by name.
| common name | string | none | true | Return matches by name.| description | string | none | true | Return matches by description.

## Example Query
http://localhost:5000/api/plants?commonName=agave

## Sample JSON Response
[\
    {\
        "plantId": 1,\
        "name": "AGAVE PLANT",\
        "commonName": "AGAVE",\
        "description": "An agave plant comes in all different sizes and shapes; some are extremely  large and belong growing outside while the smaller varieties make perfect indoor potted houseplants. Agave plants are succulents with multi-layered rosettes of thick, fleshy, leaves. The short, thick stem is often hidden by the large, leathery leaves. If there are children and pets in the house, avoid purchasing agave plants that have sharp, pointed leaves with spiny margins. The sap in the agave leaves is very irritating and the spines and sharp points are painful if they puncture your skin. It takes many, many years for an agave plant to flower, especially when grown indoors. Some varieties may eventually produce a very tall stalk with clusters of flowers at the top. You may not want your agave plant to bloom since, strangely, they often die after flowering.",\
        "type": "Earth",\
        "sunlight": "bright light",\
        "water": "every 2-3 weeks",\
        "humidity": "drought resistance",\
        "soil": "succulent potting soil",\
        "propagation": "Offset",\
        "tempMin": 65,\
        "tempMax": 80\
    }\
]\


This program was built using *`Microsoft .NET SDK 5.0.401`*, and may not be compatible with other versions. Your milage may vary.

---
## Known Bugs

* Any known bugs

---
## License



[Copyright](/LICENSE) © 2022 Zhibin Liang, Joe Roaden, and Mo Byrne

---
### Footnotes

[^1]: You must include your password in the code block section labeled `[YOUR-PASSWORD-HERE]`.