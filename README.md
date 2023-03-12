# Rest Api для игры в крестики нолики для прохождение стажировки в SENSE CAPITAL

## Endpoints

## Get ./api/game/startgame 

создает стол для игры

**входные параметры:** отсуствуют

**выходные параметры:** 
StatusCode: 200
```json
{
  "TableId":id
}
```

## POST ./api/game/move

вставляет X или O в зависимости от очереди(первый ходит X)

**входные параметры:**
```json
{
    "tableId": id,
    "position": int
}
```

**выходные параметры:**
```json
{
  "MessageError" : message
}

Сообщение об ошибке:

Table not Found - 404
Game is Finished - 400
The field is not empty - 400
```
Или

```json
{
    "resultGame": int,
    "message": message
}

resultGame перечесление состоит из:

NotFinished = 0 - игра не закончилась
Draw = 1 - ничья
X = 2 - X победил
O = 3 - O победил
```
