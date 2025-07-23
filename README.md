# CleanTxtExport

Un servicio de trabajo (.NET Worker Service) que extrae datos de una base de datos PostgreSQL y los exporta a archivos de texto de forma automática y periódica.

## 📋 Descripción

CleanTxtExport es una aplicación desarrollada en .NET 8.0 que implementa el patrón de arquitectura limpia (Clean Architecture) para exportar datos de la tabla `perso` desde una base de datos PostgreSQL hacia archivos de texto (.txt) con marcas de tiempo.

### Características principales

- ✅ Servicio de trabajo en segundo plano (Background Service)
- ✅ Arquitectura limpia con separación de responsabilidades
- ✅ Conexión a base de datos PostgreSQL
- ✅ Exportación automática cada 10 segundos
- ✅ Archivos de salida con marca de tiempo
- ✅ Logging integrado
- ✅ Filtrado de datos (solo registros con fecha válida)

## 🏗️ Arquitectura

El proyecto sigue los principios de Clean Architecture con las siguientes capas:

```
├── App.Dominio/          # Entidades del dominio
├── App.Applicacion/      # Interfaces y lógica de aplicación
├── App.Infraestructura/  # Implementaciones y servicios
└── App.WorkerService/    # Punto de entrada y configuración
```

### Capas del proyecto

- **App.Dominio**: Contiene las entidades del dominio (`Perso`)
- **App.Applicacion**: Define las interfaces de servicios (`IPersoService`)
- **App.Infraestructura**: Implementa los servicios de datos y acceso a base de datos
- **App.WorkerService**: Servicio principal que ejecuta el proceso de exportación

## 🚀 Tecnologías utilizadas

- **.NET 8.0**
- **C#**
- **PostgreSQL**
- **Dapper** (ORM ligero para acceso a datos)
- **Npgsql** (Driver para PostgreSQL)
- **Microsoft.Extensions.Hosting** (Para Worker Service)

## 📦 Estructura de datos

### Entidad Perso

```csharp
public class Perso
{
    public int id { get; set; }
    public int bin_id { get; set; }
    public string? cliente { get; set; }
    public DateTime? fecha { get; set; }
}
```

## ⚙️ Configuración

### Base de datos

El proyecto está configurado para conectarse a PostgreSQL con los siguientes parámetros por defecto:

```csharp
Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=db_ejemplo
```

### Estructura de tabla requerida

```sql
CREATE TABLE perso (
    id INTEGER PRIMARY KEY,
    bin_id INTEGER,
    cliente VARCHAR,
    fecha TIMESTAMP
);
```

## 🛠️ Instalación y ejecución

### Prerrequisitos

- .NET 8.0 SDK
- PostgreSQL
- Base de datos `db_ejemplo` con la tabla `perso`

### Pasos de instalación

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/harlericho/CleanTxtExport.git
   cd CleanTxtExport
   ```

2. **Restaurar paquetes NuGet**

   ```bash
   dotnet restore
   ```

3. **Configurar la base de datos**

   - Asegúrate de que PostgreSQL esté ejecutándose
   - Crear la base de datos `db_ejemplo`
   - Crear la tabla `perso` con la estructura indicada

4. **Compilar el proyecto**

   ```bash
   dotnet build
   ```

5. **Ejecutar el servicio**
   ```bash
   cd App.WorkerService
   dotnet run
   ```

## 📝 Funcionamiento

1. El servicio se ejecuta cada **10 segundos**
2. Consulta la tabla `perso` filtrando solo registros con fecha válida
3. Ordena los resultados por fecha de forma descendente
4. Genera un archivo de texto con formato delimitado por tabulaciones
5. Guarda el archivo con nombre `perso_export_YYYY-MM-DD_HH-mm-ss.txt`

### Formato del archivo de salida

```
id    bin_id    cliente    fecha
1     123       Cliente1   2025-01-15 10:30:00
2     124       Cliente2   2025-01-15 11:45:00
```

## 📁 Archivos generados

Los archivos se guardan en el directorio base de la aplicación con el formato:

```
perso_export_2025-01-15_14-30-25.txt
```

## 🔧 Personalización

### Cambiar intervalo de ejecución

Modificar en `Worker.cs`:

```csharp
await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
```

### Cambiar cadena de conexión

Modificar en `Program.cs`:

```csharp
var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=db_ejemplo";
```

### Personalizar consulta

Modificar la consulta SQL en `PersoService.cs`:

```csharp
var result = await connection.QueryAsync<Perso>("...");
```

## 📊 Logging

El servicio incluye logging integrado que muestra:

- Inicio de cada ciclo de ejecución
- Ruta del archivo generado
- Timestamp de cada operación

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

## 👤 Autor

**harlericho**

- GitHub: [@harlericho](https://github.com/harlericho)

---

⭐ ¡No olvides dar una estrella al proyecto si te fue útil!
