<br />
<p align="center">
  <a href="https://github.com/Quiirex/diplomska_naloga_microservices">
    <img src="https://cdn-icons-png.flaticon.com/512/919/919853.png" alt="Logo" width="150" height="150">
  </a>

  <h1 align="center">Zasnova in razvoj mikrostoritev na osnovi ogrodja .NET in zabojnikov Docker</h1>

  <p align="center">
    Izvorna koda diplomske naloge
  <br/>
  </p>
</p>

<!-- ABOUT THE PROJECT -->
## Opis spletne aplikacije

<p align="center">
V luči demonstracije reševanja tipičnih razvojnih problemov bomo predstavili
mikrostoritven pristop k razvoju aplikacije s pomočjo programskega jezika C#,
ogrodja .NET, Dockerjevih zabojnikov in Kubernetes orkestratorja. Ustvarili bomo
spletno aplikacijo, ki bo temeljila na prej omenjenih tehnologijah. Spletna aplikacija
bo kot osrednjo funkcionalnost omogočala ocenjevanje in komentiranje filmov, poleg
tega bodo uporabljene funkcionalnosti za izris čelnega dela, registracijo in prijavo
uporabnikov, iskanje filmov, dodajanje filmov na različne sezname, itd.
Osnovni protokol za komunikacijo med storitvami bo protokol HTTP. Funkcionalnosti
bodo razdeljene v množico mikrostoritev, ki se bodo izvajale in bodo upravljane v
svojem zabojniku. Orodje Kubernetes bo po potrebi skaliralo število instanc
zabojnikov.
</p>

## Pred zagonom potrebujete naslednje programe
* [Docker desktop](https://www.docker.com/products/docker-desktop/) (z omogočeno Kubernetes integracijo v nastavitvah)
* [Kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)
* [Octant](https://octant.dev/) (po želji)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (po želji)

## Zagon aplikacije (v ukazni vrstici izvedite naslednje ukaze - poskrbite, da ste v istem direktoriju, kot yaml datoteka, katero uvajate v lokalno gručo. Program Docker Desktop mora biti aktiven)
1. ```kubectl create secret generic mssql —from-literal=SA_PASSWORD=”M!cr0s3rv!ce”``` (secret je potreben za delovanje!)
2. ```kubectl apply -f pvc-claim.yaml```
3. ```kubectl apply -f mssql-depl.yaml``` (po izvedbi tega ukaza počakajte nekaj sekund)
4. ```kubectl apply -f identiteta-depl.yaml```
5. ```kubectl apply -f igralci-depl.yaml```
6. ```kubectl apply -f komentiranje-depl.yaml```
7. ```kubectl apply -f ocenjevanje-depl.yaml```
8. ```kubectl apply -f videoteka-depl.yaml```
9. ```kubectl apply -f seznami-depl.yaml```
10. ```kubectl apply -f ocenifilm-depl.yaml```
11. ```kubectl apply -f ocenifilm-np-srv.yaml```
12. ```kubectl apply -f ingress-depl.yaml```

## Če želite samodejno horizontalno skaliranje storitev

13. ```kubectl -n kube-system apply -f metric-server-depl.yaml```
14. ```kubectl autoscale deployment identiteta-depl --cpu-percent=95 --min=1 --max=3```
15. ```kubectl autoscale deployment igralci-depl --cpu-percent=95 --min=1 --max=3```
16. ```kubectl autoscale deployment komentiranje-depl --cpu-percent=95 --min=1 --max=3```
17. ```kubectl autoscale deployment ocenjevanje-depl --cpu-percent=95 --min=1 --max=3```
18. ```kubectl autoscale deployment seznami-depl --cpu-percent=95 --min=1 --max=3```
19. ```kubectl autoscale deployment videoteka-depl --cpu-percent=95 --min=1 --max=3```

## Dostopanje do spletne aplikacije preko brskalnika
1. V ukazni vrstici izvedite ukaz ```kubectl get svc```
2. Preberite port (vrata) za servis imenovan ```ocenifilmnpservice-srv```
3. Primer: ```ocenifilmnpservice-srv       NodePort       10.103.130.79    <none>        80:32530/TCP     36d``` (tukaj nas zanimajo vrata 32530)
4. V brskalnik v tem primeru vpišemo ```localhost:32530``` oz. ```127.0.0.1:32530``` in prispemo na vstopno stran aplikacije
