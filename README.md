# SecureBank
[![Docker Automated](https://img.shields.io/docker/cloud/automated/ssrd/securebank.svg)](https://hub.docker.com/r/ssrd/securebank)
[![Docker Build status](https://img.shields.io/docker/cloud/build/ssrd/securebank.svg)](https://hub.docker.com/r/ssrd/securebank/builds)
[![License](https://img.shields.io/github/license/ssrdio/SecureBank)](https://github.com/ssrdio/SecureBank/blob/master/LICENSE)

SecureBank is a FinTech application which contains all OWASP TOP 10 security vulnerabilities along with some other security flaws found in real-world applications.

![alt text](preview.gif "SecureBankPreview")

# Setup
> You can setup SecureBank application from source code, or simply pull it from [Docker Hub](https://hub.docker.com/r/ssrd/securebank).

## From source
> Make sure that you have Microsoft SQL Server DB available. You can install or run it inside docker.

1. Install [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
2. Install [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) or just run with  [Visual Studio Code](https://code.visualstudio.com/download)
3. Clone from GitHub
4. Navigate to directory SecureBank -> src
5. `dotnet run` or open solution in IDE and run there 

## From Docker
1. Install [Docker](https://docs.docker.com/get-docker/)
2. Execute `docker run -p 80:80 -p 5000:5000 -p 1080:1080 ssrd/securebank`
3. Open [http://localhost:80](http://localhost:80)

## Docker with multiple containers
1. Install [Docker](https://docs.docker.com/get-docker/)
2. Install [Docker Compose](https://docs.docker.com/compose/install/)
3. Run `docker-compose up`


## CTF-Mode
If you want to run SecureBank in CTF mode we have also prepared this option. It will create CTFd compatible export file.

Run  `docker run -p 80:80 -p 5000:5000 -e 'AppSettings:Ctf:Enabled=true' -e 'AppSettings:Ctf:Seed=example' ssrd/securebank`