# Introduction 
 Code Challenge Juntos Somos+

# PreRequisitos
 - Visual Studio 2022
 - Framework .Net 8.0

<!-- # Instruções
1 - Definir o projeto Juntos.SomosMais.Challenge.API como projeto de inicialização caso não esteja.

![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/022fe8c0-2bff-4a47-aafd-6bab5e245c76)

2 - Ao iniciar o Sistema irá executar o Middlewares InitialLoadService wm Background.

![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/461b0346-a3a7-4fd0-838d-afaed30593f1)

3 - Serão armazenados 2 mil registro em memória readonly.

4 - Após a carga dos dados, o swagger será carregado em tela.

![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/9710f1d1-8406-492f-b689-c5c05868e97c)

5 - Com o Swagger em tela basta executar o GET Passando a entrada abaixo:

![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/e13ac187-9159-4976-b3e6-e7930084d24c) -->

Onde os parametros de entrada são todos obrigatórios e devem ser preenchidos conforme abaixo:

Region = Sul ou Sudeste ou Centro-Oeste ou Norte ou Nordeste
Type = Especial ou Normal ou Laborious
PageNumber = Número da pagina desejada (ex: 1)
PageSize = Número de registros por página

![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/0d1877a7-c2db-4ae2-95c6-7f2f55a1a94b)


![image](https://github.com/tcoelho80/Juntos.SomosMais.Challenge/assets/51813749/70596d6a-22f2-4c35-89a7-e0a372f31dd0)


Observação:
- Acredito que a classificação não esteja certo, nunca trabalhei com GeoLocalização e não achei muita coisa para desenvolver a função adequadamente.
- Foquei no código, empenhando um código limpo e com qualidade.
- A camada de infra foi construida mas não esta sendo utilizada, pois os dados não estão sendo persistidos em banco, mas criei para que a mesma demosntre as camadadas  
