FROM golang:1.18 as build

WORKDIR /app
COPY . ./

RUN go mod init hello
RUN go build -o /app/hello

#sem isso, vai precisar de quase 1GB espaço
FROM alpine:3.22.0
COPY --from=build /app/hello /app/hello

ENV app="hello"
ARG hello="Linux"
ENV hello=$hello
RUN echo "$hello is life S2!"

CMD [ "/app/hello" ]