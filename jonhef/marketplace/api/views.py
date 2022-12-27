from django.shortcuts import render
from django.http import HttpRequest, HttpResponse, Http404, HttpResponse
import json
from django.db import connection
import hashlib as hash

# Create your views here.
def requestProduct(request):
    if request.method != 'POST':
        return Http404()
    if 'id' in request.headers:
        productObj = {}
        with connection.cursor as cursor:
            cursor.execute(f"SELECT * FROM products WHERE id={request.headers['id']}")
            return HttpResponse(cursor.fetchone())
    else:
        productStr = json.loads(request.body)
        with connection.cursor() as cursor:
            cursor.execute(f"INSERT INTO products(name, description, photolink, count, price, type, protein, carbohydrate, fat, calories, weight, numberOfVisits) values('{productStr['name']}', '{productStr['description']}', '{productStr['photo']}', {productStr['count']}, {productStr['price']}, '{productStr['type']}', {productStr['protein']}, {productStr['carbohydrate']}, {productStr['fat']}, {productStr['calories']}, {productStr['weight']}, 0")
            return HttpResponse(cursor.fetchone())

def requestCatalog(request):
    result = []
    type = json.loads(request.body)['type']
    if type == '':
        with connection.cursor() as cursor:
            cursor.execute('SELECT id FROM products ORDER BY numberOfVisits DESC LIMIT 12')
            result.append(cursor.fetchall())
    else:
        with connection.cursor() as cursor:
            cursor.execute(f"SELECT id FROM products WHERE type={type} ORDER BY numberOfVisits DESC LIMIT 12")
            result.append(cursor.fetchall())
    jsonResult = json.dumps(result)
    return jsonResult

def requestShopCart(request):
    result = []
    userId = json.loads(request.body)['id']
    with connection.cursor() as cursor:
        cursor.execute(f"SELECT productsIdJsonStr FROM shopcarts WHERE id={userId}")
        result = json.dumps(cursor.fetchone())
        return HttpResponse(result)

def requestProfile(request):
    result = {}
    userId = json.loads(request.body)['id']
    with connection.cursor() as cursor:
        cursor.execute(f"SELECT fio FROM users WHERE id={userId}")
        result['ФИО'] = cursor.fetchone()[0]
        return HttpResponse(json.dumps(result))

def requestAddProfile(request):
    result = {}
    jsonStr = json.loads(request.body)
    username = json.loads(request.body)['username']
    password = json.loads(request.body)['password']
    with connection.cursor() as cursor:
        cursor.execute(f"SELECT * FROM users WHERE username={username}")
        if cursor.fetchone() != None:
            return HttpResponse(status=400, content="This username is using")
        else:
            cursor.execute(f"INSERT INTO users(username, password, fio, countMoney, countBonus, ordersIsJsonStr) VALUES('{username}', '{password}', '{jsonStr['ФИО']}', 0, 0, '{json.dumps({})}')")
            return HttpResponse(cursor.fetchone()[0])

def requestLogin(request):
    result = {}
    with connection.cursor() as cursor:
        cursor.execute(f"SELECT password FROM users WHERE username='{json.loads(request.body)}'")
        if cursor.fetchone()['password'] == json.loads(request.body)['password']:
            result['result'] = True
        else:
            result['result'] = False
    return HttpResponse(json.dumps(result))