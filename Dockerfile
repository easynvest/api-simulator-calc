FROM fedora
MAINTAINER "joliveira@easynvest.com.br"
ENV RELEASE_DATE ${RELEASE_DATE}
ENV SEM_VER ${SEM_VER}
EXPOSE 80
RUN rpm --import https://packages.microsoft.com/keys/microsoft.asc
RUN echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/dotnetdev.repo 
RUN dnf -y update && dnf -y install libunwind libicu compat-openssl10 nginx dotnet-sdk-2.0.0 python-setuptools &&  easy_install supervisor
RUN mkdir /var/app
ADD Easynvest.SimulatorCalc /var/app
ADD nginx.conf /etc/nginx/nginx.conf
ADD supervisord.conf /usr/etc/supervisord.conf
WORKDIR /var/app/Easynvest.SimulatorCalc.Domain
RUN dotnet add package Microsoft.Extensions.Options --version 2.0.0 && cd ../ && dotnet restore && dotnet publish
WORKDIR /var/app
ENTRYPOINT ["/usr/bin/supervisord", "-c", "/usr/etc/supervisord.conf"]