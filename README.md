
<h1 align="center">
   LocacaoNetAPI
</h1>

## :information_source: Como usar

Para rodar essa aplicação, você irá precisar.

### Clone do Repositório
```bash
# Clonando o repo
$ git clone https://github.com/saulomlcosta/LocacaoNetAPI.git

```

### SQL - Database
```bash
# Criação do Banco de dados
$ Segue scripts de criação das tabelas na API dentro de Infra. Caminho: LocacaoNetAPI.Data/Scripts

```

### Backend - .NET
```bash
# O Projeto se encontra dentro da pasta LocacaoNetAPI.
$ LocacaoNetAPI/

# Build do projeto utilizando o runtime correspondente a versão do framework .NET.
$ Que no caso, foi usada a NET6.0.

# Documentação Swagger
$ Após rodar a aplicação, terá acesso a documentação Swagger com os Endpoints correspondentes.

# ConnectionString - Conexão com o Banco de Dados
$ No appsettings.json segue as configurações que foram usadas.
$ No appsettings.json segue as configurações que foram usadas.
$ (Logo irei configurar o docker-compose no Repositório para evitar essa seção.)

# EndPoint de Filmes
$ Para inserir filmes no POST, é necessário enviar um arquivo xlsx.
```

### Frontend - React
```bash
# Primeiramente
$ Rodar a aplicação Backend para disponibilizarmos a API com seus respectivos EndPoints.

# O Projeto se encontra dentro da pasta locacaofront.
$ locacaofront/

# Instalar as dependências
$ npm install

# Rodar o Projeto
$ npm start
```

### Informações adicionais
O repositório ainda não está finalizado, projeto FrontEnd ainda está em desenvolvimento, fora os futuras otimizações que pretendo fazer no repositório como um todo.


Feito com o ♥ by Saulo Costa :wave: [Get in touch!](https://www.linkedin.com/in/saulocosta10/)
