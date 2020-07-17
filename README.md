# LocalizationTool
This is a tool that should help in localization of .NETCore projects with Askmethat.Json.Localizer by Alexandre Teixeira https://github.com/AlexTeixeira/Askmethat-Aspnet-JsonLocalizer.

This is a work in progress in a very early phase.

It should help me (and others) to find text content in a .NET project, substitute it with the injected Localizer component and create the json with translations.

The usage is pretty gross at this moment, just run: 
dotnet.exe LocalizationTool.dll <ProjectPath> <DesiredLocalizerComponentName>

You should also run it from VS/Rider providing the two program arguments.

Stay tuned for future commits and feel free to participate into development. Any helps is appreciated.
