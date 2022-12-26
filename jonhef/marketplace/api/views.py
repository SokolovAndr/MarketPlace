from django.shortcuts import render
from django.http import HttpRequest, HttpResponse, Http404
import json
from django.db import connection

# Create your views here.
def requestProduct(request):
    if request.method != 'POST':
        return Http404()
    if 'id' in request.headers:
        productObj = {}
        with connection.cursor as cursor:
            cursor.execute(f"SELECT * FROM products WHERE id={request.headers['id']}")
            return HttpResponse(cursor.fetchone())
    productStr = json.load(request.body)
    with connection.cursor() as cursor:
        cursor.execute(f"INSERT INTO products(name, description, photolink, count, price, type, protein, carbohydrate, fat, calories, weight) values('{productStr['name']}', '{productStr['description']}', '{productStr['photo']}', {productStr['count']}, {productStr['price']}, '{productStr['type']}', {productStr['protein']}, {productStr['carbohydrate']}, {productStr['fat']}, {productStr['calories']}, {productStr['weight']}")
    