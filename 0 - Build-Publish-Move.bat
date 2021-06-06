@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget push Panosen.CodeDom.Xml\bin\Release\Panosen.CodeDom.Xml.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate
dotnet nuget push Panosen.CodeDom.Xml.Engine\bin\Release\Panosen.CodeDom.Xml.Engine.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate

move /Y Panosen.CodeDom.Xml\bin\Release\Panosen.CodeDom.Xml.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Xml.Engine\bin\Release\Panosen.CodeDom.Xml.Engine.*.nupkg D:\LocalSavoryNuget\

pause