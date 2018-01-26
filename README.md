[![Build Status](https://travis-ci.org/melvinlee/aspnetcore2.0-docker.svg?branch=master)](https://travis-ci.org/melvinlee/aspnetcore2.0-docker) [![Build status](https://ci.appveyor.com/api/projects/status/xpuheok6seri9lhq?svg=true)](https://ci.appveyor.com/project/melvinlee/aspnetcore2-0-docker)


# ASP.NET Core HitCounter

This project demostrate how to run an ASP.NET Core 2.0 App in a docker container.

## Razor Pages

This project using [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages/?tabs=visual-studio).

### Prerequisites

Install .NET Core [2.0.0](https://dot.net/core) or later.

If you're using Visual Studio, install Visual Studio 15.3 or later with the following workloads:

- ASP.NET and web development
- .NET Core cross-platform development

## Build

First, restoring nuget packages.

	$ dotnet restore

Now, publish the app.

	$ dotnet publish

## Docker

We need to build a docker image before running ASP.NET Core app in a container. 

To build a image, we need a [Dockerfile](https://docs.docker.com/engine/reference/builder/) which contain instructions on how to assembly as image.

Let's build a new image by specify tag `aspnetcore/hitcounter`.

	$ docker build -t aspnetcore/hitcounter .

To verify image build successfully.

	$ docker image ls
	aspnetcore/hitcounter   latest              a1dcd224d495        2 seconds ago       283MB

Now, let's run the newly build image in detach mode.

	$ docker run --rm -p 80:80 -d aspnetcore/hitcounter 

To list running container.

	$ docker ps
	CONTAINER ID        IMAGE                   COMMAND                  CREATED             STATUS              PORTS                NAMES
	5697e1c05ff8        aspnetcore/hitcounter   "dotnet hit-counte..."   4 minutes ago       Up 4 minutes        0.0.0.0:80->80/tcp   youthful_bassi

Let's hit the page by using docker host ip.