<img src="https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-integrador.png">

# Desafio para candidatos (AdSet Integrador)

## Solicitação:

- Criar funcionalidade para incluir, consultar, excluir e alterar cadastro de carros e na tela de consulta dos veículos possibilitar a seleção por veículo de apenas um pacote para cada portal iCarros e WebMotors, os pacotes serão (Bronze, Diamante, Platinum ou Básico), conforme layout.
- O cadastro deverá possuir os campos (Marca, Modelo, Ano, Placa, Km, Cor, Preço, lista de opcionais para atribuir ao veículo ex.: (Ar Condicionado, Alarme, Airbag, Freio ABS)).
- Deverá ser possível incluir até 15 fotos para o veículo.
- Apenas a km, opcionais e fotos não devem ser obrigatórios.
- O layout codificado deverá ser exatamente o mesmo do arquivo disponível (adset-layout.ai).
- Nos filtros de dropdown deverão ter as seguintes opções por cada drop (<b>Ano Min</b> = 2000, 2001, 2002.. até 2024 | <b>Ano Max</b> = 2000, 2001, 2002.. até 2024 | <b>Preço</b> = 10mil a 50mil, 50mil a 90mil, +90mil | <b>Fotos</b> = Com Fotos, Sem Fotos | <b>Cor</b> = Listar as cores com os valores em distinct dos veículos inseridos).

Após terminar seu teste submeta um pull request e aguarde seu feedback.

## Instruções:
- Criar Projeto do tipo Class Library para separar a camada de Dados.
- Criar Projeto do tipo ASP.NET Web Application com Template MVC/Razor (Front-End)
- A tela de estoque / consulta deverá ser desenvolvida conforme o layout (https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-layout.ai) criado no programa Adobe Illustrator.
- Na camada de dados deixe a estrutura completa do Migration para o Entity Framework Code-First pronta para apenas executarmos e gerar o banco e tabelas.
- Caso você julgar necessário, utilize Design patterns e nos informe quais utilizou e porque.

## Pré-requisitos:
- HTML5, CSS, JavaScript, Bootstrap, POO, C#, .NET 4.0+, WebApi, C#, ASP NET, SQL, LINQ, Entity Framework, Code First, Design Responsivo, WebServices *(SOAP)*, APIs Restfull e Windows Services

### IDE:
 - Visual Studio 2013+
 
### Servidor de Banco:
 - Microsoft SQL Server 2012+

## Notas:
* Lembre-se de fazer um fork deste repositório! Apenas cloná-lo vai te impedir de criar o pull request e dificultar a entrega;
