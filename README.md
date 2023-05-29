# C# API Project - IPI (M1)

Welcome to the C# API project that allows you to make various requests on the statistics of characters from League of
Legends (LoL) and Overwatch.

> The data used in this project is from [Kaggle](https://www.kaggle.com/), and has been cleaned.
> [League Of Legends S12 statistic](https://www.kaggle.com/datasets/vivovinco/league-of-legends-champion-stats?select=League+of+Legends+Champion+Stats+12.9.csv).
> [Overwatch Hero Stats](https://www.kaggle.com/datasets/mykhailokachan/overwatch-2-statistics?select=ow2_season_03_FINAL_heroes_stats__2023-05-06.csv).

<div align="center">
    <img src="https://www.pcinvasion.com/wp-content/uploads/2022/08/overwatch-2-premium.jpg" height="150">
    <img src="https://cdn1.epicgames.com/offer/24b9b5e323bc40eea252a10cdd3b2f10/LOL_2560x1440-98749e0d718e82d27a084941939bc9d3" height="150">
</div>

This project aims to provide an API to obtain information such as win statistics, individual performance, special
abilities, skill levels,
and more from League Of Legends and Overwatch2 games.

## Table of Contents

- [Installation and run](#installation-and-run)
- [Endpoints](#endpoints)
- [Examples](#examples)
- [Authors](#authors)

## Installation and run

1. Clone this repository to your local machine.
2. Ensure that you have installed the required dependencies.
3. Run the API using your preferred development environment.

You can run the API with the `dotnet` command :

```bash
dotnet run INET410-Linq-CharacterStats.sln ASPNETCORE_URLS=http://localhost:5295 ASPNETCORE_ENVIRONMENT=Development
```

## Endpoints

The API provides the following endpoints:

- `/api/leagueoflegends` : Get the list of LoL characters.
- `/api/leagueoflegends/search?parameter=1` : Get the list of LoL characters that match the search parameter.
- `/api/leagueoflegends/xml` : Get the list of Lol characters in XML format.
- `/api/overwatch2` : Get the list of Overwatch characters.
- `/api/overwatch2/search?parameter=1` : Get the list of Overwatch characters that match the search parameter.
- `/api/overwatch2/xml` : Get the list of Overwatch characters in XML format.

## Examples

### Get the list of LoL characters

```
GET /api/legueoflegends
```

Response:

```json
[
    {
      "name": "Aatrox",
      "class": "Fighter",
      "role": "TOP",
      "tier": "God",
      "score": 77.17,
      "trend": -5.29,
      "winPercentage": 49.54,
      "rolePercentage": 92.59,
      "pickPercentage": 7.61,
      "banPercentage": 6.47,
      "kda": 1.84
    }
]
```

### Get the list of Overwatch character

```
GET /api/overwatch2/
```

Response:

```json
[
  {
    "hero": "Ana",
    "skillTier": "All",
    "kdaRatio": 3.6,
    "pickRatePercentage": 8.66,
    "winRatePercentage": 49.73,
    "eliminationsPer10min": 8.45,
    "ObjectiveKillsPer10min": 3.83,
    "objectiveTimePer10min": 65,
    "damagePer10min": 2357,
    "healingPer10min": 7648,
    "deathsPer10min": 6.66
  }
]
```

## Authors

- [Tykok](https://github.com/Tykok)
