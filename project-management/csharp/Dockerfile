FROM pulumi/pulumi-build-container as build

RUN git clone https://github.com/tmeckel/pulumi-azuredevops && \
    cd pulumi-azuredevops && \
    make build

FROM alpine:3.11

RUN apk update && \
    apk add \
        ca-certificates \
        curl \
        dpkg \
        gnupg \
        bash

# Install .NET Core SDK
# RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb \
#         -O packages-microsoft-prod.deb && \
#     dpkg -i packages-microsoft-prod.deb && \
#     rm packages-microsoft-prod.deb && \
#     apk update && \
#     apk add \
#        dotnet-sdk-3.1

# Install .NET Core SDK
RUN apk update && \
    apk add \
        zlib \
        icu-libs \
        lttng-ust && \
    curl -fsSL https://dot.net/v1/dotnet-install.sh | bash -s -- -Channel LTS && \
    dotnet --list-sdks

# Passing --build-arg PULUMI_VERSION=vX.Y.Z will use that version
# of the SDK. Otherwise, we use whatever get.pulumi.com thinks is
# the latest
ARG PULUMI_VERSION=latest

# Install the Pulumi SDK, including the CLI and language runtimes.
RUN if [ "$PULUMI_VERSION" = "latest" ]; then \
    curl -fsSL https://get.pulumi.com/ | bash; \
  else \
    curl -fsSL https://get.pulumi.com/ | bash -s -- --version $(echo $PULUMI_VERSION | cut -c 2-); \
  fi && \
  mv ~/.pulumi/bin/* /usr/bin

COPY --from=build ~/go/bin/pulumi-resource-azuredevops /usr/bin
COPY --from=build ~/pulumi-azuredevops/sdk/dotnet/bin/**/*.nuget /var/nuget/

# I think it's safe to say if we're using this mega image, we want pulumi
ENTRYPOINT ["pulumi"]