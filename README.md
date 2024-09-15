
# ERP-InsightWise API

## Integrantes do Grupo
- **Breno Lemes Santiago** - RM: 552270
- **Felipe Guedes Gonçalves** - RM: 550906
- **Luiz Fellipe Soares de Sousa Lucena** - RM: 551365
- **Nina Rebello Francisco** - RM: 99509
- **Vitória Maria de Camargo** - RM: 552344

## Documentação da API - Swagger

Documentação disponível no navegador ao rodar o programa.

## Arquitetura

**Escolha da Arquitetura**: Monolítica


#### Justificativa:

Em uma arquitetura monolítica, todos os componentes da aplicação são desenvolvidos e implantados como uma única unidade, o que simplifica a comunicação entre eles e reduz a complexidade da configuração e manutenção. 

Esse modelo facilita o desenvolvimento e a implantação, uma vez que a aplicação é tratada como um único sistema coeso. Embora não ofereça a mesma escalabilidade e flexibilidade que uma arquitetura de microserviços, a arquitetura monolítica é mais adequada para equipes menores e para projetos onde a simplicidade e o tempo de desenvolvimento são prioritários. Além disso, a abordagem monolítica permite uma visão unificada da aplicação, tornando mais fácil o monitoramento e a depuração. A decisão de usar uma arquitetura monolítica foi baseada na necessidade de uma solução mais direta e menos complexa para o nosso projeto atual.



## Design Patterns Utilizados

- **Padrão Repository**: Utilizado para abstrair a lógica de acesso a dados e promover a separação entre a lógica de negócios e o acesso ao banco de dados. Isso permite uma maior flexibilidade e facilidade na troca de mecanismos de persistência.

- **Padrão Controller**: Implementado para gerenciar a lógica de controle e a interação entre o usuário e a aplicação. Os controladores são responsáveis por receber as requisições, processá-las e retornar as respostas apropriadas, mantendo uma separação clara entre a lógica de apresentação e a lógica de negócios.

- **Padrão Singleton**: Implementado para garantir que apenas uma instância de um serviço centralizado seja criada e utilizada em toda a aplicação. Este padrão é útil para gerenciar configurações e serviços que devem ser compartilhados entre diferentes partes da aplicação.


## Instruções para Rodar a API

### Pré-requisitos

- **.NET SDK**: Certifique-se de ter o .NET SDK instalado. Você pode baixar a versão mais recente do [site oficial do .NET](https://dotnet.microsoft.com/download).

- **Banco de Dados**: O projeto usa um banco de dados SQL Developer - Oracle. Certifique-se de ter uma instância disponível e atualize a string de conexão no arquivo `appsettings.json` se necessário.

### Passos para Executar a API

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/seu-usuario/erp-insightwise.git
