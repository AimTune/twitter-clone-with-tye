# A Twitter Clone With Project Tye

Project Tye is a tool that lets you easily develop and deploy microservices applications. My purpose is to develop a Twitter clone using the tool.

If you want to try this example, you must have Tye tool, .NET 7 (for C# Projects) and Docker (For other projects not developed with C#). Install [Node.js 18.x+](https://nodejs.org/en), [Docker](https://www.docker.com/), [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) and [Tye](https://github.com/dotnet/tye/blob/main/docs/getting_started.md#installing-tye).

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
- [x] Add gRPC example
- [x] Add Keycloak (Identity Server Alternative)
- [x] Add Authentication and Authorization to Vue project
- [x] Add Authentication and Authorization to .NET Projects
- [x] Add Elasticsearch
- [ ] Add Elasticsearch to .NET Projects
- [ ] Add Distrubited Tracing Tool (Zipkin alternatives (Jaeger))
- [ ] Add HealthCheck
- [ ] Add Profile microservice
- [ ] Add Tweet microservice
- [ ] Add Hashtag microservice
- [ ] Add Feed microservice
- [ ] Try Dapr extension
- [ ] Try microfrontend

If you use elastic extension and get `max virtual memory areas vm.max_map_count [65530] is too low, increase to at least [262144]` error, you can run the following command on your docker host.

```bash
# for windows machine
wsl -d docker-desktop
# run inside docker host machine
sysctl -w vm.max_map_count=262144
```

You can review [REFERENCES](REFERENCES.md) for the resources I used.
