## ������ postgres

``` bash
docker-compose up
```

## ������ pgAdmin

<http://localhost:5050/>


<img src="./images/pgAdmin.webp"
     alt="Settings example" />

�����, ������ � ����� `docker-compose.yml`

## ������ �����������

`@"Host=localhost;Username=root;Password=root;Database=PubDatabase"`

### ���������� ������ ������������

���� ��������� �� ����� docker-compose, �� ����� ����� ������� �������� ������ ������������, 
����� ������������ � ������ �����������

``` bash
docker exec -it pgsql-dev bash
psql -h localhost -U postgres
```
``` sql
ALTER USER postgres PASSWORD 'Pa$$w0rd';
```