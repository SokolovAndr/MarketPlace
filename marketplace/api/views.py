from django.shortcuts import render
from django.http import HttpRequest, HttpResponse, Http404, HttpResponse
import json
from django.db import connections
import hashlib as hash

# Create your views here.
def requestProduct(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    if 'id' in request.headers:
        productObj = {}
        with connections['marketplace'].cursor() as cursor:
            cursor.execute(f"SELECT * FROM products WHERE id={request.headers['id']};")
            return HttpResponse(json.dumps(cursor.fetchone()))
    else:
        productStr = json.loads(request.body)
        with connections['marketplace'].cursor() as cursor:
            cursor.execute(f"INSERT INTO products(name, description, photolink, count, price, type, protein, carbohydrate, fat, calories, weight, numberOfVisits) values('{productStr['name']}', '{productStr['description']}', '{productStr['photo']}', {productStr['count']}, {productStr['price']}, '{productStr['type']}', {productStr['protein']}, {productStr['carbohydrate']}, {productStr['fat']}, {productStr['calories']}, {productStr['weight']}, 0);")
            return HttpResponse(json.dumps(cursor.fetchone()))

def requestCatalog(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = []
    type = json.loads(request.body)['type']
    if type == '':
        with connections['marketplace'].cursor() as cursor:
            cursor.execute('SELECT id FROM products ORDER BY numberOfVisits DESC LIMIT 12;')
            SQLResult = cursor.fetchall()
            for i in range(0, SQLResult):
                result.append(SQLResult[i][0])
    else:
        with connections['marketplace'].cursor() as cursor:
            cursor.execute(f"SELECT id FROM products WHERE type={type} ORDER BY numberOfVisits DESC LIMIT 12;")
            SQLResult = cursor.fetchall()
            for i in range(0, SQLResult):
                result.append(SQLResult[i][0])
    jsonResult = json.dumps(result)
    return HttpResponse(jsonResult)

def requestShopCart(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = []
    userId = json.loads(request.body)['id']
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT productsIdJsonStr FROM shopcarts WHERE id={userId};")
        result = json.dumps(cursor.fetchone())
        return HttpResponse(result)

def requestProfile(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = {}
    userToken = json.loads(request.body)['token']
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT fio FROM users WHERE token={userToken};")
        result['ФИО'] = cursor.fetchone()[0]
        return HttpResponse(json.dumps(result))

def requestAddProfile(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = {}
    jsonStr = json.loads(request.body)
    username = json.loads(request.body)['username']
    password = hash.md5(json.loads(request.body)['password'])
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT * FROM users WHERE username={username};")
        if cursor.fetchone() != None:
            return HttpResponse(status=400, content="This username is using")
        else:
            cursor.execute(f"INSERT INTO users(username, password, fio, countMoney, countBonus, ordersIsJsonStr, token) VALUES('{username}', '{password}', '{jsonStr['ФИО']}', 0, 0, '{json.dumps({})}', '{hash.md5(username + password)}');")
            response = HttpResponse(status=200)
            response.set_cookie('token', hash.md5(username + password), max_age=2592000)
            return response

def requestLogin(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = {}
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT password FROM users WHERE username='{json.loads(request.body)}';")
        if cursor.fetchone()[0] == hash.md5(json.loads(request.body)['password']):
            result['result'] = True
            cursor.execute(f"SELECT token FROM users WHERE username='{json.loads(request.body)}';")
            result['token'] = cursor.fetchone()[0]
        else:
            return HttpResponse(status=401)
    response = HttpResponse(json.dumps(result))
    response.set_cookie('token', result['token'], 2592000)
    return response

def requestBuy(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    jsonStr = json.loads(request.body)
    price = 0
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT countMoney, countBonus FROM users WHERE token={jsonStr['token']};")
        countMoney = cursor.fetchone()[0]
        countBonus = cursor.fetchone()[1]
        cursor.execute(f"SELECT productsIdJsonStr FROM shopcarts WHERE userId=(SELECT id FROM users WHERE token='{jsonStr['token']}');")
        products = json.loads(cursor.fetchone()[0])
        for i in range(0,len(products)):
            cursor.execute(f"SELECT price FROM products WHERE id={products[i]};")
            price += cursor.fetchone()[0]
        moneyFull = countMoney + (countBonus / 10)
        if price > moneyFull:
            return HttpResponse(status=420)
        cursor.execute(f"INSERT INTO orders(orderDate, userId, productsIdJsonStr) VALUES(NOW(), (SELECT id FROM users WHERE token={jsonStr['token']}), {json.dumps(products)});")
        cursor.execute(f"UPDATE users SET countBonus={round(price/100) + moneyFull - price}, countMoney={moneyFull-price} WHERE token={jsonStr['token']};")
        cursor.execute(f"UPDATE shopcarts SET productsIdJsonStr='{'{}'}' WHERE userId=(SELECT id FROM users WHERE token='{jsonStr['token']}');")
        return HttpResponse(status=200)

def requestOrders(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    result = []
    jsonReq = json.loads(request.body)
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT id FROM orders WHERE userId=(SELECT id FROM users WHERE token='{jsonReq['token']}');")
        SQLResult = cursor.fetchall()
        for i in range(0, SQLResult):
            result.append(SQLResult[i][0])
        jsonResult = json.dumps(result)
        return HttpResponse(jsonResult)

def requestOrderById(request):
    if request.method != 'POST':
        return HttpResponse(status=404)
    jsonLoad = json.load(request.body)
    with connections['marketplace'].cursor() as cursor:
        cursor.execute(f"SELECT productsIdJsonStr, orderDate FROM orders WHERE id={jsonLoad['id']};")
        SQLResult = cursor.fetchone()
        result = {'products' : SQLResult[0], 'orderDate' : SQLResult[1]}
        return HttpResponse(json.dumps(result))