

<!-- local-development:start -->
# Desarrollo local

Puedes abrir este repositorio en VS Code, Antigravity o Sublime Text. El compilador y los servicios necesarios dependen del componente indicado abajo.

## Visual Studio 2022 / .NET Framework

Instala la carga de trabajo de escritorio .NET y el paquete de destino indicado en la tabla. Los proyectos ASP.NET también requieren la carga web e IIS Express. Abre la solución `.sln` correspondiente y selecciona el proyecto de aplicación para iniciar.

```powershell
# Ejecutar desde Developer PowerShell de Visual Studio 2022
$solutionDir = (Resolve-Path 'Semana_4').Path + '\'
MSBuild.exe 'Semana_4/Semana_4/Semana_4.csproj' /restore /p:RestorePackagesConfig=true /p:Configuration=Debug /p:DeployOnBuild=false "/p:SolutionDir=$solutionDir"
```

## Componentes y validación

Inventario y compilaciones locales del 2026-11-15. Una compilación correcta no acredita todavía interacción, compatibilidad de base de datos, instalador ni despliegue.

| Componente | Tipo / destino | Validación |
| --- | --- | --- |
| [Semana_4/Semana_4.sln](<Semana_4/Semana_4.sln>) | solution | Sin ejecutar |
| [Semana_4/Semana_4/Semana_4.csproj](<Semana_4/Semana_4/Semana_4.csproj>) | dotnet / v4.8.1 | Compila; prueba funcional pendiente |

## Archivos ignorados

`.gitignore` excluye credenciales locales, estado del editor y salidas de las herramientas detectadas. No deja de versionar archivos que ya estaban en Git. Los manifiestos, archivos de bloqueo, recursos fuente y scripts de esquema forman parte del código.
<!-- local-development:end -->
