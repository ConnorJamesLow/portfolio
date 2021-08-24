Write-Output "dotnet publish:"
dotnet publish -c Release -o .\publish\wwwroot

Write-Output "push gh-pages"
Set-Location .\publish\wwwroot
git add .
git commit -m "via publish script"
git push
Set-Location ..\..
