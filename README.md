# PosicionesNet
Examen Técnico Net

Instrucciones: 

Restaurar Base de datos en SQL Server

Abrir Solución con Visual Studio 2015 preferentemente.

Modificar la cadena de conexión de los siguientes proyectos:
- Posiciones
- PosicionesDatos
- PosicionesTest

<add name="Posiciones" connectionString="metadata=res://*/Datos.csdl|res://*/Datos.ssdl|res://*/Datos.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESARROLLO15\SQLEXPRESS;initial catalog=Posiciones;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

Hay que cambiar el data source, quitar el integrated security si se autentica con usuario de SQL y agregar usuario y contraseña si también va a estar autenticado con usuario de SQL. Si se va a autenticar con usuario de windows solo cambiar el data source

Recompilar solución

Ejecutar
