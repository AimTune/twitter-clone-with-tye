# A Twitter Clone With Project Tye

Project Tye is a tool that lets you easily develop and deploy microservices applications. My purpose is to develop a Twitter clone using the tool.

If you want to try this example, you must have Tye tool, .NET 7 (for C# Projects) and Docker (For other projects not developed with C#). Install [Docker](https://www.docker.com/), [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) and [Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye).

Command

```console
tye run --watch
```

If you want to change and debug this project, you must use VS Code and [Tye VS Code Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-tye).

For more information, visit [Project Tye Repository](https://github.com/dotnet/tye).

#### TODO

- [x] Create project
- [x] Add SignalR project example (for chat)
- [x] Add Vue project example (with TypeScript and SignalR Client)
- [x] Add Postgres Container
- [ ] Add HealthCheck
- [ ] Add IdentityServer 4
- [ ] Add Elastic (with Dockerfile)
- [ ] Add Distrubited Tracing Tool (Zipkin alternatives (Jaeger))
- [ ] Add gRPC example
- [ ] Add Profile microservice
- [ ] Add Tweet microservice
- [ ] Add Hashtag microservice
- [ ] Add Feed microservice
- [ ] Try microfrontend
