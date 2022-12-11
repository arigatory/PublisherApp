## Запуск postgres

``` bash
docker run --name pgsql-dev -e POSTGRES_PASSWORD=Pa$$w0rd -p 5432:5432 postgres
```

## Добавление пароля пользователю

``` bash
docker exec -it pgsql-dev bash
psql -h localhost -U postgres
```
``` sql
ALTER USER postgres PASSWORD 'Pa$$w0rd';
```