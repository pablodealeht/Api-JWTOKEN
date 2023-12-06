# ApiLogin
Api de Testing con login incluido más consultas de promedio, registro, personal y usuarios

## Estructura de Carpetas

- **Application:** Contiene los casos de uso (Use Cases) y lógica de aplicación.
- **Domain:** Define las entidades y reglas de negocio.
- **Infrastructure:** Implementa detalles externos, como bases de datos y servicios externos.
- **Web:** Contiene los controladores, modelos y configuraciones de la interfaz de usuario.

## Base de Datos
### Estructura de Tablas
- **Usuarios:** Almacena información de usuarios y tokens.
- **Registros:** Almacena los ingresos y egresos del personal.

## Servicios

### Services 1 – Autenticación

- **Método:** POST
- **Descripción:** Genera un token de autenticación.
- **Parámetros:**
  - `user:` Nombre de usuario.
  - `pass:` Contraseña.

### Services 2 - Registro de Ingresos y Egresos

- **Método:** POST
- **Descripción:** Registra ingresos y egresos del personal.
- **Parámetros:**
  - `idEmployee:` ID del empleado.
  - `date:` Fecha del registro.
  - `registerType:` Tipo de registro (ingreso/egreso).
  - `businessLocation:` Ubicación del negocio.

### Services 3 - Búsqueda de Registros

- **Método:** GET
- **Descripción:** Lista la cantidad de ingresos y egresos según filtros.
- **Parámetros:**
  - `dateFrom:` Fecha inicio.
  - `dateTo:` Fecha fin.
  - `descriptionFilter:` Filtro por nombre o apellido.
  - `businessLocation:` Sucursal.

### Services 4 - Promedio de Ingresos y Egresos 

- **Método:** GET
- **Descripción:** Devuelve el promedio de hombres y mujeres que ingresan y egresan por mes, por sucursal.
- **Parámetros:**
  - `dateFrom:` Fecha inicio.
  - `dateTo:` Fecha fin.

## Lenguaje de Desarrollo
El proyecto está desarrollado principalmente en C# utilizando ASP.NET.

## Validaciones de Datos
- Todas las solicitudes incluyen validaciones para garantizar datos consistentes y seguros.
- Se realizan validaciones específicas para asegurar la integridad de la base de datos.


