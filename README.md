![Logo Preto](https://i.imgur.com/LyQ6ygf.png)

## API Web ASP.NET Core para Gestão de Funcionários

Esta API permite operações CRUD para registros de funcionários e facilita a coleta de dados de interação dos usuários com a plataforma, submetendo-os para análise de produtividade em softwares ERP.

## Integrantes do Grupo global
- **Breno Lemes Santiago** - RM: 552270
- **Felipe Guedes Gonçalves** - RM: 550906
- **Luiz Fellipe Soares de Sousa Lucena** - RM: 551365
- **Nina Rebello Francisco** - RM: 99509
- **Vitória Maria de Camargo** - RM: 552344

## Documentação da API - Swagger

A documentação está disponível no navegador quando o programa está em execução.

## Arquitetura

**Escolha da Arquitetura**: Monolítica

### Justificativa

A arquitetura monolítica integra todos os componentes da aplicação em uma única unidade, simplificando a comunicação e reduzindo a complexidade de configuração e manutenção. Esse modelo aprimora os processos de desenvolvimento e implantação ao tratar a aplicação como um sistema coeso. Embora não ofereça a mesma escalabilidade e flexibilidade que os microserviços, uma arquitetura monolítica é adequada para equipes menores e para projetos que priorizam simplicidade e desenvolvimento rápido. Além disso, proporciona uma visão unificada da aplicação, facilitando o monitoramento e a depuração. Nossa decisão de adotar essa arquitetura foi baseada na necessidade de uma solução mais direta e menos complexa para o nosso projeto atual.

## Padrões de Design Utilizados

- **Padrão Repository**: Este padrão abstrai a lógica de acesso a dados, promovendo a separação entre a lógica de negócios e o acesso ao banco de dados. Ele aumenta a flexibilidade e simplifica a troca de mecanismos de persistência.

- **Padrão MVC**: Implementado para gerenciar a lógica de controle e a interação do usuário com a aplicação. Os controladores tratam as requisições, processam-nas e retornam as respostas apropriadas, mantendo uma separação clara entre a lógica de apresentação e a lógica de negócios.

- **Padrão Singleton**: Utilizado para garantir que apenas uma instância de um serviço centralizado seja criada e utilizada em toda a aplicação. Esse padrão é útil para gerenciar configurações e serviços que devem ser compartilhados entre diferentes partes da aplicação.

## Testes Implementados

A API conta com uma suíte de testes automatizados, garantindo a qualidade e a confiabilidade do código. Os testes incluem:

- **Testes Unitários**: Validação da lógica de negócios e dos métodos dos repositórios, garantindo que cada componente funcione de forma isolada.
- **Testes de Integração**: Verificação da interação com a API ViaCEP.
- **Testes Sistema**: Garantia de que as operações CRUD funcionem conforme esperado, verificando os endpoints da API.

### Instruções para Rodar os Testes

Para garantir a qualidade do código, os testes automatizados devem ser executados regularmente. Siga as instruções abaixo para rodar os testes:

1. **Abra o terminal no diretório do projeto.**

2. **Execute o seguinte comando para rodar os testes unitários e de integração:**

   ```bash
   dotnet test

## Práticas de Clean Code

Durante o desenvolvimento, foram aplicadas diversas práticas de Clean Code para manter a legibilidade e a manutenção do código. Algumas das práticas incluem:

- **Nomenclatura Clara**: Nomes descritivos para variáveis, métodos e classes, facilitando a compreensão do código.
- **Funções Pequenas e Coesas**: Métodos com uma única responsabilidade, promovendo a simplicidade e a reutilização do código.
- **Organização de Código**: Estrutura clara de pastas e arquivos, separando responsabilidades e promovendo a modularidade.

## Funcionalidades de IA Generativa

A API foi aprimorada com funcionalidades de IA generativa, incluindo a implementação de análise de sentimentos para avaliar feedbacks dos recrutadores sobre os funcionários. Essa análise ajuda a interpretar as percepções dos recrutadores de forma quantitativa e qualitativa, permitindo uma melhor compreensão do desempenho e das áreas de melhoria dos funcionários.

### Endpoint de Feedback

Foi disponibilizado um endpoint que permite adicionar feedbacks sobre os funcionários e, em seguida, receber a resposta da análise de sentimentos. Esse fluxo possibilita que os recrutadores insiram suas observações e recebam uma avaliação imediata sobre a natureza do feedback (positivo ou negativo). 

**Exemplo de Uso:**

- **Endpoint**: `POST /api/Sentiment/predict`
- **Corpo da Requisição**:
  ```json
  {
      "col0": "O funcionário é bom e demonstrou grande comprometimento e habilidade na execução de suas tarefas.",
      "col1": 0
  }

## Utilização do Serviço ViaCEP

A API utiliza a ViaCEP para obter informações de endereços a partir do CEP fornecido. Esta integração facilita a inserção de dados de endereço de forma precisa e rápida, melhorando a experiência do usuário ao registrar funcionários. A API ViaCEP é uma ferramenta útil que fornece informações como logradouro, bairro, cidade e estado, eliminando a necessidade de preenchimento manual e minimizando erros.

**Exemplo de Uso:**

- **Endpoint**: `GET /CEP`
- **Input**:
  ```
  Digitar um CEP válido
## HealthCheck

Usei **Health Check** para monitorar automaticamente a saúde dos serviços da minha aplicação, garantindo que cada componente esteja funcionando corretamente. Com isso, consigo identificar rapidamente falhas e indisponibilidades, permitindo redirecionar o tráfego para instâncias saudáveis e melhorar a resiliência do sistema. Em um ambiente com múltiplos serviços, essa prática é essencial para manter a alta disponibilidade e otimizar o desempenho geral, evitando que falhas em uma parte da aplicação afetem a experiência do usuário.

**Exemplo de Uso:**

- **URL**:
  ```
  https://localhost:7121/Health-Check
## Instruções para Rodar a API

### Pré-requisitos

- **.NET SDK**: Certifique-se de ter o .NET SDK instalado. Você pode baixar a versão mais recente do [site oficial do .NET](https://dotnet.microsoft.com/download).

- **Banco de Dados**: O projeto usa um banco de dados SQL Developer - Oracle. Certifique-se de ter uma instância disponível e atualize a string de conexão no arquivo `appsettings.json` se necessário.

### Passos para Executar a API

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/LuizLucena97/ERP-InsightWise.git
