# Hello.Net

## SDK Installation

https://dotnet.microsoft.com/download

### Debian based distros
Add trusted key to package repository
```
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```
Download sdk throug apt
```
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-5.0
```
`dotnet --version`

## Create your first webapp

```
mkdir myFirstDotNetSolution
cd myFirstDotNetSolution
dotnet new sln
mkdir myFirstWebApp
cd myFirstWebApp
dotnet new webapp
```

### Run your first webapp
```
dotnet run
```

## Install your favorite dotnet IDEE(visual studio code)
Go to "https://code.visualstudio.com/download" and download the debian package

```
sudo apt install ./<file>.deb
```
