GET _search
{
  "query": {
    "match_all": {}
  }
}

DELETE some-logs

POST some-logs/_doc
{
  "message":"Fruit added to the basket",
  "date":"2020-09-08T18:52:00",
  "level":"info",
  "counter":2
}

get some-logs

POST some-logs/_doc
{
  "message":"Fruit added to the basket",
  "date":"2020-09-08T18:53:00",
  "level":"info",
  "counter":4
}

POST some-logs/_doc
{
  "message":"Fruit added to the basket",
  "date":"2020-09-08T18:54:00",
  "level":"info",
  "counter":2
}

POST some-logs/_doc
{
  "message":"Oh no! Something wrong!",
  "date":"2020-09-08T18:55:00",
  "level":"error",
  "error":{
    "message":"Stackoverflow Excetpion",
    "line":123,
    "class":"SomeClass"
  }
}

DELETE /cars

POST /cars/_bulk
{ "index": {}}
{ "price" : 10000, "color" : "red", "make" : "honda", "sold" : "2019-10-28" }
{ "index": {}}
{ "price" : 20000, "color" : "red", "make" : "honda", "sold" : "2019-11-05" }
{ "index": {}}
{ "price" : 30000, "color" : "green", "make" : "ford", "sold" : "2019-05-18" }
{ "index": {}}
{ "price" : 15000, "color" : "blue", "make" : "toyota", "sold" : "2019-07-02" }
{ "index": {}}
{ "price" : 12000, "color" : "green", "make" : "toyota", "sold" : "2019-08-19" }
{ "index": {}}
{ "price" : 20000, "color" : "red", "make" : "honda", "sold" : "2019-11-05" }
{ "index": {}}
{ "price" : 80000, "color" : "red", "make" : "bmw", "sold" : "2019-01-01" }
{ "index": {}}
{ "price" : 25000, "color" : "blue", "make" : "ford", "sold" : "2019-02-12" }