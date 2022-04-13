# Movie Store - BACKEND

### Desarrollo de una Aplicación API REST a cerca de un Sistema de Compra y Renta de Películas.

![alt text](https://github.com/vorellana/MovieStoreBackend/blob/master/resources/backend-1.png?raw=true)

### La aplicación se encuentra desplegada en el servicio **Azure** y se puede ver uno de sus endpoints (lista de películas):
### https://moviestorebackend.azurewebsites.net/api/Movies

![alt text](https://github.com/vorellana/MovieStoreBackend/blob/master/resources/backend-2.png?raw=true)

## 1. Características
* La solución contiene varios proyectos para un mayor orden y mantenibilidad del código.
* Uso de inyección de dependencias para un código desacoplado.
* Pruebas unitarias implementadas con xUnit.net.
* Despliegue y publicación en el servicio de nube Azure.
* Manejo de errores.
* Manejo de datos con Entity Frameworks Core.
* Modelamiento de la Base de datos mediante código (Code First).
* Base de datos publicada en Azure.

## 2. Base de datos
### Diagrama entidad-relación
![alt text](https://github.com/vorellana/MovieStoreBackend/blob/master/resources/backend-3.png?raw=true)
## 3. Estructura de carpetas y proyectos.
* Proyecto Entities: Contiene el código de los módelos de Base de Datos.
* Proyecto Web API: Contiene los controllers que se encargan de exponer los endpoints.
![alt text](https://github.com/vorellana/MovieStoreBackend/blob/master/resources/backend-4.png?raw=true)
## 4. Tecnologías de desarrollo

Para el presente proyecto se utilizarón las siguientes tecnologías como librerías, frameworks, servicios en la nube, herramientas de despliegue entre otros.
### Backend
* **.NET 6:** Framework de desarrollo.
* **Entity Framework Core:** ORM que admite consultas con LINQ, manejos de datos y migraciones de esquemas.
* **SQL Server:** Sistema de gestión de base de datos relacional.
* **react-paginate:** 
### Testing
* **xUnit.net:** Herramienta para pruebas unitarias.
### Deployment
* **Azure**: Servicio en la nube que en este caso se utiliza para desplegar la aplicación.
* **GitHub**: Servicio de repositorio de código fuente en donde se encuentran almacenado todo el código del proyecto.

## Gracias
