FROM microsoft/aspnetcore-build:2.0.0 AS build
ADD Easynvest.SimulatorCalc /var/build
WORKDIR /var/build
RUN dotnet restore
RUN dotnet publish --output /output --configuration Release

FROM microsoft/aspnetcore:2.0.0
MAINTAINER "joliveira@easynvest.com.br"
ENV RELEASE_DATE ${RELEASE_DATE}
ENV SEM_VER ${SEM_VER}
EXPOSE 5000
COPY --from=build /output /var/app
WORKDIR /var/app
ENTRYPOINT ["dotnet", "Easynvest.SimulatorCalc.Api.dll"]