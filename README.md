# Windows Form Cervantes

## Descrição
Aplicação desktop utilizando Windows Forms e banco de dados PostgreSQL.

## Criação das Tabelas

1. Certifique-se de que você tem PostgreSQL instalado.
2. Conecte ao seu banco de dados PostgreSQL usando o PgAdmin, terminal ou outro cliente SQL.
3. Execute o arquivo `create_tables.sql` para criar as tabelas necessárias.

### Comando:
```sh
psql -U seu_usuario -d seu_banco_de_dados -a -f create_tables.sql
```

## Execução da Aplicação
1. Abra o projeto `CervantesWindowsForm` no Visual Studio.
2. Configure a string de conexão no `App.config`.
3. Compile e execute a aplicação.
