OddsCalc5000
`cd OddsCalc5000`
`docker build --tag oddscalc5000 -f ./Dockerfile ..`
`docker container run -dp 8080:80 oddscalc5000`
visit http://localhost:8080
